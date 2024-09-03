using Aeg.CarService.Bll.Abstract;
using Aeg.CarService.Entity.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aeg.CarService.Web.Controllers.Web
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private readonly Repository<About> repoAbout = new Repository<About>();
        public ActionResult Index()
        {
            if (repoAbout.List().Count == 0)
            {
                About about = new About();
                about.Content = "Content is empty";
                about.Image = "Image is empty";
                about.Motto = "Motto is empty";
                repoAbout.Insert(about);
            }
            return View(repoAbout.List().FirstOrDefault());
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveAbout(About about,HttpPostedFileBase Image)
        {
            if (repoAbout.List().Count > 0)
            {
                string extension=Path.GetExtension(Image.FileName);
                string fileName = Path.GetFileNameWithoutExtension(Image.FileName)+"_"+Guid.NewGuid()+extension;
                string path=Server.MapPath("/Images/About/"+fileName);
                Image.SaveAs(path);
                var updated = repoAbout.List().FirstOrDefault();
                updated.Content = about.Content;
                updated.Motto = about.Motto;
                updated.Image = "/Images/About/" + fileName;
                repoAbout.Update(updated);
            }
            return RedirectToAction("Index");
        }
    }
}