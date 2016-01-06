using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMvvm.Contracts;
using Windows.UI.Xaml.Controls;

namespace ToDoMvvm.Services
{
    public class NavigationService: INavigationService
    {
        private Frame frame;

        public Frame Frame
        {
            get
            {
                return frame;
            }
            set
            {
                frame = value;
                frame.Navigated += OnFrameNavigated;
            }
        }

        private void OnFrameNavigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            var view = e.Content as IView;
            var viewModel = view.ViewModel;
            viewModel.Initialize();
            
        }

        public void Navigate(string pageName)
        {
            switch (pageName)
            {

                case "MainPage":
                    var mainPageType = SimpleIoc.Default.GetInstance<IMainPage>();
                    Frame.Navigate(mainPageType.GetType());
                    break;
                case "EditPage": var editPageType = SimpleIoc.Default.GetInstance<IEditPage>();
                    Frame.Navigate(editPageType.GetType());
                    break;
                default: 
                    var defaultPageType = SimpleIoc.Default.GetInstance<IMainPage>();
                    Frame.Navigate(defaultPageType.GetType());
                    break;
            }
        }
    }
}
