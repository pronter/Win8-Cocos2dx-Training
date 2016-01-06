using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_05
{
    class Picture
    {
        public string name { get; set; }

        public string src { get; set; }

        public Picture(string p1, string p2)
        {
            // TODO: Complete member initialization
            this.name = p1;
            this.src = p2;
        }
    }
}
