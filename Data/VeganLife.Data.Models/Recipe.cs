namespace VeganLife.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using VeganLife.Data.Common.Models;

    public class Recipe : BaseDeletableModel<int>
    {
        public Recipe()
        {
            this.Ingredients = new HashSet<RecipeIngredient>();
            this.Images = new HashSet<RecipeImage>();
        }

        public string Name { get; set; }

        public string Instructions { get; set; }

        public TimeSpan TotalCookingTime { get; set; }

        public int PortionsCount { get; set; }

        public int CaloriesPerPortion { get; set; }

        public string OriginalUrl { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public int CategoryId { get; set; }

        //// public bool IsApproved { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<RecipeIngredient> Ingredients { get; set; }

        public virtual ICollection<RecipeImage> Images { get; set; }
    }
}
