using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMvvm.Contracts;
using ToDoMvvm.Messages;
using ToDoMvvm.ServiceClient.ToDoService;

namespace ToDoMvvm.ViewModels
{
    public class EditViewModel : ViewModelBase, IEditViewModel
    {
        private ToDoItem selectedToDoItem;

        public RelayCommand GoBackCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        public ToDoItem SelectedToDoItem
        {
            get
            {
                return selectedToDoItem;
            }
            set
            {
                selectedToDoItem = value;
                SimpleIoc.Default.GetInstance<IShareService>().ShareData = selectedToDoItem.Title;

            }
        }


        public EditViewModel()
        {
            InitializeCommands();
            InitializeMessenger();
        }

        public void Initialize()
        {
            SimpleIoc.Default.GetInstance<IShareService>().Initialize();
        }



        private void InitializeCommands()
        {
            GoBackCommand = new RelayCommand(() =>
            {
                SimpleIoc.Default.GetInstance<INavigationService>().Navigate("MainPage");
            });
            DeleteCommand = new RelayCommand(() =>
                {
                    SimpleIoc.Default.GetInstance<IToDoDataService>().DeleteItemById(SelectedToDoItem.ToDoId);
                    Messenger.Default.Send<ReloadToDoItemsMessage>(new ReloadToDoItemsMessage() { Reload = true });
                    SimpleIoc.Default.GetInstance<IDialogService>().ShowDeleteConfirmation();
                    SimpleIoc.Default.GetInstance<INavigationService>().Navigate("MainPage");
                });
        }

        private void InitializeMessenger()
        {
            Messenger.Default.Register<ItemSelectedMessage>(this, OnItemSelectedMessageReceived);
        }

        private void OnItemSelectedMessageReceived(ItemSelectedMessage itemSelectedMessage)
        {
            SelectedToDoItem = itemSelectedMessage.Item;
        }
    }
}
