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
            if (Session["Data"] == null)
            {
                InventarioService service = new InventarioService();
                Session["Data"] = service.GetAllElements();
            }
            return View(Session["Data"]);
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