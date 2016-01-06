using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_04
{
    class VModel : INotifyPropertyChanged
    {
        //用一个动态数据集合来存储mylist
        private ObservableCollection<book> mylist;
        private int selectedItemIndex;
        public VModel()
        {
            mylist = new ObservableCollection<book>();
            selectedItemIndex = -1;
        }

        public int SelectedItemIndex
        {
            get
            {
                return selectedItemIndex;
            }
            set
            {
                selectedItemIndex = value;
                NotifyPropertyChanged("SelectedItemIndex");
            }
        }

        public ObservableCollection<book> MyList
        {
            get
            {
                return mylist;
            }
        }

        //注册事件 PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string str)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(str));
            }
        }
        // 实现Search功能
        public void Search(string searchTerm)
        {
            int selectedItemIndex = -1;
            for (int i = 0; i < mylist.Count; i++)
            {
                //从title里面匹配seachTerm
                if (mylist[i].Title.ToLower().Contains(searchTerm.ToLower()))
                {
                    selectedItemIndex = i;
                }
            }
            SelectedItemIndex = selectedItemIndex;
        }
    }
}
