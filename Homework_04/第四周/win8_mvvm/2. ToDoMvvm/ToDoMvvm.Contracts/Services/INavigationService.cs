using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ToDoMvvm.Contracts
{
    public interface INavigationService
    {
        void Navigate(string pageName);
        Frame Frame { get; set; }
    }
}
