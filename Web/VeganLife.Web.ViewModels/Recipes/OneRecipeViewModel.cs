namespace VeganLife.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using VeganLife.Data.Models;
    using VeganLife.Services.Mapping;

    public class OneRecipeViewModel : IMapFrom<Recipe>
    {
        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public string Instructions { get; set; }

        public TimeSpan TotalCookingTime { get; set; }

        public int PortionsCount { get; set; }

        public int CaloriesPerPortion { get; set; }

        public IEnumerable<IngredientsViewModel> Ingredients { get; set; }
    }
}
