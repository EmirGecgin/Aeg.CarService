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
        private readonly Repository<About> repoAbout = new Repository<About>();
        private readonly Repository<Blog> repoBlog = new Repository<Blog>();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Slider = repoSlider.List();
            ViewBag.Announcements = repoAnnouncements.List().FirstOrDefault();
            ViewBag.Services = repoServices.List();
            ViewBag.Blogs = repoBlog.Get().OrderByDescending(x=>x.Id).Take(4).ToList();
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.About = repoAbout.List().FirstOrDefault();
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
        public ActionResult BlogDetails(int id)
        {
            var blog = repoBlog.GetById(id);
            return View(blog);
        }
    }
}
