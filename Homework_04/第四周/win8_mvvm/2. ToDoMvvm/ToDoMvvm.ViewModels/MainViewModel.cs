using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMvvm.Contracts;
using ToDoMvvm.Messages;
using ToDoMvvm.ServiceClient.ToDoService;

namespace ToDoMvvm.ViewModels
{
    public class MainViewModel: ViewModelBase, IMainViewModel
    {
        private IToDoDataService toDoDataService;
        private INavigationService navigationService;
        public RelayCommand<ToDoItem> ItemClickCommand { get; set; }

        private string title;

        public string Title
        {
            get { return title; }
            set { 
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        private ToDoItem selectedToDo;

        public ToDoItem SelectedToDo 
        {
            get
            {
                return selectedToDo;
            }
            set
            {
                selectedToDo = value;
                RaisePropertyChanged("SelectedToDo");
            }
        }

        private ObservableCollection<ToDoItem> todoItems;

        public ObservableCollection<ToDoItem> ToDoItems 
        {
            get
            {
                return todoItems;
            }
            set
            {
                todoItems = value;
                RaisePropertyChanged("ToDoItems");
            }
        }

        public MainViewModel()
        {
            Title = "Hello world";
            toDoDataService = SimpleIoc.Default.GetInstance<IToDoDataService>();
            navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            InitializeCommands();
            InitializeMessenger();
            LoadAllToDos();
        }

        public void Initialize()
        {

        }

        private void InitializeMessenger()
        {
            Messenger.Default.Register<ReloadToDoItemsMessage>(this, OnReloadToDoItemsMessageReceived);
        }

        private void InitializeCommands()
        {
            ItemClickCommand = new RelayCommand<ToDoItem>((item) =>
            {
                Messenger.Default.Send<ItemSelectedMessage>(new ItemSelectedMessage() { Item = SelectedToDo });
                navigationService.Navigate("EditPage");
            });
        }

        private void OnReloadToDoItemsMessageReceived(ReloadToDoItemsMessage reloadToDoItemsMessage)
        {
            SelectedToDo = null;
            LoadAllToDos();
        }

        public async void LoadAllToDos()
        {
            ToDoItems = await toDoDataService.GetAllToDoItems();
        }
    }
}
