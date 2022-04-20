namespace VeganLife.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using VeganLife.Data.Common.Models;

    public class Ingredient : BaseDeletableModel<int>
    {
        public Ingredient()
        {
            this.Recipes = new HashSet<RecipeIngredient>();
        }

        public string Name { get; set; }

        public ICollection<RecipeIngredient> Recipes { get; set; }
    }
}
