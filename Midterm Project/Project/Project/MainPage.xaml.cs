using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.ShareTarget;
using Windows.ApplicationModel.Search;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.ApplicationModel;
using Windows.Storage;                            
using Windows.Storage.Streams;
using Windows.Storage.Pickers;
using Windows.Graphics.Imaging;
using Project.ViewModel;
using Project.Common;


namespace Project
{

    public class PopControl : ContentControl
    {
        Popup m_pop = null;
        public PopControl()
        {
            this.DefaultStyleKey = typeof(PopControl);
            // 弹出层的宽度等于窗口的宽度
            this.Width = Window.Current.Bounds.Width;
            // 弹出层的高度等于窗口的高度
            this.Height = Window.Current.Bounds.Height;
            this.HorizontalContentAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
            this.m_pop = new Popup();
            // 将当前控件作为Popup的Child
            this.m_pop.Child = this;
        }
        public TransitionCollection PopTransitions
        {
            get
            {
                if (m_pop.ChildTransitions == null)
                {
                    m_pop.ChildTransitions = new TransitionCollection();
                }
                return m_pop.ChildTransitions;
            }
        }
        /// <summary>
        /// 显示弹出层
        /// </summary>
        public virtual void ShowPop()
        {
            if (this.m_pop != null)
            {
                this.m_pop.IsOpen = true;
            }
        }
        /// <summary>
        /// 隐藏弹出层
        /// </summary>
        public virtual void HidePop()
        {
            if (this.m_pop != null)
            {
                this.m_pop.IsOpen = false;
            }
        }
    }

    public sealed partial class ULike : UserControl
    {
        PopControl _pc;
        public ULike(PopControl c)
        {
           this.InitializeComponent();
            _pc = c;
        }

