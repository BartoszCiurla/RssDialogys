using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using RssDialogys.Domain.Abstract;
using RssDialogys.Domain.Entities;
using NLog;

namespace RssDialogys.Domain.Concrete
{
    public class ImageRepository:IImageRepository
    {
        private DirectoryInfo _dirInfo;
        private FileInfo[] _feedImageFileInfos;
       
        public void InitializeGetImage()
        {
            _dirInfo = new DirectoryInfo(@".\..\\..\..\RssDialogys.Domain\RssImages");
            _feedImageFileInfos = new FileInfo[16];
            NlogEngine.logger.Trace("RssDialogs.Domain.Concrete.ImageRepository.InitializeGetImage");
        }
        public void SetFilesToFileInfos(int index,Item news)
        {
            _feedImageFileInfos[index] = _dirInfo.GetFiles(news.ImageId + ".jpg").SingleOrDefault();
            NlogEngine.logger.Trace("RssDialogs.Domain.Concrete.ImageRepository.SetFilesToFileInfos index{0} imageId{1}", index, news.ImageId);
        }

        public Image this[int index]
        {
            get { return Image.FromFile(_feedImageFileInfos[index].FullName); }
        }

        public void SetRandomFilesToFileInfosForCategory(int index,IEnumerable<ImageId> imageId, int categoryQuantity)
        {
            var rnd = new Random();
            _feedImageFileInfos[index] =
                _dirInfo.GetFiles(imageId.ElementAt(rnd.Next(categoryQuantity)).Id + ".jpg").SingleOrDefault();
            NlogEngine.logger.Trace("RssDialogs.Domain.Concrete.ImageRepository.SetRandomFilesToFileInfosForCategory index{0} categoryQuantity{1}", index, categoryQuantity);
        }

        public bool UploadAndSaveImage(string imageId, string url)
        {
            if (url != "")
            {
                try
                {
                    Image image = DownloadImageFromUrl(url);
                    string rootPath = @".\..\\..\..\RssDialogys.Domain\RssImages";
                    string fileName = Path.Combine(rootPath, imageId + ".jpg");
                    image.Save(fileName);
                    NlogEngine.logger.Trace("RssDialogs.Domain.Concrete.ImageRepository.UploadAndSaveImage imageID{0} url{1}", imageId, url);
                    return true;
                }
                catch
                {
                    NlogEngine.logger.Fatal("RssDialogs.Domain.Concrete.ImageRepository.UploadAndSaveImage imageId{0} url{1}", imageId, url);
                    return false;
                }
            }
            return false;
        }
        public Image DownloadImageFromUrl(string imageUrl)
        {
            Image image = null;
            try
            {
                System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                System.Net.WebResponse webResponse = webRequest.GetResponse();
                Stream stream = webResponse.GetResponseStream();
                if (stream != null) image = Image.FromStream(stream);
                webResponse.Close();
            }
            catch
            {
                return null;
            }

            return image;
        }
    }
}
