using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMvvm.ServiceClient.ToDoService;

namespace ToDoMvvm.Contracts
{
    public interface IToDoDataService
    {
        Task<ObservableCollection<ToDoItem>> GetAllToDoItems();
        Task<ToDoItem> GetToDoItemById(int id);
        void DeleteItemById(int id);
    }
}
