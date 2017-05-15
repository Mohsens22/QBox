using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBox.ViewModels
{
    public class PerformanceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Model.Stat> Stats { get; set; }
        public PerformanceViewModel()
        {
            Stats = new ObservableCollection<Model.Stat>();
            List<Model.Stat> _stats = Model.SetNewQuestions.GetStats();
            foreach (var item in _stats)
            {
                Stats.Add(item);
            }

        }
    }
}
