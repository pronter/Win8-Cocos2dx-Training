using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Project
{
    class card : INotifyPropertyChanged
    {
        private BitmapImage imagePath;
        public BitmapImage ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                if (value == imagePath)
                    return;
                imagePath = value;
                //调用NotifyPropertyChanged事件。
                NotifyPropertyChanged("ImagePath");
            }
        }
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value == title)
                    return;
                title = value;
                NotifyPropertyChanged("Title");
            }
        }

        private string content;
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                if (value == content)
                    return;
                content = value;
                NotifyPropertyChanged("Content");
            }
        }
        #region 属性变化事件
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string SomeString)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(SomeString));
            }
        }
        #endregion
    }
}
