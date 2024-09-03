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
    public class SliderController : Controller
    {
        private readonly Repository<Slider> repoSlider = new Repository<Slider>();
        public ActionResult Index()
        {
            var slider=repoSlider.List().OrderByDescending(x=>x.Id);
            return View(slider);
        }
        //public JsonResult GetSliders()
        //{
        //    var sliders = repoSlider.List().OrderByDescending(x => x.Id).ToList();
        //    return Json(sliders, JsonRequestBehavior.AllowGet);
        //}ajax ile veri çekme
        public ActionResult SliderSave(Slider slider, HttpPostedFileBase image)
        {
            try
            {
                if (image != null)
                {
                    string extension = Path.GetExtension(image.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(image.FileName) + "_" + Guid.NewGuid();
                    string fullName = fileName + extension;
                    string path = Server.MapPath("/Images/Slider/") + fullName;
                    image.SaveAs(path);
                    string dbPath = "/Images/Slider/" + fullName;
                    slider.Image = dbPath;
                    repoSlider.Insert(slider);
                    TempData["OK"]= "Kayıt Başarılı";
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["NO"] = "Kayıt Başarısız";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult SliderDelete(int id)
        {
            try
            {
                var slider = repoSlider.GetById(id);
                if (slider != null)
                {
                    string path = Request.MapPath(slider.Image);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    repoSlider.Delete(slider);
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