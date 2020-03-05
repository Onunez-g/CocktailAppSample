using CocktailApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CocktailApp.Services
{
    class CocktailServices : ICocktailServices
    {
        const string ApiURL = "https://www.thecocktaildb.com/api/json/v1/1";
        public async Task<IEnumerable<Drink>> GetDrinksByCocktailGlass(string glass)
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync($"{ApiURL}/filter.php?g={glass}");
            var cocktails = JsonConvert.DeserializeObject<Cocktail>(result);
            return cocktails.Drinks;
        }

        public async Task<IEnumerable<Glass>> GetGlasses()
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync($"{ApiURL}/list.php?g=list");
            var glasses = JsonConvert.DeserializeObject<CocktailGlass>(result);
            return glasses.Drinks;
        }
    }
}
