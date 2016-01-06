using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMvvm.Contracts
{
    public interface IShareService
    {
        string ShareData { get; set; }
        void Initialize();
    }
}
