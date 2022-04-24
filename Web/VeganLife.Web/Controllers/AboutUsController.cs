using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VeganLife.Services.Data;
using VeganLife.Web.ViewModels.Home;
using VeganLife.Web.ViewModels.Recipes;
using Microsoft.AspNetCore.Identity;
using VeganLife.Data.Models;


namespace VeganLife.Web.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRecipesService recipesService;
        private readonly UserManager<ApplicationUser> userManager;

        public AboutUsController(ICategoriesService categoriesService, IRecipesService recipesService, UserManager<ApplicationUser> userManager)
        {
            this.categoriesService = categoriesService;
            this.recipesService = recipesService;
            this.userManager = userManager;
        }

        public IActionResult AboutUs()
        {
            var viewModel = new CreateRecipeInputModel();
            viewModel.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }
    }
}
