using MVCExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample
{
    /// <summary> 
    /// Clase para representar la logica de negocio
    /// </summary>
    interface IView
    {
        void LoadData();
        void ClearInput();
        void CreateHeadersListView();

    }
}
