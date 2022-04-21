namespace VeganLife.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using VeganLife.Data.Common.Repositories;
    using VeganLife.Data.Models;
    using VeganLife.Services.Data.Dtos;
    using VeganLife.Web.ViewModels.Home;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IRepository<RecipeImage> recipeImagesRepository;
        private readonly IRepository<ProductImage> productImagesRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;
        private readonly IDeletableEntityRepository<Product> productRepository;

        public GetCountsService(
            IDeletableEntityRepository<Category> categoriesRepository,
            IRepository<RecipeImage> recipeImagesRepository,
            IRepository<ProductImage> productImagesRepository,
            IDeletableEntityRepository<Ingredient> ingredientRepository,
            IDeletableEntityRepository<Recipe> recipesRepository,
            IDeletableEntityRepository<Product> productRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.recipeImagesRepository = recipeImagesRepository;
            this.productImagesRepository = productImagesRepository;
            this.ingredientRepository = ingredientRepository;
            this.recipesRepository = recipesRepository;
            this.productRepository = productRepository;
        }

        public CountsDto GetCounts()
        {
            var data = new CountsDto
            {
                CategoriesCount = this.categoriesRepository.All().Count(),
                RecipeImagesCount = this.recipeImagesRepository.All().Count(),
                IngredientsCount = this.ingredientRepository.All().Count(),
                RecipesCount = this.recipesRepository.All().Count(),
                ProductsCount = this.productRepository.All().Count(),
                ProductImagesCount = this.productImagesRepository.All().Count(),
            };
            return data;
        }
    }
}
