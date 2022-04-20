﻿namespace VeganLife.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using VeganLife.Data;
    using VeganLife.Web.ViewModels;
    using VeganLife.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                CategoriesCount = this.db.Categories.Count(),
                RecipeImagesCount = this.db.RecipeImages.Count(),
                IngredientsCount = this.db.Ingredients.Count(),
                RecipesCount = this.db.Recipes.Count(),
                ProductsCount = this.db.Products.Count(),
                ProductImagesCount = this.db.ProductImages.Count(), 
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
