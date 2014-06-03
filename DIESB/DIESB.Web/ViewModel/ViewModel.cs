using DIESB.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIESB.Web.ViewModel
{
    public class ViewModel
    {
        public IList<UF> UFList { get; set; }
        public String Pesquisa { get; set; }
        public String SelectedUF { get; set; }
    }
}