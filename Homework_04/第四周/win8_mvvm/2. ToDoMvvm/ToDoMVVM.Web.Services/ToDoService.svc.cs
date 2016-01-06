using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ToDoMVVM.Web.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ToDoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ToDoService.svc or ToDoService.svc.cs at the Solution Explorer and start debugging.
    public class ToDoService : IToDoService
    {
        public List<ToDoItem> GetAllToDos()
        { 
            return ToDoRepository.GetInstance().ToDoItems; 
        }

        public ToDoItem GetToDoItemById(int id)
        {
            return ToDoRepository.GetInstance().ToDoItems.Where(t => t.ToDoId == id).FirstOrDefault();
        }


        public void DeleteToDoItemById(int id)
        {
            var item = ToDoRepository.GetInstance().ToDoItems.Where(t => t.ToDoId == id).FirstOrDefault();
            ToDoRepository.GetInstance().ToDoItems.Remove(item);
        }
    }
}
