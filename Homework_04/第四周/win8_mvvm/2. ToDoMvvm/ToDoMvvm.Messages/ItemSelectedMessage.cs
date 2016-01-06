using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMvvm.ServiceClient.ToDoService;

namespace ToDoMvvm.Messages
{
    public class ItemSelectedMessage
    {
        public ToDoItem Item { get; set; }

    }
}
