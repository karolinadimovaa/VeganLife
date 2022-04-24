namespace VeganLife.Web.ViewModels.Recipes
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateRecipeInputModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [MinLength(40)]
        public string Instructions { get; set; }

        [Range(0, 24 * 60)]
        [Display(Name ="Cooking Time(Please include preparation time) in minutes")]
        public int TotalCookingTime { get; set; }

        [Range(1,100)]
        public int PortionsCount { get; set; }

        public IFormFile

        [Range(1, 10000)]
        public int CaloriesPerPortion { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<RecipeIngredientInputModel> Ingredients { get; set; }

        public IEnumerable<KeyValuePair<string,string>> CategoriesItems { get; set; }
    }
}
