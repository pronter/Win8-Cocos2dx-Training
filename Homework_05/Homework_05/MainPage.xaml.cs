using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.ShareTarget;
using Windows.UI.Core;
using Windows.ApplicationModel;                     // 获得本地安装文件时使用 Package  
using Windows.Storage;                              // StorageFile  
using Windows.Storage.Streams;
using Windows.Storage.Pickers;
using Windows.Graphics.Imaging;


// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Homework_05
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int index = 0;
        private string[] bg = { "ms-appx:///Assets/background1.jpg", "ms-appx:///Assets/background2.jpg", "ms-appx:///Assets/background3.jpg" };
     
        public MainPage()
        {
            DataTransferManager.GetForCurrentView().DataRequested += dtm_DataRequested;
            this.InitializeComponent();
            
        }

        private async void dtm_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            DataRequest request = args.Request;
            request.Data.Properties.Title = "Share StorageItems Example";
            request.Data.Properties.Description = "Demonstrates how to share files.";

            // Because we are making async calls in the DataRequested event handler,
            // we need to get the deferral first.
            DataRequestDeferral deferral = request.GetDeferral();

            // Make sure we always call Complete on the deferral.
            try
            {
                StorageFile logoFile =
                    await Package.Current.InstalledLocation.GetFileAsync("Assets\\Logo.png");
                List<IStorageItem> storageItems = new List<IStorageItem>();
                storageItems.Add(logoFile);
                request.Data.SetStorageItems(storageItems);
            }
            finally
            {
                deferral.Complete();
            }/*
            string FileTitle = "my title";
            string FileDescription = "this is the discription";
            DataPackage data = args.Request.Data;
            data.Properties.Title = FileTitle;
            data.Properties.Description = FileDescription;  
            data.SetText(FileDescription);
            var waiter = args.Request.GetDeferral();
            try
            {
                StorageFile image = await Package.Current.InstalledLocation.GetFileAsync("Assets\\un_select.jpg");
                data.Properties.Thumbnail = RandomAccessStreamReference.CreateFromFile(image);  //     获取或设置 DataPackage 的缩略图像。  
                data.SetBitmap(RandomAccessStreamReference.CreateFromFile(image));          //     设置 DataPackage 中包含的位图图像。  
                List<IStorageFile> files = new List<IStorageFile>();
                files.Add(image);
                data.SetStorageItems(files);

            }
            finally
            {
                waiter.Complete();
            } */
        }
        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem selectedItem = sender as MenuFlyoutItem;

            if (selectedItem != null)
            {
                if (selectedItem.Tag.ToString() == "first")
                {
                    var bg_brush = new ImageBrush { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/background1.jpg")) };
                    this.change_bg.Background = bg_brush;
                    index = 0;
                }
                else if (selectedItem.Tag.ToString() == "second")
                {
                    var bg_brush = new ImageBrush { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/background2.jpg")) };
                    this.change_bg.Background = bg_brush;
                    index = 1;
                }
                else if (selectedItem.Tag.ToString() == "third")
                {
                    var bg_brush = new ImageBrush { ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/background3.jpg")) };
                    this.change_bg.Background = bg_brush;
                    index = 3;
                }
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (index == 0)
                index = 2;
            else
                index--;
            var bg_brush = new ImageBrush { ImageSource = new BitmapImage(new Uri(bg[index])) };
            this.change_bg.Background = bg_brush;
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            if (index == 2)
                index = 0;
            else
                index++;
            var bg_brush = new ImageBrush { ImageSource = new BitmapImage(new Uri(bg[index])) };
            this.change_bg.Background = bg_brush;
        }

        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
           this.Frame.Navigate(typeof(Detail));
        }

        private void AppBarButton_Click_4(object sender, RoutedEventArgs e)
        {
            DataTransferManager.GetForCurrentView().DataRequested -= dtm_DataRequested;
            DataTransferManager.ShowShareUI();
        }

        private void AppBarButton_Click_5(object sender, RoutedEventArgs e)
        {

        }
    }
}
