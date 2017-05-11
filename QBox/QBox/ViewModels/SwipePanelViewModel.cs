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
            for (int i = 0; i < 7; i++)
            {
                items.Add(new NameValueItem { Name = "Test" + i, Value = _random.Next(10, 100) });
            }
            Greet = "Dear " + Model.SignHelper.GetName();
            Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
                await storageFolder.GetFileAsync("avatar.jpg");
            Picture = sampleFile.Path;
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
    }
}
