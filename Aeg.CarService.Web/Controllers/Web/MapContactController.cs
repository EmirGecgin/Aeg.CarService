using Aeg.CarService.Bll.Abstract;
using Aeg.CarService.Entity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aeg.CarService.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MapContactController : Controller
    {
        private readonly Repository<MapContact> repoMapContact= new Repository<MapContact>();
        public ActionResult Index()
        {
            if (repoMapContact.List().Count == 0)
            {
                MapContact mapContact = new MapContact();
                mapContact.Map = "-";
                mapContact.Contact = "-";
                repoMapContact.Insert(mapContact);
            }
            return View(repoMapContact.List().FirstOrDefault());
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult MapContactSave(MapContact mapContact)
        {
            try
            {
                if (repoMapContact.List().Count > 0)
                {
                    var updated = repoMapContact.List().FirstOrDefault();
                    updated.Contact = mapContact.Contact;
                    updated.Map = mapContact.Map;
                    repoMapContact.Update(updated);
                }
                TempData["OK"] = "Map ve Contact başarıyla güncellendi.";
            }
            catch (Exception)
            {
                TempData["NO"] = "Map ve Contact güncellenemedi."; ;
            }
            
            return RedirectToAction("Index");
        }
    }
}