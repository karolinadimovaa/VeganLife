namespace VeganLife.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using VeganLife.Data.Models;
    using VeganLife.Services.Data;
    using VeganLife.Web.ViewModels.Recipes;

    public class RecipesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRecipesService recipesService;
        private readonly UserManager<ApplicationUser> userManager;

        public RecipesController(ICategoriesService categoriesService, IRecipesService recipesService, UserManager<ApplicationUser> userManager)
        {
            this.categoriesService = categoriesService;
            this.recipesService = recipesService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel();
            viewModel.CategoriesItems= this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateRecipeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems= this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }
            var user = await this.userManager.GetUserAsync(this.User);
            await this.recipesService.CreateAsync(input, user.Id);

            // TODO: Redirect to recipe info page
            return this.Redirect("/");
        }

        public IActionResult All(int id)
        {
            return this.Redirect("/");
        }
    }
}
