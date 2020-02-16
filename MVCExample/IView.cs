using MVCExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCExample
{
    interface IView
    {
        void LoadData();
        void ClearInput();
        void CreateHeadersListView();

    }
}
