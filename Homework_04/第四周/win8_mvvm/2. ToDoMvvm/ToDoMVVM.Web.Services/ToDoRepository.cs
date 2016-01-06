using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoMVVM.Web.Services
{
    public class ToDoRepository
    {
        private static ToDoRepository instance;
        private static List<ToDoItem> toDoItems;

        public static ToDoRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new ToDoRepository();
            }
            return instance;
        }

        protected ToDoRepository()
        {
            InitializeList();
        }

        private void InitializeList()
        {
            toDoItems = new List<ToDoItem>();
            var toDoItem1 = new ToDoItem() { ToDoId = 1, Title = "Create webinar demos", Description = "Finish demo material of MVVM webinar", Priority = 1, DueDate = new DateTime(2012, 10, 10), Category = "Personal" };
            var toDoItem2 = new ToDoItem() { ToDoId = 2, Title = "abcd", Description = "Finish demo material of MVVM webinar", Priority = 1, DueDate = new DateTime(2012, 10, 10), Category = "Personal" };
            var toDoItem3 = new ToDoItem() { ToDoId = 3, Title = "dfgv", Description = "Finish demo material of MVVM webinar", Priority = 1, DueDate = new DateTime(2012, 10, 10), Category = "Personal" };
            var toDoItem4 = new ToDoItem() { ToDoId = 4, Title = "rtyj", Description = "Finish demo material of MVVM webinar", Priority = 1, DueDate = new DateTime(2012, 10, 10), Category = "Personal" };
            var toDoItem5 = new ToDoItem() { ToDoId = 5, Title = "ffss", Description = "Finish demo material of MVVM webinar", Priority = 1, DueDate = new DateTime(2012, 10, 10), Category = "Personal" };
            toDoItems.Add(toDoItem1);
            toDoItems.Add(toDoItem2);
            toDoItems.Add(toDoItem3);
            toDoItems.Add(toDoItem4);
            toDoItems.Add(toDoItem5);
        }

        public List<ToDoItem> ToDoItems
        {
            get
            {
                return toDoItems;
            }
            set
            {
                toDoItems = value;
            }
        }

    }
}