using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionInventario.Services;
using GestionInventario.Models;

namespace GestionInventario.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View( new InventarioService().GetAllElements());
        }

        public PartialViewResult GetElementTable()
        {
            return PartialView("~/Views/Partial/_ElementTable.cshtml", new InventarioService().GetAllElements());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public PartialViewResult GetElementForm(string id)
        {
            int _id = int.TryParse(id, out _id) ? _id : 0;
            Element model = _id == 0? new Element(): new InventarioService().GetElementById(_id);
            return PartialView("~/Views/Partial/_ElementForm.cshtml", model);
        }
    }
}