using PubSub;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QBox.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
            try
            {
                if (Classes.Themesetter.GetApplicationTheme() == "Dark")
                    ThemeSelector.SelectedIndex = 0;
                else if (Classes.Themesetter.GetApplicationTheme() == "Light")
                    ThemeSelector.SelectedIndex = 1;
                else
                    ThemeSelector.SelectedIndex = 2;
            }
            catch { }
            namebox.Text = Model.SignHelper.GetName();
            Family.Text = Model.SignHelper.GetFamily();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.Publish("Settings");
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.GetFileAsync("avatar.jpg");

            avatar.ImageSource = new BitmapImage(new Uri(sampleFile.Path));
        }
        private void ThemeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Classes.Themesetter.SetApplicationTheme((ThemeSelector.SelectedItem as ComboBoxItem).Tag.ToString());
            }
            catch { }
        }
        private string name;
        private string filename;

        private async void Button_Click_1(object sender, RoutedEventArgs e)
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


                avatar.ImageSource = null;

                const uint size = 150; //Send your required size
                using (StorageItemThumbnail thumbnail = await copiedFile.GetThumbnailAsync(ThumbnailMode.SingleItem, size))
                {
                    if (thumbnail != null)
                    {
                        //Prepare thumbnail to display
                        BitmapImage bitmapImage = new BitmapImage();

                        bitmapImage.SetSource(thumbnail);
                        avatar.ImageSource = bitmapImage;


                    }
                }
                var messageDialog = new MessageDialog("Your picture had been saved successfuly.");
                messageDialog.ShowAsync();

            }
        }


        private void Family_TextChanged(object sender, TextChangedEventArgs e)
        {
            Model.SignHelper.SetFamily(Family.Text);
        }

        private void namebox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Model.SignHelper.SetName(namebox.Text);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Mybar.Visibility = Visibility.Visible;
            await AddFakeDars();
            await AddFakeQuestions();
            Mybar.Visibility = Visibility.Collapsed;


           
            


        }
        private Random _random = new Random();

        async Task AddFakeDars()
        {
            try
            {
                Model.SetNewQuestions.SetCourse(new Model.Course() { Name = "Math", ID = 101 });
                Model.SetNewQuestions.SetCourse(new Model.Course() { Name = "Physins", ID = 102 });
                Model.SetNewQuestions.SetCourse(new Model.Course() { Name = "Computer", ID = 103 });
            }
            catch { }

        }
        async Task AddFakeQuestions()
        {

            List<Model.Question> Questions = new List<Model.Question>();
            for (int i = 0; i < 100; i++)
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
                    Course = new Model.Course { Name = "Math", ID = 101 }


                });
            }
            for (int i = 0; i < 100; i++)
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
                    Course = new Model.Course { Name = "Physins", ID = 102 }


                });
            }
            for (int i = 0; i < 100; i++)
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
                    Course = new Model.Course { Name = "Computer", ID = 103 }


                });
            }
            foreach (var item in Questions)
            {
                Model.SetNewQuestions.SetQuestion(item);
            }

        }
    }
}
