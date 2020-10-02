using ApiHelper.Models;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiHelper
{
    public class DogApiProcessor
    {

        public static async Task<BreedModel> LoadBreedList()
        {
            ///TODO : À compléter LoadBreedList
            /// Attention le type de retour n'est pas nécessairement bon
            string url = $"https://dog.ceo/api/breeds/list";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
               // Debug.WriteLine(response.Content.);
                if (response.IsSuccessStatusCode)
                {

                    var message  = await response.Content.ReadAsStringAsync();
                    BreedModel breeds = JsonConvert.DeserializeObject<BreedModel>(message);
                    return breeds;

                }
                else
                {
 
                    throw new Exception(response.ReasonPhrase);
                }


            }
            /// J'ai mis quelque chose pour avoir une base
            /// TODO : Compléter le modèle manquant

        }

        public static async Task<DogModel> GetImageUrl(string breed)
        {
            /// TODO : GetImageUrl()
            string url = $"https://dog.ceo/api/breed/hound/images/random";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                // Debug.WriteLine(response.Content.);
                if (response.IsSuccessStatusCode)
                {

                    var message = await response.Content.ReadAsStringAsync();
                    DogModel dogs = JsonConvert.DeserializeObject<DogModel>(message);
                    return dogs;

                }
                else
                {

                    throw new Exception(response.ReasonPhrase);
                }


            }

        }
    }
}
