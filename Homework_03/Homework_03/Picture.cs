using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_03
{
    public class Picture
    {
        public string name { get; set; }
        public string src { get; set; }
        public Picture(string p1, string p2)
        {
            this.name = p1;
            this.src = p2;
        }
    }
}
