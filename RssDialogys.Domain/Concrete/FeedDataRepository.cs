using System;
using System.Collections.Generic;
using System.Linq;
using RssDialogys.Domain.Abstract;
using RssDialogys.Domain.Entities;
using NLog;


namespace RssDialogys.Domain.Concrete
{
    public class FeedDataRepository:IFeedDataRepository
    {
        private string _imageId;
        private bool _saveResult;
        private IImageRepository _save;
        public IQueryable<Item> GetItems
        {
            get { return _context.Items.OrderByDescending(x=>x.PublishDate); }
        }
        private readonly EfDbContext _context = new EfDbContext();
        public void SaveFeedsData(IEnumerable<Item> items)
        {
            using (var context = new EfDbContext())
            {
                foreach (var item in items)
                {
                    _imageId = Guid.NewGuid().ToString();
                    _saveResult = false;
                    Item dbEntry =
                        context.Items.FirstOrDefault(x => x.PublishDate == item.PublishDate && x.Title == item.Title && x.Content.Length == item.Content.Length);   
                    //zabezpieczenie przed zapisaniem takim samych danych oraz pustych pozycje co moze miec miejsce przy braku połączenia z rss.
                    if (dbEntry == null && item.Href != "")
                    {
                        _save = new ImageRepository();
                        _saveResult=_save.UploadAndSaveImage(_imageId, item.Href);
                        if (_saveResult)
                        {
                            item.ImageId = _imageId;
                            item.UploadDate = DateTime.Now;
                            NlogEngine.logger.Trace("RssDialogys.Domain.Concrete.FeedDataRepository.SaveFeedsData Apend new item to database " + item.Title);
                            context.Items.Add(item);
                        }                       
                    }
                }
                context.SaveChanges();
            }          
        }

        public IEnumerable<CategoryPubDateQuantity> GetCategiesInformations()
        {
            NlogEngine.logger.Trace("GetCategoriesInformations");
            return
                _context.Items.GroupBy(c => c.Category)
                    .Select(
                        x =>
                            new CategoryPubDateQuantity
                            {
                                Category = x.Key,
                                PubDate = x.Max(c => c.PublishDate),
                                Quantity = x.Distinct().Count()
                            }).OrderByDescending(x => x.Quantity);
        }

        public IEnumerable<Item> GetItemsForChangePagePresentation(int page, int itemsPerPage,string category)
        {
            NlogEngine.logger.Trace("RssDialogys.Domain.Concrete.FeedDataRepository.GetItemsForChangePagePresentation page{0} itemsPerPage{1} category{2}", page, itemsPerPage,
                category);
            return _context.Items.OrderByDescending(x => x.PublishDate)
                .Where(x => x.Category == category)
                .Skip((page - 1)*itemsPerPage)
                .Take(itemsPerPage);
        }

        public IEnumerable<Item> GetItemsForChooseCategoryPresentation(int itemsPerPage,string category)
        {
            NlogEngine.logger.Trace("RssDialogys.Domain.Concrete.FeedDataRepository.GetItemsForChooseCategoryPresentation itemsPerPage{0} category{1}", itemsPerPage, category);
            return _context.Items.OrderByDescending(x => x.PublishDate)
                .Where(x => x.Category == category)
                .Take(itemsPerPage);
        }

        public IEnumerable<ImageId> GetImageIdForCategory(string category)
        {
            NlogEngine.logger.Trace("RssDialogys.Domain.Concrete.FeedDataRepository.GetImageIdForCategory category{0}", category);
            return _context.Items.Where(x => x.Category == category).Select(x => new ImageId {Id = x.ImageId});
        }
    }
}
