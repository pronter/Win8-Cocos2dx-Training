using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DataBindingSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void ElementBindingButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ElementBinding));
        }

        private void BindingToObjectsButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BindToObjects));
        }

        private void ObservableCollectionBinding_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ObservableCollectionBinding));
        }

        private void NotifyPropertyChangedBindingButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NotifyPropertyChangedPerson));
        }

        private void ConvertersButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Converters));
        }

        private void DataTemplatesButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DataTemplating));
        }

        private void AnonymousTypeBinding_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AnonymousTypeBinding));
        }
    }
}
