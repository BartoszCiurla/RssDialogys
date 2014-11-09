using System.Collections.Generic;
using System.Drawing;
using RssDialogys.Domain.Entities;

namespace RssDialogys.Domain.Abstract
{
    public interface IImageRepository
    {
        bool UploadAndSaveImage(string imageId, string url);
        Image DownloadImageFromUrl(string imageUrl);
        void InitializeGetImage();
        void SetFilesToFileInfos(int index, Item news);
        void SetRandomFilesToFileInfosForCategory(int index, IEnumerable<ImageId> imageId, int categoryQuantity);

        Image this[int index] { get; }
    }
}
