using CocktailApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailApp.Services
{
    public interface ICocktailServices
    {
        Task<IEnumerable<Glass>> GetGlasses();
        Task<IEnumerable<Drink>> GetDrinksByCocktailGlass(string glass);
    }
}
