using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RssDialogys.Domain.Abstract;
using RssDialogys.Domain.Entities;
using Moq;

namespace RssDialogys.Domain.Unit.Tests
{
    [TestFixture]
    public class FeedDataRepository
    {
        [Test]  //tragiczny czas testu 123 ms dramat to sa raczej testy integracyjne a nie unitowe ..
        public void Get_Categories_Information_PubDate_Quantity_Name_For_Group_Category()
        {
            var mock = new Mock<IFeedDataRepository>();
            mock.Setup(m => m.GetCategiesInformations()).Returns(new[]
            {
                new Item {Category = "Sport", PublishDate = DateTime.Now.AddHours(1)},
                new Item {Category = "Sport", PublishDate = DateTime.Now.AddHours(2)},
                new Item {Category = "Kultura", PublishDate = DateTime.Now.AddHours(3)},
                new Item {Category = "Muzyka", PublishDate = DateTime.Now.AddHours(4)},
                new Item {Category = "Facet", PublishDate = DateTime.Now.AddHours(4)},
                new Item {Category = "Sport", PublishDate = DateTime.Now.AddHours(4)},
                new Item {Category = "Muzyka", PublishDate = DateTime.Now.AddHours(4)},
                new Item {Category = "Kultura", PublishDate = DateTime.Now.AddHours(4)},
                new Item {Category = "Facet", PublishDate = DateTime.Now.AddHours(4)},
                new Item {Category = "Muzyka", PublishDate = DateTime.Now.AddHours(4)}
            }.GroupBy(c => c.Category)
                .Select(
                    x =>
                        new CategoryPubDateQuantity
                        {
                            Category = x.Key,
                            PubDate = x.Max(c => c.PublishDate),
                            Quantity = x.Distinct().Count()
                        }).OrderByDescending(x => x.Quantity));

            var result = mock.Object;
            List<CategoryPubDateQuantity> allinOne = result.GetCategiesInformations().ToList();

            //quantity of categories
            Assert.AreEqual(4, allinOne.Count);    
            //quantity for category
            Assert.AreEqual(3, allinOne[0].Quantity);
            //pubDate for the most category count item , i'm taking max date 
            Assert.AreEqual(DateTime.Now.AddHours(4).ToShortDateString(), allinOne[0].PubDate.ToShortDateString());
        }

        [Test]
        [TestCase(4,1,4,"Gry")]
        [TestCase(3, 4, 4, "Gry")]
        [TestCase(0,1,3,"Muzyka")]
        [TestCase(0,2,1,"Inne")]
        public void Get_Items_For_Chage_Page_Presentation(int resulToComare,int page, int itemsPerPage, string category)
        {
            var mock = new Mock<IFeedDataRepository>();
            mock.Setup(m => m.GetItemsForChangePagePresentation(page,itemsPerPage,category)).Returns(new []
            {
                new Item {Category = "Gry"},
                new Item {Category = "Gry"},
                new Item {Category = "Gry"},
                new Item {Category = "Gry"},
                new Item {Category = "Gry"},
                new Item {Category = "Gry"},
                new Item {Category = "Gry"},
                new Item {Category = "Gry"},
                new Item {Category = "Gry"},
                new Item {Category = "Gry"},
                new Item {Category = "Gry"},
                new Item {Category = "Gry"},
                new Item {Category = "Gry"},
                new Item {Category = "Gry"},
                new Item {Category = "Gry"},
                new Item {Category = "Inne"}
            }.OrderByDescending(x => x.PublishDate)
                .Where(x => x.Category == category)
                .Skip((page - 1)*itemsPerPage)
                .Take(itemsPerPage).ToList());
            //nie wiem czy tak to się powinno robić 
            var result = mock.Object.GetItemsForChangePagePresentation(page, itemsPerPage, category);
            Assert.AreEqual(resulToComare, result.Count());
        }      

    }
}
