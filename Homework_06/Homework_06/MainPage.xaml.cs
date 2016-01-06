using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Homework_06
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
            ///创建一个WriteableBitmap对象，它的作用是提供了一个可写入并更新的BitmapSource
            WriteableBitmap writeAbleBitmap = new WriteableBitmap(172, 129);
            ///创建一个FileOpenPicker对象
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".bmp");
            ///file被创建来保存我们选择的图片
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                ///以只读的方式打开选定的文件
                IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read);
                ///通过访问流来设置源图像
                await writeAbleBitmap.SetSourceAsync(stream);
                picture.Source = writeAbleBitmap;
            }
        }
    }
}
