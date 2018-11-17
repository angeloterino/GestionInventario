using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionInventario.Models;

namespace GestionInventario.Data
{
    public class Memory
    {
        public Element[] DataElements = {
            new Element { Id = 1, Name = "Coco en lata", Quantity = 0, Type = "Comida", ExpireDate = new DateTime(2020, 10, 10).ToShortDateString() },
            new Element { Id = 2, Name = "Salmón noruego", Quantity = 0, Type = "Comida", ExpireDate = new DateTime(2020, 10, 10).ToShortDateString() },
            new Element { Id = 3, Name = "Cerveza", Quantity = 0, Type = "Bebida", ExpireDate = new DateTime(2020, 10, 10).ToShortDateString() },
            new Element { Id = 4, Name = "Cola", Quantity = 0, Type = "Bebida", ExpireDate = new DateTime(2020, 10, 10).ToShortDateString() },
            new Element { Id = 5, Name = "Patatas fritas", Quantity = 0, Type = "Comida", ExpireDate = new DateTime(2020, 10, 10).ToShortDateString() }
        };
    }

    public class Data : IDisposable
    {
        public Data()
        {
            DDBB.ElementTable = new Memory().DataElements;
        }
        public Element[] GetAllElements()
        {
            return DDBB.ElementTable;
        }
        public Element GetElementById(int id)
        {
            return DDBB.ElementTable.Where(m => m.Id == id).FirstOrDefault();
        }
        public bool SetElement(int id, Element obj)
        {
            DDBB.ElementTable.SetValue(obj, Array.IndexOf(DDBB.ElementTable, obj));
            return true;
        }
        public bool InsertElement(Element obj)
        {
            Element[] aux = {obj};
            DDBB.ElementTable.Concat(aux);
            return true;
        }
        public bool RemoveElementById(int id)
        {
            DDBB.ElementTable = DDBB.ElementTable.Where(m => m.Id != id).ToArray();
            return true;
        }

        public void Dispose()
        {

        }
    }
    public static class DDBB
    {
        public static Element[] ElementTable { get; set; }
    }
}