        private void onClick(object sender, RoutedEventArgs e)
        {
            if (_pc != null)
            {
                _pc.HidePop();
            }
        }
    }

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
            //DataTransferManager.GetForCurrentView().DataRequested += dtm_DataRequested;
            Button1.Visibility = Visibility.Collapsed;
            Button2.Visibility = Visibility.Collapsed;
            Button3.Visibility = Visibility.Collapsed;
            Button4.Visibility = Visibility.Collapsed;
            Button5.Visibility = Visibility.Collapsed;
            Button6.Visibility = Visibility.Collapsed;
            Button7.Visibility = Visibility.Collapsed;
            Reset.Visibility = Visibility.Collapsed;
            GView.Visibility = Visibility.Collapsed;
            Introdution.Visibility = Visibility.Collapsed;
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
            //法师可用卡牌库-MyList
            vmodel.Group();
            //平民卡组-MyList1
            vmodel.Group1();
            //机械流速攻法-MyList2
            vmodel.Group2();
            //机械流中速法-MyList3
            vmodel.Group3();
            //蓝白随从控场-MyList4
            vmodel.Group4();
            //蓝白随从快攻-MyList5
            vmodel.Group5();
            //零件机械法师-MyList6
            vmodel.Group6();
            //亡语流奥秘法-MyList7
            vmodel.Group7();
            
            
            //推送数据到UI
            GView.ItemsSource = vmodel.MyList;
            vmodel.PropertyChanged += (sender, e1) =>
            {
                if (GView.SelectedItems != null) GView.SelectedItems.Clear();
                if (e1.PropertyName == "SelectedItemIndex")
                {
                    foreach (card temp in vmodel.MyList)
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            if (selected[i] == null) continue;
                            if (temp.Title.ToLower().Contains(selected[i].ToLower()))
                            {
                                 GView.SelectedItems.Add(temp);
                            }
                        }
                    }
                }
            };
        }

        void searchPane_SuggestionsRequested(SearchPane sender, SearchPaneSuggestionsRequestedEventArgs args)
        {
            selected = new string[9];
            int i = 0;
            foreach (card temp in vmodel.MyList)
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
            }
            else
            {
                GView.Visibility = Visibility.Visible;
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
        public class MainPageState
        {
            public DateTime LastVisit
            {
                get;
                set;
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            GView.ItemsSource = null;
            GView.ItemsSource = vmodel.MyList1;
            Introdution.Text = "平民基本卡牌：\r    平民基本卡牌是为初学者最容易收集卡牌为主，其中的基本牌均可在前期升级过程中系统赠送。\r    从中筛选出的30张基本卡牌，可以让初学者熟悉法师类卡牌的特性。";
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            GView.ItemsSource = null;
            GView.ItemsSource = vmodel.MyList2;
            Introdution.Text = "机械流速攻法：\r    思路是前期随从铺场速攻，各种机械相辅相成，中期靠法术可以控制场面达到伤害不断档，后期上安东尼依靠各种随从留下的零件来换几发火球结束战斗。";
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            GView.ItemsSource = null;
            GView.ItemsSource = vmodel.MyList3;
            Introdution.Text = "机械流中速法：\r    在前期早早建立起局面，利用自己的随从不断压制对手的血量，持续的往场面上放出越来越具有威胁性的随从。最后火球术以及寒冰箭拥有很强的爆发能力，经常能造成出乎对手意料之外的伤害。";
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            GView.ItemsSource = null;
            GView.ItemsSource = vmodel.MyList4;
            Introdution.Text = "蓝白随从控场法：\r    前期铺场，让对手来解我们的牌，以打脸为主，一旦前期让我们蹭到足够多的血，后期用法术斩杀就变得相对容易，2张冰锥和2张水元素使冰枪更加灵活，不再必须和寒冰箭捆绑使用，还可以利用冰锥在控场的同时解决对方的嘲讽怪。";
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            GView.ItemsSource = null;
            GView.ItemsSource = vmodel.MyList5;
            Introdution.Text = "蓝白随从速攻法：\r    中速打法，以随从站场优先，前4回合能够站住随从压制对手的话，取胜的机会就很大了。有随从站场的情况下，法师的AOE和解牌能够很轻松的帮助随从打出伤害。火球在此套牌从更多时候是用来糊脸。一般10回合左右结束战斗。";
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            GView.ItemsSource = null;
            GView.ItemsSource = vmodel.MyList6;
            Introdution.Text = "零件机械法师：\r    前期以机械压场体系为主，配合寒冰箭、烈焰轰炸等解牌，中期4费的地精炎术士则是其他所有职业的噩梦，后期以安东尼达斯为核心进行爆炸伤害输出。这样的法师在后期的爆发力不容小视。";
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            GView.ItemsSource = null;
            GView.ItemsSource = vmodel.MyList7;
            Introdution.Text = "亡语流奥秘法：\r   这套卡组大大加强了奥秘法在前期的作战能力，除了传统奥秘法必带的肯瑞托法师以及疯狂科学家。随机拖上奥秘的效果虽不如肯瑞托法师稳定，但是被解掉科学家的话不仅赚了卡差，而且赚了3点法力水晶。这个特效在前期影响非常明显。 ";
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            GView.ItemsSource = null;
            GView.ItemsSource = vmodel.MyList;
            Introdution.Text = "法师卡牌库：\r    法师可用卡牌共299张，其中包括法师限定牌36张，以及中立牌263张。\r    法师限定牌以法术类为主，搭配上不同的中立牌后可有多样打法。";
        }

        private void Method_Click(object sender, RoutedEventArgs e)
        {
            Introdution.Text = "法师卡牌库：\r    法师可用卡牌共299张，其中包括法师限定牌36张，以及中立牌263张。\r    法师限定牌以法术类为主，搭配上不同的中立牌后可有多样打法。";
            Button1.Visibility = Visibility.Visible;
            Button2.Visibility = Visibility.Visible;
            Button3.Visibility = Visibility.Visible;
            Button4.Visibility = Visibility.Visible;
            Button5.Visibility = Visibility.Visible;
            Button6.Visibility = Visibility.Visible;
            Button7.Visibility = Visibility.Visible;
            Reset.Visibility = Visibility.Visible;
            GView.Visibility = Visibility.Visible;
            Introdution.Visibility = Visibility.Visible;
            Method.Visibility = Visibility.Collapsed;
            fashi.Visibility = Visibility.Collapsed;
            fashipic.Visibility = Visibility.Collapsed;
            name.Visibility = Visibility.Collapsed;
            cardground.Visibility = Visibility.Collapsed;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Button1.Visibility = Visibility.Collapsed;
            Button2.Visibility = Visibility.Collapsed;
            Button3.Visibility = Visibility.Collapsed;
            Button4.Visibility = Visibility.Collapsed;
            Button5.Visibility = Visibility.Collapsed;
            Button6.Visibility = Visibility.Collapsed;
            Button7.Visibility = Visibility.Collapsed;
            Reset.Visibility = Visibility.Collapsed;
            GView.Visibility = Visibility.Collapsed;
            Introdution.Visibility = Visibility.Collapsed;
            Method.Visibility = Visibility.Visible;
            fashi.Visibility = Visibility.Visible;
            fashipic.Visibility = Visibility.Visible;
            name.Visibility = Visibility.Visible;
            cardground.Visibility = Visibility.Visible;
        }

        private void Like_Click(object sender, RoutedEventArgs e)
        {
            PopControl pc = new PopControl();
            ULike uc = new ULike(pc);
            pc.Content = uc;
            pc.ShowPop();
        }
        private void DisLike_Click(object sender, RoutedEventArgs e)
        {
            PopControl pc = new PopControl();
            ULike uc= new ULike(pc);
            pc.Content = uc;
            pc.ShowPop();
        }
        private async void About_Click(object sender, RoutedEventArgs e)
        {
            var mes = new MessageDialog("About us");
            mes.Content = "技术人员:　庄梓嘉、庄汉权、周腾\r\r资料仅供参考\r\r@2015 Win8 Midterm Project";
            mes.Title = "About Us";
            await mes.ShowAsync();
        }

        private void Share_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.GetForCurrentView().DataRequested -= dtm_DataRequested;
            DataTransferManager.ShowShareUI();
        }
        private async void dtm_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            DataRequest request = args.Request;
            request.Data.Properties.Title = "Share StorageItems Example";
            request.Data.Properties.Description = "Demonstrates how to share files.";
            DataRequestDeferral deferral = request.GetDeferral();
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
            }
        }
    }
}