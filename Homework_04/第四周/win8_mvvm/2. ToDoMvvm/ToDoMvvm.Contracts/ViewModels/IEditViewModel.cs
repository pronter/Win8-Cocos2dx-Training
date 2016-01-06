using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMvvm.ServiceClient.ToDoService;

namespace ToDoMvvm.Contracts
{
    public interface IEditViewModel: IViewModel
    {
        ToDoItem SelectedToDoItem { get; set; }
    }
}
