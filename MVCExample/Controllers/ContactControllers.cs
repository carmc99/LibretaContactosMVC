using MVCExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample.Controllers
{
    /// <summary> 
    /// Clase para gestionar el flujo de informacion entre el modelo y la vista
    /// </summary>
    public class ContactControllers
    {
        List<Contact> contacts;
        public ContactControllers()
        {
            contacts = new List<Contact>();
        }

        public List<Contact> Contacts (){
            return contacts;
        }

        /// <summary> 
        /// Elimina un elemento de la lista
        /// </summary>
        /// <param name="contact">
        /// Un objecto de la clase Contact
        /// </param>
        ///  <return>
        /// Verdadero: al crearse el registro, Falso: si este no se logro crear
        /// </return>
        public bool create(Contact contact)
        {
            if(contact.Phone.Length > 0 && contact.Name.Length > 0)
            {
                contacts.Add(new Contact
                {
                    Name = contact.Name,
                    LastName = contact.LastName,
                    Addres = contact.Addres,
                    Phone = contact.Phone
                });
                return true;
            }
            Console.WriteLine("Contact information not valid");
            return false;
        }

        /// <summary> 
        /// Elimina un elemento de la lista
        /// </summary>
        /// <param name="phone">
        /// Clave con la cual se buscara el contacto
        /// </param>
        public bool delete(string phone)
        {
            Contact contact = contacts.Find(item => item.Phone == phone );
            if(contact != null)
            {
                contacts.Remove(contact);
                return true;
            }
            Console.WriteLine("Contact no found");
            return false;
        }

    }
}
