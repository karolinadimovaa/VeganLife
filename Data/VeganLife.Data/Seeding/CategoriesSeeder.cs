namespace VeganLife.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VeganLife.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if(dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Breakfast" });

            await dbContext.Categories.AddAsync(new Category { Name = "Lunch" });

            await dbContext.Categories.AddAsync(new Category { Name = "Dinner" });

            await dbContext.SaveChangesAsync();
        }
    }
}
