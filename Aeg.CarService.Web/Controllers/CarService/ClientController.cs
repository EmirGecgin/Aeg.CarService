using Aeg.CarService.Bll.Abstract;
using Aeg.CarService.Entity.CarService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aeg.CarService.Web.Controllers.CarService
{
    public class ClientController : Controller
    {
        private readonly Repository<Client> repoClient=new Repository<Client>();
        public ActionResult Index()
        {
            return View(repoClient.Get().OrderByDescending(x => x.Id).Take(20).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {
                repoClient.Insert(client);
                TempData["OK"] = "Kayıt Başarılı";
            }
            catch (Exception)
            {
                TempData["NO"] = "Kayıt Başarısız";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            var client= repoClient.GetById(Id);
            ViewBag.Title = client.NameSurname + "'s Information Edit";
            return View(client);
        }
        [HttpPost]
        public ActionResult Edit(Client client,int id)
        {
            try
            {
               var updatedClient= repoClient.GetById(id);
                updatedClient.NameSurname= client.NameSurname;
                updatedClient.PhoneNumber = client.PhoneNumber;
                updatedClient.Email = client.Email;
                updatedClient.Address = client.Address;
                repoClient.Update(updatedClient);
                TempData["OK"] = "Kayıt Başarılı";
            }
            catch (Exception)
            {
                TempData["NO"] = "Kayıt Başarısız";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ClientDelete(int id)
        {
            try
            {
                repoClient.Delete(repoClient.GetById(id));
                TempData["OK"] = "Silme İşlemi Başarılı";
            }
            catch (Exception)
            {
                TempData["NO"] = "Silme İşlemi Başarısız";
            }
            return RedirectToAction("Index");
        }
    }
}