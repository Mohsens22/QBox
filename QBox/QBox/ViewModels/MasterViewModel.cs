using PubSub;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBox.ViewModels
{
    public delegate void Sth(string something);
   
    public class MasterViewModel : INotifyPropertyChanged
    {
        
         public MasterViewModel()
        {
            this.Subscribe<string>(Text =>
            {
                Header = Text;
            });

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private string _header ;
        public string Header
        {
            get
            {

                return _header;

            }
            set
            {
                if (_header != value)
                {
                    _header = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Header"));
                    }
                }

            }
        }




    }
}
