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
        private static Element[] dataElements = {
            new Element { Id = 1, Name = "Coco en lata", Quantity = 0, Type = "Comida", ExpireDate = new DateTime(2020, 10, 10).ToShortDateString() },
            new Element { Id = 2, Name = "Salmón noruego", Quantity = 0, Type = "Comida", ExpireDate = new DateTime(2020, 10, 10).ToShortDateString() },
            new Element { Id = 3, Name = "Cerveza", Quantity = 0, Type = "Bebida", ExpireDate = new DateTime(2020, 10, 10).ToShortDateString() },
            new Element { Id = 4, Name = "Cola", Quantity = 0, Type = "Bebida", ExpireDate = new DateTime(2020, 10, 10).ToShortDateString() },
            new Element { Id = 5, Name = "Patatas fritas", Quantity = 0, Type = "Comida", ExpireDate = new DateTime(2020, 10, 10).ToShortDateString() }
        };
        
        public static Element[] DataElements { get => dataElements; set => dataElements = value; }
    }

    public static class Data 
    {
        public static Element[] GetAllElements()
        {
            return DDBB.ElementTable;
        }
        public static Element GetElementById(int id)
        {
            return DDBB.ElementTable.Where(m => m.Id == id).FirstOrDefault();
        }
        public static bool SetElement(int id, Element obj)
        {
            obj.Expired = DateTime.Parse(obj.ExpireDate) < DateTime.Now;
            Element auxObj = DDBB.ElementTable.Where(m => m.Id == id).First();
            obj.LessQuantity = auxObj.Quantity > obj.Quantity;
            DDBB.ElementTable.SetValue(obj, Array.IndexOf(DDBB.ElementTable, auxObj));
            return true;
        }
        public static bool InsertElement(Element obj)
        {
            obj.Id = DDBB.ElementTable.Max(m => m.Id) + 1;
            Element[] aux = {obj};
            DDBB.ElementTable = DDBB.ElementTable.Concat(aux).ToArray();
            return true;
        }
        public static bool RemoveElementById(int id)
        {
            DDBB.ElementTable = DDBB.ElementTable.Where(m => m.Id != id).ToArray();
            return true;
        }

    }
    public static class DDBB
    {
        public static Element[] ElementTable { get => Memory.DataElements; set => Memory.DataElements = value; }
    }
}
