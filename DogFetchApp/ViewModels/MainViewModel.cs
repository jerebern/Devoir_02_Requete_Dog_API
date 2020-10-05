using DogFetchApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;


namespace DogFetchApp.ViewModels
{
    class MainViewModel : BaseViewModel

    {
        public DelegateCommand<string> FetchCommand { get; private set; }
        public DelegateCommand<string> ChangeLanguageCommand { get; private set; }
        private string dogImagesList;
        private ObservableCollection<string> dogsImages;
        private ObservableCollection<string> breedList;
        private string numberOfImageToLoad;
        private int numberOfImageToShow;
        private string selectedPicture;

        private string selectedItemBreed;

        private ObservableCollection<string> imagesToload;

        public string SelectedPicture
        {
            get => selectedPicture;

            set
            {
                selectedPicture = value;
                OnPropertyChanged();
            }
        }

        public int NumberOfImageToShow
        {
            get => numberOfImageToShow;

            set
            {
                numberOfImageToShow = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> ImagesToload{

            get => imagesToload;

            set
            {
                imagesToload = value;
                OnPropertyChanged();
            }
        
        }
        public string NumberOfImageTolLoad
        {
            get => numberOfImageToLoad;

            set
            {
                numberOfImageToLoad = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> DogsImages{
            get => dogsImages;

            set
            {
                dogsImages = value;
                OnPropertyChanged();
            }

            }
        public string SelectedItemBreed
        {
            get => selectedItemBreed;

            set
            {
                selectedItemBreed = value;
                OnPropertyChanged();
                Debug.WriteLine("Selected breed : " + selectedItemBreed);
            }

        }

        public string DogImagesList
        {
            get => dogImagesList;

            set
            {
                dogImagesList = value;
                OnPropertyChanged();
            }

        }

        public ObservableCollection<string> Breedlist
        {

            get => breedList;

            set
            {
                breedList = value;
                OnPropertyChanged();
            }

        }

        public MainViewModel()
        {
            FetchCommand = new DelegateCommand<string>(FetchPicture);
            ChangeLanguageCommand = new DelegateCommand<string>(Change_Language);
            Init_value_combox();
            Init();

        }



        private async void Init()
        {
            await Init_BreedList();

        }
        
        private void  Init_value_combox()
        {
            ImagesToload = new ObservableCollection<string> { "1", "3", "5", "10" };


        }


        private void Change_Language(string str)
        {
            Debug.WriteLine("Changing language to : " + str);
            Properties.Settings.Default.Language = str;
            Properties.Settings.Default.Save();
            Debug.WriteLine("Starting " + Application.ResourceAssembly.Location);
             string path =  Application.ResourceAssembly.Location;
            string filtoStart = Path.ChangeExtension(path,".exe");
            System.Diagnostics.Process.Start(filtoStart);
            Application.Current.Shutdown();

        }

        private async void FetchPicture(object obj)
        {
            DogsImages = new ObservableCollection<string>();
            if (SelectedItemBreed != null)
            {

                Debug.WriteLine(NumberOfImageTolLoad);

                if(NumberOfImageTolLoad != null)
                {

                for(int i = 0; i < int.Parse(NumberOfImageTolLoad.ToString()); i++)
                {

                    var images = await ApiHelper.DogApiProcessor.GetImageUrl(SelectedItemBreed);


                    DogsImages.Add(images.message);

                }
          
                Debug.WriteLine("Loading from : " + SelectedItemBreed + " Source");

                Debug.WriteLine(DogsImages.Count);
                    numberOfImageToShow = int.Parse(NumberOfImageTolLoad);
            }

            }
        }

        private async Task Init_BreedList()
        {

          var breeds = await ApiHelper.DogApiProcessor.LoadBreedList();
            Breedlist = new ObservableCollection<string>();

           Debug.WriteLine( breeds.message.Count);
            foreach(var breed in breeds.message)
            {
                Breedlist.Add(breed);
           }


        }


    }
}
