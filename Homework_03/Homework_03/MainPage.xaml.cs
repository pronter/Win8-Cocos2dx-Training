using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
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

namespace Homework_03
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Picture> mylist;
        public Rect WindowsRect = Window.Current.Bounds;
        public MainPage()
        {
            Window.Current.SizeChanged += sizechanged;
            this.InitializeComponent();
            FView.Visibility = Visibility.Visible;
            GView.Visibility = Visibility.Collapsed;
            LView.Visibility = Visibility.Collapsed;
            List<Picture> peopleList = new List<Picture>()
            {
                new Picture("鸣人","Assets/鸣人.jpeg"),
                new Picture("佐助","Assets/佐助.jpg"),
                new Picture("小樱","Assets/小樱.jpg"),
                new Picture("水月","Assets/水月.jpg"),
                new Picture("李","Assets/李.jpg")
            };
            mylist = peopleList;
            this.GView.ItemsSource = mylist;
            this.LView.ItemsSource = mylist;
            this.FView.ItemsSource = mylist;
        }
            private void sizechanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs edge) {
                double width = edge.Size.Width;
                double heigh = edge.Size.Height;
                if (width <= heigh) {
                    background.Visibility = Visibility.Collapsed;
                    background_change.Visibility = Visibility.Visible;
                    FView.Visibility = Visibility.Collapsed;
                    GView.Visibility = Visibility.Collapsed;
                    LView.Visibility = Visibility.Visible;
                    GridView.Visibility = Visibility.Collapsed;
                    FlipView.Visibility = Visibility.Collapsed;
                    ListView.Visibility = Visibility.Collapsed;
                    LView.Margin = new Thickness(180,136,0,0);
                    LView.SelectedIndex = GView.SelectedIndex;
                } else {
                    background_change.Visibility = Visibility.Collapsed;
                    background.Visibility = Visibility.Visible;
                    FView.Visibility = Visibility.Collapsed;
                    GView.Visibility = Visibility.Visible;
                    LView.Visibility = Visibility.Collapsed;
                    GridView.Visibility = Visibility.Visible;
                    FlipView.Visibility = Visibility.Visible;
                    ListView.Visibility = Visibility.Visible;
                    LView.Margin = new Thickness(544, 136, 0, 0);
                }
                GView.SelectedIndex = LView.SelectedIndex;
            }

            private void GridView_Click(object sender, RoutedEventArgs e)
            {
                FView.Visibility = Visibility.Collapsed;
                GView.Visibility = Visibility.Visible;
                LView.Visibility = Visibility.Collapsed;
            }

            private void FlipView_Click(object sender, RoutedEventArgs e)
            {
                FView.Visibility = Visibility.Visible;
                GView.Visibility = Visibility.Collapsed;
                LView.Visibility = Visibility.Collapsed;
            }
            private void ListView_Click(object sender, RoutedEventArgs e)
            {
                FView.Visibility = Visibility.Collapsed;
                GView.Visibility = Visibility.Collapsed;
                LView.Visibility = Visibility.Visible;
            }

            private void GView_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            }

            private void LView_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            }
        }
}
