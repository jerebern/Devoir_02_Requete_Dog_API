using DogFetchApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DogFetchApp.ViewModels
{
    class MainViewModel : BaseViewModel

    {
        public DelegateCommand<string> FetchCommand { get; private set; }
        private ObservableCollection<string> dogImagesList;
        private ObservableCollection<string> breedList;

        private string selectedItem;

        
        public string SelectedItem
        {
            get => selectedItem;

            set
            {
                selectedItem = value;
                OnPropertyChanged();
                Debug.WriteLine("Selected breed : " + selectedItem);
            }

        }

        public ObservableCollection<string> DogImagesList
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
            Init();

        }



        private async void Init()
        {
            await Init_BreedList();
        }

        private async void FetchPicture(object obj)
        {
            DogImagesList = new ObservableCollection<string>();
            // to do send breed to request 

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
