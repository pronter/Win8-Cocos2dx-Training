using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoMVVM.Web.Services
{
    public class ToDoItem
    {
        public int ToDoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }

    }
}