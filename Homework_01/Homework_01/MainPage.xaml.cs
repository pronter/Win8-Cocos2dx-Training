using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Homework_01
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private delegate string AnimalSaying(object sender, myEventArgs e);
        private event AnimalSaying Say;
        Random example = new Random();
        private int number = 0;
        private string animal = "";
        public MainPage()
        {
            this.InitializeComponent();
        }
        class myEventArgs : EventArgs
        {
            public string t = "";
            public myEventArgs(string tt)
            {
                this.t = tt;
            }
        }
        interface Animal
        {
            string saying(object sender, myEventArgs e);
        }
        class cat : Animal
        {
            TextBlock word;
            public cat(TextBlock w)
            {
                this.word = w;
            }
            public string saying(object sender, myEventArgs e)
            {
                this.word.Text += "cat:我不是猫" + "\n";
                return "";
            }
        }
        class dog : Animal
        {
            TextBlock word;
            public dog(TextBlock w)
            {
                this.word = w;
            }
            public string saying(object sender, myEventArgs e)
            {
                this.word.Text += "dog:我不是狗" + "\n";
                return "";
            }
        }
        class pig : Animal
        {
            TextBlock word;
            public pig(TextBlock w)
            {
                this.word = w;
            }
            public string saying(object sender, myEventArgs e)
            {
                this.word.Text += "pig:我不是猪" + "\n";
                return "";
            }
        }
        private cat c;
        private dog d;
        private pig p;

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            number = example.Next(1, 4);
            if (number == 1)
            {
                output.Text = "";
                c = new cat(output);
                Say += new AnimalSaying(c.saying);
            }
            else if (number == 2)
            {
                output.Text = "";
                d = new dog(output);
                Say += new AnimalSaying(d.saying);
            }
            else if (number == 3)
            {
                output.Text = "";
                p = new pig(output);
                Say += new AnimalSaying(p.saying);
            }
            Say(this, new myEventArgs(animal));
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            animal = input.Text;
            if (animal == "cat")
            {
                output.Text = "";
                c = new cat(output);
                Say += new AnimalSaying(c.saying);
            }
            else if (animal == "dog")
            {
                output.Text = "";
                d = new dog(output);
                Say += new AnimalSaying(d.saying);
            }
            else if (animal == "pig")
            {
                output.Text = "";
                p = new pig(output);
                Say += new AnimalSaying(p.saying);
            }
            else
            {
                input.Text = "";
                return;
            }
            Say(this, new myEventArgs(animal));
            input.Text = "";
        }
    }
}
