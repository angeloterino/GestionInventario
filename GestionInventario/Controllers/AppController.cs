using GestionInventario.Models;
using GestionInventario.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public void Post([FromBody]Element value)
        {
            new InventarioService().SetElement(value.Id, value);
        }

        // PUT: api/App/5
        public void Put(int id, [FromBody]Element value)
        {
            new InventarioService().InsertElement(value);
        }

        // DELETE: api/App/5
        public void Delete(int id)
        {
            new InventarioService().DeleteElement(id);
        }
    }
}
