using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace QBox.Views.SubTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExamInterface : Page
    {
        ObservableCollection<Model.Question> Questions = new ObservableCollection<Model.Question>();
        private Random _random = new Random();
        public ExamInterface()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
          var x=  e.Parameter as Classes.CourseItems;
            for (int i = 0; i < x.Items; i++)
            {
                Questions.Add(new Model.Question
                {
                    Soal = "Soal with the index of" + i,
                    Answer = new List<Model.Answer>
                    {

                         new Model.Answer{AssignedFlag=1,Javab="1St answer for"+i },
                         new Model.Answer{AssignedFlag=2,Javab="2Nd answer for"+i },
                         new Model.Answer{AssignedFlag=3,Javab="3Rd answer for"+i },
                         new Model.Answer{AssignedFlag=4,Javab="4Th answer for"+i },
                    },
                    Correct = _random.Next(1, 4),
                    Course = x.Dars


                });
            }
        }
    }
}
