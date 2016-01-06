using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace DataBindingSample.Converter
{
    public class GradeConverter : IValueConverter
    {
        //Convert the slider value into Grades
        public object Convert(object value, System.Type type, object parameter, string language)
        {
            int _value;
            string _grade = string.Empty;
            //try parsing the value to int
            if (Int32.TryParse(value.ToString(), out _value))
            {
                if (_value < 50)
                    _grade = "F";
                else if (_value < 60)
                    _grade = "D";
                else if (_value < 70)
                    _grade = "C";
                else if (_value < 80)
                    _grade = "B";
                else if (_value < 90)
                    _grade = "A";
                else if (_value < 100)
                    _grade = "A+";
                else if (_value == 100)
                    _grade = "SUPER STAR!";
            }

            return _grade;
        }

        public object ConvertBack(object value, System.Type type, object parameter, string language)
        {
            throw new NotImplementedException(); //doing one-way binding so this is not required.
        }
    }
}
