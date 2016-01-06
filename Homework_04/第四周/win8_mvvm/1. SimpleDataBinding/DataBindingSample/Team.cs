using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace DataBindingSample
{
    public class Team //Has a custom string indexer
    {
        Dictionary<string, object> _propBag;
        public Team()
        {
            _propBag = new Dictionary<string, object>();
        }

        public string Name { get; set; }
        public string City { get; set; }
        public SolidColorBrush Color { get; set; }
        public object this[string indexer]
        {
            get
            {
                return _propBag[indexer];
            }
            set
            {
                _propBag[indexer] = value;
            }
        }

    }
}
