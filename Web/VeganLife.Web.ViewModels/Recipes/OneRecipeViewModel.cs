namespace VeganLife.Web.ViewModels.Recipes
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using VeganLife.Data.Models;
    using VeganLife.Services.Mapping;

    public class OneRecipeViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public string Instructions { get; set; }

        public TimeSpan TotalCookingTime { get; set; }

        public int PortionsCount { get; set; }

        public int CaloriesPerPortion { get; set; }

        public IEnumerable<IngredientsViewModel> Ingredients { get; set; }

        public void CreateMappings(IProfileExpression conf)
        {
            conf.CreateMap<Recipe, OneRecipeViewModel>().ForMember(x => x.ImageUrl, opt =>
             opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl != null ?
             x.Images.FirstOrDefault().RemoteImageUrl :
             "/images/recipes/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
