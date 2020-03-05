using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailApp.Models
{
    public class Glass
    {

        [JsonProperty("strGlass")]
        public string StrGlass { get; set; }
    }

    public class CocktailGlass
    {

        [JsonProperty("drinks")]
        public List<Glass> Drinks { get; set; }
    }
}
