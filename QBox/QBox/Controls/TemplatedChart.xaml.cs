using System;
using System.Collections.Generic;
using System.ComponentModel;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace QBox.Controls
{
    public sealed partial class TemplatedChart : UserControl,INotifyPropertyChanged
    {
        public TemplatedChart()
        {
            this.InitializeComponent();
            

        }
       
        private Double _percentage;
        public Double Percentage
        {
            get
            {

                return _percentage;

            }
            set
            {
                if (_percentage != value)
                {
                    _percentage = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Percentage"));
                    }
                }

            }
        }
        public SolidColorBrush SegmentColor
        {
            get { return (SolidColorBrush)GetValue(SegmentColorProperty); }
            set { SetValue(SegmentColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SegmentColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SegmentColorProperty =
            DependencyProperty.Register("SegmentColor", typeof(SolidColorBrush), typeof(TemplatedChart), new PropertyMetadata(null));


        public SolidColorBrush GlyphBrush
        {
            get { return (SolidColorBrush)GetValue(GlyphBrushProperty); }
            set { SetValue(GlyphBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GlyphBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GlyphBrushProperty =
            DependencyProperty.Register("GlyphBrush", typeof(SolidColorBrush), typeof(TemplatedChart), new PropertyMetadata(null));



        
        
        public int DoneTasks
        {
            get { return (int)GetValue(DoneTasksProperty);

                
            }
            set { SetValue(DoneTasksProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DoneTasks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DoneTasksProperty =
            DependencyProperty.Register("DoneTasks", typeof(int), typeof(TemplatedChart), new PropertyMetadata(null, IntendedValuePropertyChangedCallback));

        private static void IntendedValuePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var Fuck = d as TemplatedChart;
            if (Fuck == null) return;
            int percentsuspend;
            if (Fuck.PendingTasks != 0)
                percentsuspend = (int)Math.Round((double)(100 * Fuck.DoneTasks) / Fuck.PendingTasks);
            else
                percentsuspend = 0;

            Fuck.Percentage = percentsuspend;
        }

        public int PostponedTasks
        {
            get { return (int)GetValue(PostponedTasksProperty); }
            set { SetValue(PostponedTasksProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PostponedTasks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PostponedTasksProperty =
            DependencyProperty.Register("PostponedTasks", typeof(int), typeof(TemplatedChart), new PropertyMetadata(null));


        public int PendingTasks
        {
            get {
               
                return (int)GetValue(PendingTasksProperty);
                
            }
            set { SetValue(PendingTasksProperty, value);

               
            }
        }
        

        // Using a DependencyProperty as the backing store for PendingTasks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PendingTasksProperty =
            DependencyProperty.Register("PendingTasks", typeof(int), typeof(TemplatedChart), new PropertyMetadata(null, IntendedValuePropertyChangedCallback));









        public string TheTime
        {
            get { return (string)GetValue(TheTimeProperty); }
            set { SetValue(TheTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TheTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TheTimeProperty =
            DependencyProperty.Register("TheTime", typeof(string), typeof(TemplatedChart), new PropertyMetadata(null));





        public string Dars
        {
            get { return (string)GetValue(DarsProperty); }
            set { SetValue(DarsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Dars.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DarsProperty =
            DependencyProperty.Register("Dars", typeof(string), typeof(TemplatedChart), new PropertyMetadata(null));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
