using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace mvvmTest.Model
{
    class student
    {
        public string name;
        public string Name
        {
            set { 
                name = value;
            }
            get { return name;
            
            }
        }
    }
}
