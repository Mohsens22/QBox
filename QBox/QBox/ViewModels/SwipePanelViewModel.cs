using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Model;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using QBox.Classes;

namespace QBox.ViewModels
{
    public class SwipePanelViewModel : INotifyPropertyChanged
    {
        private Random _random = new Random();

        public SwipePanelViewModel()
        {
            setters();   
        }

        private async void setters()
        {
            items = new ObservableCollection<NameValueItem>();
           
            Greet = "Dear " + Model.SignHelper.GetName();
            Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
                await storageFolder.GetFileAsync("avatar.jpg");
            Picture = sampleFile.Path;

            List<Model.Stat> myls = new List<Stat>();
            myls = Model.SetNewQuestions.GetStats();
            int _all=0;
            Done = 0;
            myls.Reverse();
            int _num = 0;
            foreach (var item in myls)
            {
                
                Done = Done+ item.Correct;
                _all =_all+ item.All;
                if(_num<7)
                {
                    int percentsuspend;
                    if (item.All != 0)
                        percentsuspend = (int)Math.Round((double)(100 * item.Correct) / item.All);
                    else
                        percentsuspend = 0;
                    items.Add(new NameValueItem { Name = "Test"+_num , Value = percentsuspend });
                }
                _num++;
            }
            Sucked = _all - Done;
            
        }
        public ObservableCollection<NameValueItem> items {
            get;

            set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private string _picture ;
        private string _greet;
        public string Picture
        {
            get
            {

                return _picture;

            }
            set
            {
                if (_picture != value)
                {
                    _picture = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Picture"));
                    }
                }

            }
        }
        public string Greet
        {
            get
            {

                return _greet;

            }
            set
            {
                if (_greet != value)
                {
                    _greet = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Greet"));
                    }
                }

            }
        }
        public int Done { get; set; }
        public int Sucked { get; set; }
    }
}
