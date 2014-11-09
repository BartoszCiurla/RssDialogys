using System.Collections.Generic;
using System.Linq;
using RssDialogys.Domain.Entities;

namespace RssDialogys.Domain.Abstract
{
    public interface IFeedDataRepository
    {
        void SaveFeedsData(IEnumerable<Item> items);
        IEnumerable<CategoryPubDateQuantity> GetCategiesInformations();
        IEnumerable<Item> GetItemsForChangePagePresentation(int page, int itemsPerPage, string category);
        IEnumerable<Item> GetItemsForChooseCategoryPresentation(int itemsPerPage, string category);
        IEnumerable<ImageId> GetImageIdForCategory(string category);
        IQueryable<Item> GetItems { get; }
    }

}
