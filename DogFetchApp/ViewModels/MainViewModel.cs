using DogFetchApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace DogFetchApp.ViewModels
{
    class MainViewModel : BaseViewModel

    {
        public DelegateCommand<string> FetchCommand { get; private set; }
        private string dogImagesList;
        private ObservableCollection<string> dogsImages;
        private ObservableCollection<string> breedList;
        private string numberOfImageToLoad;

        private string selectedItemBreed;

        private ObservableCollection<string> imagesToload;

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
            Init_value_combobox();
            Init();

        }



        private async void Init()
        {
            await Init_BreedList();

        }
        
        private void  Init_value_combobox()
        {
            ImagesToload = new ObservableCollection<string> { "1", "3", "5", "10" };


        }

        private async void FetchPicture(object obj)
        {
            DogsImages = new ObservableCollection<string>();
            if (SelectedItemBreed != null)
            {

                Debug.WriteLine(NumberOfImageTolLoad);
                for(int i = 0; i < int.Parse(NumberOfImageTolLoad.ToString()); i++)
                {

                    var images = await ApiHelper.DogApiProcessor.GetImageUrl(SelectedItemBreed);


                    DogsImages.Add(images.message);

                }
          
                Debug.WriteLine("Loading from : " + SelectedItemBreed + " Source");

                Debug.WriteLine(DogsImages.Count);
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
