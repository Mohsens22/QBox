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
using QBox.ViewModels;
using QBox.ViewModels;
using PubSub;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QBox.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Main : Page
    {
     
        public ViewModels.SwipePanelViewModel VM { get; set; }
        public Main()
        {
            this.InitializeComponent();
            DataContextChanged += (s, e) =>
            {
                VM = DataContext as SwipePanelViewModel;
            };

        }

        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.Publish("Home");
        }
    }
}
