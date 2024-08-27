using Aeg.CarService.Bll.Abstract;
using Aeg.CarService.Entity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aeg.CarService.Web.Controllers.Web
{
    public class AnnouncementsController : Controller
    {
        private readonly Repository<Announcements> repoAnnouncements = new Repository<Announcements>();
        public ActionResult Index()
        {
            if(repoAnnouncements.List().Count==0)
            {
                Announcements announcement = new Announcements();
                announcement.Content = "Content is empty";
                repoAnnouncements.Insert(announcement);
            }
            var announcements = repoAnnouncements.List().FirstOrDefault();
            return View(announcements);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveAnnouncements(Announcements announcements)
        {
            if (repoAnnouncements.List().Count > 0)
            {
                var updated = repoAnnouncements.List().FirstOrDefault();
                updated.Content= announcements.Content;
                repoAnnouncements.Update(updated);
            }
            return RedirectToAction("Index");
        }
        
    }
}