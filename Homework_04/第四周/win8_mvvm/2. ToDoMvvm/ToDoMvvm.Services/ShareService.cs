using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMvvm.Contracts;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;

namespace ToDoMvvm.Services
{
    public class ShareService : IShareService
    {
        public string ShareData { get; set; }

        public ShareService()
        {
            
        }

        public void Initialize()
        {
            DataTransferManager dataTransferManager;
            dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested -= this.DataRequested;
            dataTransferManager.DataRequested += this.DataRequested;
        }

        private void DataRequested(DataTransferManager sender, DataRequestedEventArgs e)
        {
            e.Request.Data.Properties.Title = "ToDo item";
            e.Request.Data.Properties.Description = "This is data from the ToDo app";
            e.Request.Data.SetText(ShareData ?? string.Empty);
        }
    }
}
