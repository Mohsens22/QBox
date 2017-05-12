using PubSub;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QBox.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DB : Page
    {
        public DB()
        {
            this.InitializeComponent();
           
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.Publish("Database");
        }

        private void Var_Loaded(object sender, RoutedEventArgs e)
        {
            Var.SelectedIndex = 0;
        }

        private void Vax_Loaded(object sender, RoutedEventArgs e)
        {
            Vax.SelectedIndex = 0;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (Opener.Visibility == Visibility.Collapsed)
                Opener.Visibility = Visibility.Visible;
            else
                Opener.Visibility = Visibility.Collapsed;

        }
    }
}
