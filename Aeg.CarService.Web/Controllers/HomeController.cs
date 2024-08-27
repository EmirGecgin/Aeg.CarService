using Aeg.CarService.Bll.Abstract;
using Aeg.CarService.Entity.Web;
using System.Linq;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository<Slider> repoSlider = new Repository<Slider>();
        private readonly Repository<Announcements> repoAnnouncements = new Repository<Announcements>();
        private readonly Repository<Services> repoServices = new Repository<Services>();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Slider = repoSlider.List();
            ViewBag.Announcements = repoAnnouncements.List().FirstOrDefault();
            ViewBag.Services = repoServices.List();
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Deneme()
        {
            return View();
        }
    }
}
