using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mvvmTest.Model;
using System.ComponentModel;
using Windows.UI.Popups;
namespace mvvmTest.ViewModel
{
   public class student_viewmodel : INotifyPropertyChanged
    {  
        private student st;
        public void setStudentName(string name){
            st.name = name;
            INotifyPropertyChanged("name");
        }
        public string getName()
        {
            return st.name;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void INotifyPropertyChanged(string str)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(str));
            }
        }
        public student_viewmodel()
        {
            st = new student();
            PropertyChanged += async (object sender, PropertyChangedEventArgs e1) =>
            {
                if (e1.PropertyName == "name")
                {
                    MessageDialog dia = new MessageDialog(st.Name);
                    await Task.Delay(3000);
                    await dia.ShowAsync();
                }
            };
        }
    }
}
