using QBox.Views;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace QBox
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
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                try
                {
                    Frame.BackStack.Clear();

                }
                catch { }
            }
            Framer.Navigate(typeof(Main));

        }


        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tag = (e.ClickedItem as Grid).Tag.ToString();
            switch (tag)
            {
                case "Home":
                    Framer.Navigate(typeof(Main));
                    Split.IsPaneOpen = false;

                    break;
                case "Performance":
                    Framer.Navigate(typeof(Performance));
                    Split.IsPaneOpen = false;

                    break;
                case "Test":
                    Framer.Navigate(typeof(Test));
                    Split.IsPaneOpen = false;

                    break;
                case "Data":
                    Framer.Navigate(typeof(DB));
                    Split.IsPaneOpen = false;

                    break;
                case "About":
                    Framer.Navigate(typeof(About));
                    Split.IsPaneOpen = false;

                    break;
                case "Settings":
                    Framer.Navigate(typeof(Settings));
                    Split.IsPaneOpen = false;

                    break;


            }
        }

        private void SplitButton_Click(object sender, RoutedEventArgs e)
        {
            Split.IsPaneOpen = !Split.IsPaneOpen;
        }
    }
}
