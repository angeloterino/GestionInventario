using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventario.Models
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ExpireDate { get; set; }
        public bool Expired { get; set; }
        public int Quantity { get; set; }
        public List<String> TypeOptions { get{ return new List<String>{ "Comida", "Bebida" }; } }
    }
}
