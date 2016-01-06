using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingSample
{
    public class ChangeablePerson: INotifyPropertyChanged
    {
       
            public event PropertyChangedEventHandler PropertyChanged;
            private string name;
            public string Name
            {
                get { return name; }
                set 
                { 
                    name = value; 
                    NotifyPropertyChanged("Name"); 
                }
            }

            private string address;
            public string Address
            {
                get { return address; }
                set 
                { 
                    address = value; 
                    NotifyPropertyChanged("Address"); 
                }
            }

            public ChangeablePerson() { }
            public ChangeablePerson(string name, string adr)
            {
                Name = name;
                Address = adr;
            }

            public override string ToString()
            {
                return Name + ", " + Address;
            }

            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        
    }
}
