/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ToDoMvvm"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ToDoMvvm.Contracts;
using ToDoMvvm.Services;
using ToDoMvvm.ViewModels;

namespace ToDoMvvm
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IToDoDataService, ToDoDataService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IShareService, ShareService>();
            SimpleIoc.Default.Register<IMainPage, MainPage>();
            SimpleIoc.Default.Register<IEditPage, EditPage>();
            SimpleIoc.Default.Register<IMainViewModel, MainViewModel>(true);
            SimpleIoc.Default.Register<IEditViewModel, EditViewModel>(true);
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IMainViewModel>() as MainViewModel;
            }
        }

        public EditViewModel EditViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IEditViewModel>() as EditViewModel;
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}