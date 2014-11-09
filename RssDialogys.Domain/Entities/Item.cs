using System;

namespace RssDialogys.Domain.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Href { get; set; }
        public string ImageId { get; set; }
        public string Category { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UploadDate { get; set; }
        public Item()
        {
            Href = "";
            Link = "";
            Title = "";
            Content = "";
            PublishDate = DateTime.Today;
            UploadDate = DateTime.Now;
        }
    }
}
