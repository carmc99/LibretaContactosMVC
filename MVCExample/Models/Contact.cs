using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Models
{
    /// <summary> 
    /// Clase para representar la logica de negocio
    /// </summary>
    public class Contact
    {

        public string Name { set; get; }
        public string LastName { set; get; }
        public string Addres { set; get; }
        public string Phone { set; get; }
        public Contact()
        {

        }
    }
}
