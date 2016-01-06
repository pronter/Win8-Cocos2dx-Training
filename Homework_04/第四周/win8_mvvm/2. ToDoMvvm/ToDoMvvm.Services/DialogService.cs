using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMvvm.Contracts;
using Windows.UI.Popups;

namespace ToDoMvvm.Services
{
    public class DialogService: IDialogService
    {
        public async void ShowDialog(string message)
        {
            MessageDialog messageDialog = new MessageDialog(message);
            await messageDialog.ShowAsync();
        }

        public async void ShowDeleteConfirmation()
        {
            MessageDialog messageDialog = new MessageDialog("The item has been deleted");
            await messageDialog.ShowAsync();
        }
    }
}
