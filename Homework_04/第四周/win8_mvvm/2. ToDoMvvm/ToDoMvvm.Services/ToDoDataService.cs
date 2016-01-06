using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMvvm.Contracts;
using ToDoMvvm.ServiceClient.ToDoService;

namespace ToDoMvvm.Services
{
    public class ToDoDataService : IToDoDataService
    {
        public async Task<ObservableCollection<ToDoItem>> GetAllToDoItems()
        {
            ToDoServiceClient client = new ToDoServiceClient();
            var result= await client.GetAllToDosAsync();
            return result;
        }

        public async Task<ToDoItem> GetToDoItemById(int id)
        {
            ToDoServiceClient client = new ToDoServiceClient();
            var result = await client.GetToDoItemByIdAsync(id);
            return result;
        }

        public async void DeleteItemById(int id)
        {
            ToDoServiceClient client = new ToDoServiceClient();
            await client.DeleteToDoItemByIdAsync(id);
        }
    }
}
