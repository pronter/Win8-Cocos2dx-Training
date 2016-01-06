using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingSample
{
    public class Person
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }          
        
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }          
        
        public Person() 
        {
        }
        
        public Person(string name, string adr)
        {
            Name = name;
            Address = adr;
        }

        public override string ToString() { return Name + ", " + Address; }
    }
}
