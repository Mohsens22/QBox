using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QBox.Views.SubTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExamInterface : Page
    {
        ObservableCollection<Model.Question> Questions = new ObservableCollection<Model.Question>();
        private Random _random = new Random();
        private DispatcherTimer timer;
        private int basetime;
        public ExamInterface()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
        }
        void timer_Tick(object sender, object e)
        {
            basetime = basetime - 1;
            txt.Text = basetime.ToString();
            if (basetime <= 30)
            {
                txt.Foreground = new SolidColorBrush( Colors.Red);

            }
            if (basetime == 0)
            {
                timer.Stop();
                endsession();
            }

        }
        Model.Course _dars;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
          var x=  e.Parameter as Classes.CourseItems;
            var z = Model.SetNewQuestions.GetQuestion(x.Dars, x.Items);
            All = x.Items;
            _dars = x.Dars;
            foreach (var item in z)
            {
                Questions.Add(item);
            }
            basetime = x.Items*30;
            txt.Text = basetime.ToString();
            timer.Start();
        }
        int All, done, Estimated;
        void endsession()
        {
          

            var a = ListOfTests.Items;
            int _done = 5;
            Classes.NavigationStat _stat= new Classes.NavigationStat { All = All, Done=_done, Estimated = basetime,Dars=_dars};


            Frame.Navigate(typeof(FinalCard), _stat);

        }
        void calculateDone()
        {


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            endsession();
        }
    }
}
