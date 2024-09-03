using Aeg.CarService.Bll.Abstract;
using Aeg.CarService.Entity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aeg.CarService.Web.Controllers.Web
{
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        private readonly Repository<Blog> repoBlog= new Repository<Blog>();
        public ActionResult Index()
        {
            var blogs = repoBlog.List().OrderByDescending(x => x.Id);
            return View(blogs);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Blog blog)
        {
            try
            {
                blog.Date = DateTime.Now;
                repoBlog.Insert(blog);
                TempData["OK"] = "Blog başarıyla kaydedildi.";
            }
            catch (Exception)
            {
                TempData["NO"] = "Blog kaydedilemedi!";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(repoBlog.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                repoBlog.Delete(repoBlog.GetById(id));
                TempData["OK"] = "Blog başarıyla silindi.";
            }
            catch (Exception)
            {
                TempData["NO"] = "Blog silinemedi!";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var blog = repoBlog.GetById(id);
            return View(blog);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Blog blog)
        {
            try
            {
                blog.Date = DateTime.Now;
                repoBlog.Update(blog);
                TempData["OK"] = "Blog başarıyla güncellendi.";
            }
            catch (Exception)
            {
                TempData["NO"] = "Blog güncellenemedi!";
            }
            return RedirectToAction("Index");
        }
    }
}