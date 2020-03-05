using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailApp.Models
{
    public class Drink
    {

        [JsonProperty("strDrink")]
        public string StrDrink { get; set; }

        [JsonProperty("strDrinkThumb")]
        public string StrDrinkThumb { get; set; }

        [JsonProperty("idDrink")]
        public string IdDrink { get; set; }
    }

    public class Cocktail
    {

        [JsonProperty("drinks")]
        public List<Drink> Drinks { get; set; }
    }
}
