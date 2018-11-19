using GestionInventario.Models;
using GestionInventario.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace GestionInventario.Controllers
{
    public class AppController : ApiController
    {
        // GET: api/App
        public IEnumerable<Element> Get()
        {
            return new InventarioService().GetAllElements();
        }
        // GET: api/App/5
        public Element Get(int id)
        {
            return new InventarioService().GetElementById(id);
        }

        // POST: api/App
        public string Post([FromBody]Element value)
        {
            string message = "";
            bool success = false;
            if (ValidateElement(ref message, value))
            {
                if(value.Id > 0)
                    success = new InventarioService().SetElement(value.Id, value);
                else
                    success = new InventarioService().InsertElement(value);
            }
            return JsonConvert.SerializeObject(new { success = success, message = message });
        }

        // PUT: api/App/5
        public string Put(int id, [FromBody]Element value)
        {
            string message = "";
            bool success = false;
            if (ValidateElement(ref message, value))
            {
                new InventarioService().SetElement(id, value);
            }
            return JsonConvert.SerializeObject(new { success = success, message = message });
        }

        // DELETE: api/App/5
        public void Delete(int id)
        {
            new InventarioService().DeleteElement(id);
        }

        private bool ValidateElement(ref string message, Element element)
        {
            if(string.IsNullOrEmpty(element.Name) || string.IsNullOrEmpty(element.ExpireDate))
            {
                message = "Los campos Nombre y Fecha de Caducidad no pueden ser nulos.";
                return false;
            }
            if(!DateTime.TryParse(element.ExpireDate, out DateTime result))
            {
                message = "El campo Fecha de Caducidad tiene un formato de fecha no válido.";
                return false;
            }
            return true;
        }
    }
}
