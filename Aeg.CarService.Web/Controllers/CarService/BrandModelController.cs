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
            var brands = repoBrand.Get(x => x.IsDeleted == false).OrderBy(x => x.BrandName).ToList();
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
            var models = repoModel.Get(x => x.BrandId == Id).Select(x => new { x.Id, x.ModelName }).ToList();
            return Json(models, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ModelList(int id)
        {
            var brand = repoBrand.GetById(id);
            ViewBag.BrandName = brand.BrandName;
            ViewBag.BrandId = brand.Id;
            var models = repoModel.Get(x => x.BrandId == id && x.IsDeleted==false).ToList();
            return View(models);
        }
        public ActionResult CreateModel(Model model)
        {
            try
            {
                if (repoModel.Get(x => x.ModelName == model.ModelName && x.BrandId == model.BrandId).Any())
                {
                    TempData["NO"] = "Kayıt Başarısız, kayıtlı veri var.";
                    return RedirectToAction("ModelList", new { id = model.BrandId });
                }
                repoModel.Insert(model);
                TempData["OK"] = "Kayıt Başarılı";
                return RedirectToAction("ModelList", new { id = model.BrandId });
            }
            catch (Exception)
            {
                TempData["NO"] = "Kayıt Başarısız";
                return RedirectToAction("ModelList", new { id = model.BrandId });
            }

        }
        public ActionResult BrandDelete(int id)
        {
            try
            {
                var brand = repoBrand.GetById(id);
                brand.IsDeleted = true;
                repoBrand.Update(brand);
                TempData["OK"] = "Silme işlemi başarılı";

            }
            catch (Exception)
            {
                TempData["NO"] = "Silme işlemi başarısız";

            }
            return RedirectToAction("Index");

        }
        public ActionResult ModelDelete(int id)
        {
            var model = repoModel.GetById(id);
            try
            {
                model.IsDeleted = true;
                repoModel.Update(model);
                TempData["OK"] = "Silme işlemi başarılı";
            }
            catch (Exception)
            {
                TempData["NO"] = "Silme işlemi başarısız";
            }
            return RedirectToAction("ModelList", new {id=model.BrandId});

        }
    }
}