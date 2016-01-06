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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Homework_05
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Detail : Page
    {
        List<Picture> mylist;
        public Detail()
        {
            this.InitializeComponent();
            List<Picture> clothList = new List<Picture>()
            {
                new Picture("百年孤独","Assets/百年孤独.jpg"),
                new Picture("岛","Assets/岛.jpg"),
                new Picture("麦田里的守望者","Assets/麦田里的守望者.jpg"),
                new Picture("牧羊少年奇幻之旅","Assets/牧羊少年奇幻之旅.jpg"),
                new Picture("山河经","Assets/山河经.jpg"),
                new Picture("山河之书","Assets/山河之书.jpg"),
                new Picture("我的孤独是一座花园","Assets/我的孤独是一座花园.jpg"),
            };
            mylist = clothList;
            this.mygridview.ItemsSource = mylist;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
