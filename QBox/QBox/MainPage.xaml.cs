using QBox.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;
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
            Myer((SolidColorBrush)Application.Current.Resources["AppBackgroundColor"], new SolidColorBrush(Colors.White));
        }
        
        private async void Myer(SolidColorBrush Brush , SolidColorBrush Foreground)
        {
            SolidColorBrush a = Brush;
            try
            {
                ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
                titleBar.BackgroundColor = a.Color;

                titleBar.ButtonBackgroundColor = a.Color;

                titleBar.InactiveBackgroundColor = a.Color;
                titleBar.ButtonInactiveBackgroundColor = a.Color;
                titleBar.InactiveForegroundColor = Foreground.Color;
                titleBar.ButtonInactiveForegroundColor = Foreground.Color;
                titleBar.ForegroundColor = Foreground.Color;
                titleBar.ButtonForegroundColor = Foreground.Color;


                //fuck you asshilism

            }
            catch
            {

            }
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                var statusBar = StatusBar.GetForCurrentView();
                if (statusBar != null)
                {
                    statusBar.BackgroundOpacity = 1;
                    statusBar.BackgroundColor = a.Color;
                    statusBar.ForegroundColor = Foreground.Color;
                }
            }
        }




        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tag = (e.ClickedItem as Grid).Tag.ToString();
            switch (tag)
            {
                case "Home":
                    Framer.Navigate(typeof(Main));
                    if (Split.DisplayMode != SplitViewDisplayMode.Inline)
                        Split.IsPaneOpen = false;

                    break;
                case "Performance":
                    Framer.Navigate(typeof(Performance));
                    if(Split.DisplayMode!= SplitViewDisplayMode.Inline)
                    Split.IsPaneOpen = false;

                    break;
                case "Test":
                    Framer.Navigate(typeof(Test));
                    if (Split.DisplayMode != SplitViewDisplayMode.Inline)
                        Split.IsPaneOpen = false;
                    break;
                case "Data":
                    Framer.Navigate(typeof(DB));
                    if (Split.DisplayMode != SplitViewDisplayMode.Inline)
                        Split.IsPaneOpen = false;
                    break;
                case "About":
                    Framer.Navigate(typeof(About));
                    if (Split.DisplayMode != SplitViewDisplayMode.Inline)
                        Split.IsPaneOpen = false;
                    break;
                case "Settings":
                    Framer.Navigate(typeof(Settings));
                    if (Split.DisplayMode != SplitViewDisplayMode.Inline)
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
