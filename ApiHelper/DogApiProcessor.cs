using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
//
namespace ApiHelper
{
    public class DogApiProcessor
    {

        public static async Task<List<string>> LoadBreedList()
        {
            ///TODO : À compléter LoadBreedList
            /// Attention le type de retour n'est pas nécessairement bon
            /// J'ai mis quelque chose pour avoir une base
            /// TODO : Compléter le modèle manquant

            return new List<string>();
        }

        public static async Task<string> GetImageUrl(string breed)
        {
            /// TODO : GetImageUrl()
            /// TODO : Compléter le modèle manquant
            return string.Empty;
        }
    }
}
