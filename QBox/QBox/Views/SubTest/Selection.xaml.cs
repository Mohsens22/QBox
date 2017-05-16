using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QBox.Views.SubTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Selection : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Model.Course> Courses { get; set; }
        Model.Course _Dars;
        int _Amount;
        public Selection()
        {
            this.InitializeComponent();
            Courses = new ObservableCollection<Model.Course>();
            var x = Model.SetNewQuestions.GetCourse();
            foreach (var item in x)
            {
                Courses.Add(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Var_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Var.SelectedIndex = 0;
            }
            catch { }
        }

        private void Vax_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Vax.SelectedIndex = 0;
            }
            catch { }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var x = new Classes.CourseItems {Dars=_Dars , Items=_Amount };
            Frame.Navigate(typeof(ExamInterface), x);
        }

        private void Vax_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

                 _Amount= int.Parse((e.AddedItems.FirstOrDefault() as ComboBoxItem).Tag.ToString());
        }

        private void Var_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           _Dars =(Model.Course) e.AddedItems.FirstOrDefault();
        }
    }
}
