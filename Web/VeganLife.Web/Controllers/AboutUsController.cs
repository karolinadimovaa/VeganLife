using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VeganLife.Services.Data;
using VeganLife.Web.ViewModels.Home;
using VeganLife.Web.ViewModels.Recipes;
using Microsoft.AspNetCore.Identity;
using VeganLife.Data.Models;


namespace VeganLife.Web.Controllers
{
    public class AboutUsController : Controller
    {
        public AboutUsController()
        {
        }

        public IActionResult AboutUs()
        {
            return this.View();
        }
    }
}
