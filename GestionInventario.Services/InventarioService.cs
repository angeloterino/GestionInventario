using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionInventario.Data;
using GestionInventario.Models;

namespace GestionInventario.Services
{
    public class InventarioService
    {
        public List<Element> GetAllElements()
        {
            return Data.Data.GetAllElements().ToList();
        }
        public Element GetElementById(int id)
        {
            return Data.Data.GetElementById(id);
        }
        public bool SetElement(int id, Element obj)
        {
            return Data.Data.SetElement(id, obj);
        }
        public bool InsertElement(Element obj)
        {
            return Data.Data.InsertElement(obj);
        }
        public bool DeleteElement(int id)
        {
            return Data.Data.RemoveElementById(id);
        }
    }
}
