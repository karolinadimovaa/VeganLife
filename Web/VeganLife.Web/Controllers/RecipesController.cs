namespace VeganLife.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using VeganLife.Data.Models;
    using VeganLife.Services.Data;
    using VeganLife.Web.ViewModels.Recipes;

    public class RecipesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRecipesService recipesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public RecipesController(ICategoriesService categoriesService, IRecipesService recipesService, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            this.categoriesService = categoriesService;
            this.recipesService = recipesService;
            this.userManager = userManager;
            this.environment = environment;
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
            try
            {
            await this.recipesService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception exception)
            {
                this.ModelState.AddModelError(string.Empty, exception.Message);
                input.CategoriesItems = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }
            // TODO: Redirect to recipe info page
            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 6;
            var viewModel = new RecipesListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                RecipesCount = this.recipesService.GetCount(),
                Recipes = this.recipesService.GetAll(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        public IActionResult OneRecipe(int id)
        {
            var singleRecipe = this.recipesService.GetOneRecipe<OneRecipeViewModel>(id);
            return this.View(singleRecipe);
        }
    }
}
