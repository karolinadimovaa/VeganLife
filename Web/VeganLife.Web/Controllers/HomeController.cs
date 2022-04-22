namespace VeganLife.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using VeganLife.Data;
    using VeganLife.Data.Common.Repositories;
    using VeganLife.Data.Models;
    using VeganLife.Services.Data;
    using VeganLife.Web.ViewModels;
    using VeganLife.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService countsService;

        public HomeController(IGetCountsService countsService)
        {
            this.countsService = countsService;
        }

        public IActionResult Index()
        {
            var countsDto = this.countsService.GetCounts();
            var viewModel = new IndexViewModel
            {
                CategoriesCount = countsDto.CategoriesCount,
                ProductImagesCount = countsDto.ProductImagesCount,
                RecipeImagesCount = countsDto.RecipeImagesCount,
                RecipesCount = countsDto.RecipesCount,
                IngredientsCount = countsDto.IngredientsCount,
                ProductsCount = countsDto.ProductsCount,
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }
        public IActionResult AboutUs()
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
