using Aeg.CarService.Bll.Abstract;
using Aeg.CarService.Entity.CarService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aeg.CarService.Web.Controllers.CarService
{
    public class BrandModelController : Controller
    {
       private readonly Repository<Brand> repoBrand = new Repository<Brand>();
       private readonly Repository<Model> repoModel = new Repository<Model>();
        public ActionResult Index()
        {
            var brands=repoBrand.Get().OrderBy(x=>x.BrandName).ToList();
            return View(brands);
        }
        public ActionResult CreateBrand(Brand brand)
        {
            try
            {
                if (repoBrand.Get(x => x.BrandName == brand.BrandName).Any())
                {
                    TempData["NO"] = "Kayıt Başarısız, kayıtlı veri var.";
                    return RedirectToAction("Index");
                }
                repoBrand.Insert(brand);
                TempData["OK"] = "Kayıt Başarılı";
            }
            catch (Exception)
            {
                TempData["NO"] = "Kayıt Başarısız";
            }
            return RedirectToAction("Index");
        }
        public JsonResult GetModels(int Id)
        {
            var models = repoModel.Get(x => x.BrandId == Id).Select(x => new {x.Id,x.ModelName}).ToList();
            return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
}