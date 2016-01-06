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
using week4Search.ViewModel;
using week4Search.Common;

namespace week4Search
{
    public sealed partial class MainPage
    {
        private NavigationHelper navi;
        private VModel vmodel;
        private Rect windowsRect = Window.Current.Bounds;

        public NavigationHelper Navi
        {
            get 
            {
                return navi;
            }
        }
        /// <summary>
        /// Gets the view's ViewModel.
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

            vmodel.MyList.Add(new book { Title = "C大学教程", ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/1.jpg")), Content = "面向过程、基于对象、面向对象以及泛型编程，内容全面、生动、易懂，由浅入深地介绍了结构化编程和软件工程的基本概念" });
            vmodel.MyList.Add(new book { Title = "数据结构与算法分析", ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/2.jpg")), Content = "书的内容包括表、栈、队列、树、散列表、优先队列、排序、不相交集算法、图论算法、算法分析、算法设计、摊还分析、查找树算法、k-d树和配对堆等。" });
            vmodel.MyList.Add(new book { Title = "数据库管理系统原理与设计", ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/3.jpg")), Content = "全书分为数据库基础，应用程序开发、存储与索引、查询评估、事务管理、数据库设计与调整、高级主题等七大部分" });
            vmodel.MyList.Add(new book { Title = "操作系统概念", ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/4.jpg")), Content = "系统性——覆盖计算机专业主干课程和非计算机专业计算机基础课程。" });
            vmodel.MyList.Add(new book { Title = "编译原理", ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/5.jpg")), Content = "内容包括语言和文法、词法分析、语法分析、语法制导翻译、中间代码生成、存储管理、代码优化和目标代码生成。 " });
            vmodel.MyList.Add(new book { Title = "计算机网络", ImagePath = new BitmapImage(new Uri("ms-appx:///" + "Assets/6.jpg")), Content = "从应用层协议开始沿协议栈向下讲解，强调应用层范例和应用编程接口" });

            //推送数据到UI
            gView.ItemsSource = vmodel.MyList;
            lView.ItemsSource = vmodel.MyList;

            vmodel.PropertyChanged += (sender, e1) =>
            {
                if (e1.PropertyName == "SelectedItemIndex")
                {
                    gView.SelectedIndex = vmodel.SelectedItemIndex;
                    lView.SelectedIndex = vmodel.SelectedItemIndex;
                }
            };
        }

        void searchPane_SuggestionsRequested(SearchPane sender, SearchPaneSuggestionsRequestedEventArgs args)
        {
            foreach (book temp in vmodel.MyList)
            {
              string MaybeRight = temp.Title;

            if (MaybeRight.StartsWith(args.QueryText, StringComparison.CurrentCultureIgnoreCase))
            {
              args.Request.SearchSuggestionCollection.AppendQuerySuggestion(MaybeRight);
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
                gView.Visibility = Visibility.Collapsed;
                lView.Visibility = Visibility.Visible;
            }
            else
            {
                gView.Visibility = Visibility.Visible;
                lView.Visibility = Visibility.Collapsed;
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