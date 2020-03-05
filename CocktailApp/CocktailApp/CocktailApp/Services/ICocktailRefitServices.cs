using CocktailApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailApp.Services
{
    public interface ICocktailRefitServices
    {
        [Get("/filter.php?g={glass}")]
        Task<Cocktail> GetDrinksByGlassAsync(string glass);
    }
}
