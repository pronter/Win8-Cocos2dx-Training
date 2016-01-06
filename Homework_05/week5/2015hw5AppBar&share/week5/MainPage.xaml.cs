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
using Windows.ApplicationModel.DataTransfer;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace week5
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataTransferManager.GetForCurrentView().DataRequested += MainPage_DataRequested;
        }
        private void Forward(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(page2));
        }
        private void Previous(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(page2));
        }
        void MainPage_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            var defl = args.Request.GetDeferral();
            // 设置数据包
            DataPackage dp = new DataPackage();
            dp.Properties.Title = "共享文本";
            dp.Properties.Description = "分享一些内容。";
            dp.SetText(text.Text);
            args.Request.Data = dp;
            // 报告操作完成
            defl.Complete();
        }
        private void share_click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }
        private void dragEnter(object sender, RoutedEventArgs e)
        {
            if (text.Text == "Share here!")
            text.Text = "";
        }
    }
}
