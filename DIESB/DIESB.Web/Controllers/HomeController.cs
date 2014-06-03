using DIESB.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIESB.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index(ViewModel.ViewModel vm)
        {
            var list = new InstituicaoBO().GetByCursosSearch(vm.Pesquisa, vm.SelectedUF);
            return View(list);
        }
        //
        // GET: /Home/
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Pesquisa()
        {
            var ufs = new InstituicaoBO().GetUFS().OrderBy(x => x.Descricao).ToList();

            return View(new ViewModel.ViewModel
            {
                UFList = ufs
            });
        }
    }
}
