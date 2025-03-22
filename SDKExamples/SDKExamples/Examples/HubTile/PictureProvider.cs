using System;
using Telerik.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

namespace SDKExamples.HubTile
{
    public class PictureProvider : IImageSourceProvider
    {
        private string AbsolutePath = "ms-appx:///Images/";

        public ImageSource GetImageSource(object parameter)
        {
            return new BitmapImage(new Uri(this.AbsolutePath + (parameter as PicturePath).PictureName, UriKind.Absolute));
        }
    }

    public class PicturePath
    {
        public string PictureName { get; set; }
    }
}
