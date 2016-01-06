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
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;  
// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Homework_02
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void animation_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(animation));
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ID_box.Text = "";
            Class_selection.SelectedValue = "";
            Name_box.Text = "";
            Gender_female.IsChecked = false;
            Gender_male.IsChecked = false;
            Fire.IsChecked = false;
            Water.IsChecked = false;
            Soild.IsChecked = false;
            Wind.IsChecked = false;
            Describe_box.Text = "Tell something···";
            Check.Text = "";
        }

        private async void Uplord_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".bmp");
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read);
                Windows.UI.Xaml.Media.Imaging.BitmapImage bmp = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                bmp.SetSource(stream);
                this.picture.Source = bmp;
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string all = "Registration failed!\n";
            int times = 0;
            if (Class_selection.SelectedValue == "")
            {
                all += "Please choose your Class.\n";
            }
            else if(Class_selection.SelectedValue != "") 
            {
                times++;
            }
            if (ID_box.Text == "")
            {
                all += "Please fill in your ID.\n";
            }
            else if(ID_box.Text != "") 
            {
                times++;
            }
            if (Name_box.Text == "")
            {
                all += "Please fill in your Name.\n";
            }
            else if(Name_box.Text != "") 
            {
                times++;
            }
            if (Gender_female.IsChecked == false && Gender_male.IsChecked == false)
            {
                all += "Please choose your gender.\n";
            }
            else if (Gender_female.IsChecked != false || Gender_male.IsChecked != false) 
            {
                times++;
            }
            if (Fire.IsChecked == false && Water.IsChecked == false && Soild.IsChecked == false && Wind.IsChecked == false)
            {
                all += "Please choose your Attribute.\n";
            }
            else if (Fire.IsChecked != false || Water.IsChecked != false || Soild.IsChecked != false || Wind.IsChecked != false)
            {
                times++;
            }
            if (times == 5)
            {
                Check.Text = "Congratulations!\nYou have successfully registered!\nHave a good game!\n";
            }
            else if (times != 5) {
                Check.Text = all;
            }
        }


    }
}