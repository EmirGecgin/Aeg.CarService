using Aeg.CarService.Bll.Abstract;
using Aeg.CarService.Entity.CarService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Aeg.CarService.Web.Controllers.CarService
{
    public class WorkOrderController : Controller
    {
        private readonly Repository<Client> repoClient = new Repository<Client>();
        public ActionResult Index(string search)
        {
            if (search == "" || search == null)
            {
                var clients = repoClient.Get().OrderByDescending(x => x.Id).Take(20).ToList();
                return View(clients);
            }
            var searchClients = repoClient.Get(x => x.NameSurname.Contains(search) || x.PhoneNumber.Contains(search)).ToList();
            return View(searchClients);
        }
        public ActionResult CreateWorkOrder(int Id)
        {
            return View();
        }
    }
}