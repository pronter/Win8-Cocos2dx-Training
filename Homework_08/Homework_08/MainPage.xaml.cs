using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using Windows.Media.Capture;


// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Homework_08
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var camera = new CameraCaptureUI();
            camera.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Png;
            var file = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (file != null)
            {
                ImageSource src = new BitmapImage(new Uri(file.Path));
                photo.Source = src;
            }
        }
        private async void Button_Click1(object sender, RoutedEventArgs e)
        {
            var camera = new CameraCaptureUI();
            camera.VideoSettings.Format = CameraCaptureUIVideoFormat.Wmv;
            var file = await camera.CaptureFileAsync(CameraCaptureUIMode.Video);
            if (file != null)
            {
            }
        }
    }
}
