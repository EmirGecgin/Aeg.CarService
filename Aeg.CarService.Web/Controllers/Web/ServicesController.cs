using Aeg.CarService.Bll.Abstract;
using Aeg.CarService.Entity.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Aeg.CarService.Web.Controllers.Web
{
    [Authorize(Roles = "Admin")]
    public class ServicesController : Controller
    {
        private readonly Repository<Services> repoServices = new Repository<Services>();
        public ActionResult Index()
        {
            var services = repoServices.List().OrderByDescending(x => x.Id);
            return View(services);
        }
        [HttpPost]
        public ActionResult SaveServices(Services service, HttpPostedFileBase Image)
        {

            try
            {
                if (Image != null)
                {
                    string extension = Path.GetExtension(Image.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Image.FileName) + "_" + Guid.NewGuid() + extension;
                    string path = Server.MapPath("/Images/Service/") + fileName;
                    Image.SaveAs(path);
                    WebImage img = new WebImage(path);
                    img.Resize(285, 180, true, true);
                    img.Save(path);
                    service.Image = "/Images/Service/" + fileName;
                    repoServices.Insert(service);
                    TempData["OK"] = "Kayıt Başarılı";
                }


            }
            catch (Exception)
            {
                TempData["NO"] = "Kayıt Başarısız";
            }

            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult ServiceDelete(int id)
        {
            try
            {
                var service = repoServices.GetById(id);
                if (service != null)
                {
                    string path = Request.MapPath(service.Image);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    repoServices.Delete(service);
                    TempData["OK"] = "Silme Başarılı";
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["NO"] = "Silme Başarısız";
                return RedirectToAction("Index");
            }
        }
    }
}