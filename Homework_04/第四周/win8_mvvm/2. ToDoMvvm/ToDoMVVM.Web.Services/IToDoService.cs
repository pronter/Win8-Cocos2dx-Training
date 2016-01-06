using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ToDoMVVM.Web.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IToDoService" in both code and config file together.
    [ServiceContract]
    public interface IToDoService
    {
        [OperationContract]
        List<ToDoItem> GetAllToDos();

        [OperationContract]
        ToDoItem GetToDoItemById(int id);

        [OperationContract]
        void DeleteToDoItemById(int id);
    }
}
