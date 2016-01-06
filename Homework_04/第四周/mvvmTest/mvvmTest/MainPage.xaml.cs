using System;
using mvvmTest.ViewModel;
using mvvmTest.Model;
using System.ComponentModel;
namespace mvvmTest
{
    public sealed partial class MainPage
    {
        public student_viewmodel sv;
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
            
        }
       
        protected override void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            sv = new student_viewmodel();
            sv.PropertyChanged += (object sender,PropertyChangedEventArgs e1) =>
            {
                if (e1.PropertyName == "name")
                {
                    show.Content = sv.getName();
                }
            };

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

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            sv.setStudentName(input.Text);
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