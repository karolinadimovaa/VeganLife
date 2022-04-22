using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VeganLife.Web.ViewModels.Recipes;

namespace VeganLife.Web.Controllers
{
    public class ShopController:Controller
    {
        public ShopController()
        {
  
        }

        public IActionResult Shop()
        {            
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Shop(CreateRecipeInputModel input)
        {
            return this.View();
        }
    }
}
