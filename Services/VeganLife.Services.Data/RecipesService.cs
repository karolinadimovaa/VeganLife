namespace VeganLife.Services.Data
{
    using Grpc.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VeganLife.Data.Common.Repositories;
    using VeganLife.Data.Models;
    using VeganLife.Services.Mapping;
    using VeganLife.Web.ViewModels.Recipes;

    public class RecipesService : IRecipesService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientsRepository;

        public RecipesService(IDeletableEntityRepository<Recipe> recipesRepository,
            IDeletableEntityRepository<Ingredient> ingredientsRepository)
        {
            this.recipesRepository = recipesRepository;
            this.ingredientsRepository = ingredientsRepository;
        }

        public async Task CreateAsync(CreateRecipeInputModel input, string userId)
        {
            var recipe = new Recipe
            {
                CategoryId = input.CategoryId,
                Name = input.Name,
                Instructions = input.Instructions,
                TotalCookingTime = TimeSpan.FromMinutes(input.TotalCookingTime),
                CaloriesPerPortion = input.CaloriesPerPortion,
                PortionsCount = input.PortionsCount,
                AddedByUserId = userId,
            };

            foreach (var ingr in input.Ingredients)
            {
                var ingredient = this.ingredientsRepository.All().FirstOrDefault(x => x.Name == ingr.IngredientName);
                if (ingredient == null)
                {
                    ingredient = new Ingredient
                    {
                        Name = ingr.IngredientName,
                    };
                }
                recipe.Ingredients.Add(new RecipeIngredient
                {
                    Ingredient = ingredient,
                    Quantity = ingr.Quantity,
                });
            }
            await this.recipesRepository.AddAsync(recipe);
            await this.recipesRepository.SaveChangesAsync();
        }

        public IEnumerable<RecipeInListViewModel> GetAll(int page, int itemsPerPage = 12)
        {
            var recipes = this.recipesRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new RecipeInListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Instructions,
                    ImageUrl = x.Images.FirstOrDefault().RemoteImageUrl != null ? 
                    x.Images.FirstOrDefault().RemoteImageUrl : 
                    "/images/recipes/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension,
                }).ToList();
            return recipes;
        }

        public int GetCount()
        {         
            return this.recipesRepository.All().Count();
        }

        public T GetOneRecipe<T>(int id)
        {
            var singleRecipe = this.recipesRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();
            return singleRecipe;
        }
    }
}
