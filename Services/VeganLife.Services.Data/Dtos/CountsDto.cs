using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeganLife.Services.Data.Dtos
{
    public  class CountsDto
    {
        public int RecipesCount { get; set; }

        public int CategoriesCount { get; set; }

        public int IngredientsCount { get; set; }

        public int RecipeImagesCount { get; set; }

        public int ProductsCount { get; set; }

        public int ProductImagesCount { get; set; }
    }
}
