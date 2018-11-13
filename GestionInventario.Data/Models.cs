using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventario.Data.Models
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ExpireDate { get; set; }
        public int Quantity { get; set; }
    }
}
