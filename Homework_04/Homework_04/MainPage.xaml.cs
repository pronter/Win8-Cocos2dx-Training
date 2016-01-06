using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Search;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Homework_04.ViewModel;
using Homework_04.Common;

namespace Homework_04
{
    public sealed partial class MainPage
    {
        private NavigationHelper navi;
        private VModel vmodel;
        private Rect windowsRect = Window.Current.Bounds;
        private string[] selected = new string[9];

        public NavigationHelper Navi
        {
            get
            {
                return navi;
            }
        }
        /// <summary>
        /// Gets the View's ViewModel.
        /// </summary>
        public MainViewModel Vm
        {
            get
            {
                return (MainViewModel)DataContext;
            }
        }

        public MainPage()
        {
            InitializeComponent();
            this.navi = new NavigationHelper(this);
            this.navi.LoadState += navi_LoadState;
            this.navi.SaveState += navi_SaveState;
            SearchPane.GetForCurrentView().SuggestionsRequested += searchPane_SuggestionsRequested;
            Window.Current.SizeChanged += OnsizeChanged;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //由App.xaml.cs导航过来后提供数据
            navi.OnNavigatedTo(e);
            vmodel = (VModel)e.Parameter;
            vmodel.MyList.Add(new book { Title = "百年孤独", ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/百年孤独.jpg")), Content = "布恩迪亚家族七代人的传奇故事，加勒比海沿岸小镇马孔多的百年兴衰。" });
            vmodel.MyList.Add(new book { Title = "岛", ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/岛.jpg")), Content = "一座绝望的岛， 一座永远没有返还之路的岛,属于伟大而又平凡的人们的时代。" });
            vmodel.MyList.Add(new book { Title = "麦田里的守望者", ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/麦田里的守望者.jpg")), Content = "16岁的中学生霍尔顿·考尔菲德从离开学校到纽约游荡的三天经历。" });
            vmodel.MyList.Add(new book { Title = "牧羊少年奇幻之旅", ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/牧羊少年奇幻之旅.jpg")), Content = "一个过着平淡日子牧羊少年圣地亚哥，做了两次关于宝藏的梦前往埃及寻宝的经历。" });
            vmodel.MyList.Add(new book { Title = "我的孤独是一座花园", ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/我的孤独是一座花园.jpg")), Content = "世界诗坛的叙利亚诗人阿多尼斯的第一部中文版诗集。" });
            vmodel.MyList.Add(new book { Title = "在路上", ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/在路上.jpg")), Content = "凯鲁亚克和他的朋友们试图用一些新意的眼光来看世界，寻找令人信服的价值。" });
            vmodel.MyList.Add(new book { Title = "山河经", ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/山河经.jpg")), Content = "一部记载中国古代国神话、地理、动植物、物产、巫术、宗教、医药、民俗的著作。" });
            vmodel.MyList.Add(new book { Title = "山河之书", ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/山河之书.jpg")), Content = "余秋雨教授二十余年考察中国文化现场的脚印,从宏观上通述了中国山河的空间意义。" });
            //推送数据到UI
            GView.ItemsSource = vmodel.MyList;
            LView.ItemsSource = vmodel.MyList;
            vmodel.PropertyChanged += (sender, e1) =>
            {
                if (GView.SelectedItems != null) GView.SelectedItems.Clear();
                if (e1.PropertyName == "SelectedItemIndex")
                {
              //GView.SelectedIndex = vmodel.SelectedItemIndex;
                    foreach (book temp in vmodel.MyList)
                    {
                       for (int i = 0; i < 9; i++) {
                            if (selected[i] == null) continue;
                            if (temp.Title.ToLower().Contains(selected[i].ToLower())) {
                                GView.SelectedItems.Add(temp);
                            }
                        }
                        //GView.SelectedItems.Add(temp);
                    }
                    LView.SelectedIndex = vmodel.SelectedItemIndex;
                }
            };
        }

        void searchPane_SuggestionsRequested(SearchPane sender, SearchPaneSuggestionsRequestedEventArgs args)
        {
            selected = new string[9];
            int i = 0;
            foreach (book temp in vmodel.MyList)
            {
                string MaybeRight = temp.Title;

                if (MaybeRight.StartsWith(args.QueryText, StringComparison.CurrentCultureIgnoreCase))
                {
                    args.Request.SearchSuggestionCollection.AppendQuerySuggestion(MaybeRight);
                    selected[i] = MaybeRight;
                    i++;
                }
                if (args.Request.SearchSuggestionCollection.Size > 5)
                {
                    break;
                }
            }
        }
        private void navi_LoadState(object sender, LoadStateEventArgs e)
        {
        }
        private void navi_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        private void OnsizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            double AppWidth = e.Size.Width;
            double AppHeight = e.Size.Height;
            if (AppWidth <= windowsRect.Width / 2)
            {
                GView.Visibility = Visibility.Collapsed;
                LView.Visibility = Visibility.Visible;
            }
            else
            {
                GView.Visibility = Visibility.Visible;
                LView.Visibility = Visibility.Collapsed;
            }
        }


        protected override void LoadState(object state)
        {
            var casted = state as MainPageState;

            if (casted != null)
            {
                Vm.Load(casted.LastVisit);
            }
        }

        protected override object SaveState()
        {
            return new MainPageState
            {
                LastVisit = DateTime.Now
            };
        }
    }
    public class MainPageState
    {
        public DateTime LastVisit
        {
            get;
            set;
        }
    }
}