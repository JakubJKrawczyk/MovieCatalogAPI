using Microsoft.AspNetCore.Mvc;

namespace MovieCatalog___Practice_Quest.Controllers
{
    [ApiController, Route("/")]
    public class MovieCatalogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
