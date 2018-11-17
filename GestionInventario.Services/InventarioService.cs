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
            using (Data.Data data = new Data.Data())
            {
                return data.GetAllElements().ToList();
            }
        }
        public Element GetElementById(int id)
        {
            using (Data.Data data = new Data.Data())
            {
                return data.GetElementById(id);
            }
        }
        public bool SetElement(int id, Element obj)
        {
            using (Data.Data data = new Data.Data())
            {
                return data.SetElement(id, obj);
            }
        }
        public bool InsertElement(Element obj)
        {
            using (Data.Data data = new Data.Data())
            {
                return data.InsertElement(obj);
            }
        }
        public bool DeleteElement(int id)
        {
            using (Data.Data data = new Data.Data())
            {
                return data.RemoveElementById(id);
            }
        }
    }
}
