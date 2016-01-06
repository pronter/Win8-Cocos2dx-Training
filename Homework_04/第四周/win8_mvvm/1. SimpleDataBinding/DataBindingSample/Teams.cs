using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace DataBindingSample
{
    public class Teams : List<Team>
    {
        public Teams()
        {
            Add(new Team() { Name = "The Reds", City = "Liverpool", Color = new SolidColorBrush(Colors.Green) });
            Add(new Team() { Name = "The Red Devils", City = "Manchester", Color = new SolidColorBrush(Colors.Yellow) });
            Add(new Team() { Name = "The Blues", City = "London", Color = new SolidColorBrush(Colors.Orange) });
            Team _t = new Team() { Name = "The Gunners", City = "London", Color = new SolidColorBrush(Colors.Red) };
            _t["Gaffer"] = "le Professeur";
            _t["Skipper"] = "Mr Gooner";

            Add(_t);
        }

    }
}
