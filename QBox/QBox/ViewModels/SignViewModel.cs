using QBox.Classes;
using QBox.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Model;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;

namespace QBox.ViewModels
{
    class SignViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private string _family;
        private BitmapImage _avatar;
        public BitmapImage Avatar
        {
            get
            {
                return _avatar;

            }
            set
            {

                if (_avatar != value)
                {
                    _avatar = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Avatar"));
                    }
                }
            }
        }
        public string Family
        {
            get
            {
                return _family;

            }
            set
            {

                if (_family != value)
                {
                    _family = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Family"));
                    }
                }
            }
        }
        public string Name
        {
            get
            {
                return _name;

            }
            set
            {

                if (_name != value)
                {
                    _name = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Name"));
                    }
                }
            }
        }
        public MyCommand Picture
        {
            get;
            set;
        }
        public MyCommand SignInCommand
        {
            get;
            set;
        }
        public SignViewModel()
        {
            Picture = new MyCommand();
            Picture.CanExecuteFunc = obj => true;
            Picture.ExecuteFunc = PictureeAsync;
            SignInCommand = new MyCommand();
            SignInCommand.CanExecuteFunc = obj => true;
            SignInCommand.ExecuteFunc = SignIn;
        }
        private void SignIn(object obj)
        {
            Model.SignHelper.Usersetter(Name, Family);
            Wellcome.current.Frame.Navigate(typeof(MainPage));
        }
        private string name;
        private string filename;
        private async void PictureeAsync(object obj)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {


                // Application now has read/write access to the picked file
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;

                try
                {
                    Windows.Storage.StorageFolder storageFolder =
    Windows.Storage.ApplicationData.Current.LocalFolder;
                    Windows.Storage.StorageFile sampleFile =
                        await storageFolder.GetFileAsync("avatar.jpg");
                    sampleFile.DeleteAsync(StorageDeleteOption.PermanentDelete);

                }
                catch { }

                StorageFile copiedFile = await file.CopyAsync(localFolder, "avatar.jpg");

                filename = "avatar.jpg";




                const uint size = 150; //Send your required size
                using (StorageItemThumbnail thumbnail = await copiedFile.GetThumbnailAsync(ThumbnailMode.SingleItem, size))
                {
                    if (thumbnail != null)
                    {
                        //Prepare thumbnail to display
                        BitmapImage bitmapImage = new BitmapImage();

                        bitmapImage.SetSource(thumbnail);
                        Avatar = bitmapImage;


                    }
                }
                var messageDialog = new MessageDialog("Your picture had been saved successfuly.");
                messageDialog.ShowAsync();

            }
        }

    }
}
