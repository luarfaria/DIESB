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
        public ActionResult Paginacao(int pagina)
        {
            Session["PAGINA"] = pagina;
            String uf = Session["UF"] == null? String.Empty : Session["UF"].ToString();
            Session["UF"] = uf;
            String pesquisa = Session["PESQUISA"] == null ? String.Empty : Session["PESQUISA"].ToString();
            Session["PESQUISA"] = pesquisa;
            var list = new InstituicaoBO().GetByCursosSearch(pesquisa, uf, pagina);
            return View("Index", list);
        }

        [HttpPost]
        public ActionResult Index(ViewModel.ViewModel vm)
        {
            Session["UF"] = vm.SelectedUF;
            Session["PESQUISA"] = vm.Pesquisa;
            var list = new InstituicaoBO().GetByCursosSearch(vm.Pesquisa, vm.SelectedUF, 1);
            return View(list);
        }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }


        public ActionResult Contato()
        {
            return View();
        }


        public ActionResult Pesquisa()
        {
            var ufs = new InstituicaoBO().GetUFS().OrderBy(x => x.Descricao).ToList();
            String pesquisa = Session["PESQUISA"] != null ? Session["PESQUISA"].ToString() : String.Empty;
            Session["PESQUISA"] = pesquisa;
            String uf = Session["UF"] == null ? String.Empty : Session["UF"].ToString();
            Session["UF"] = uf;
            return View(new ViewModel.ViewModel
            {
                UFList = ufs,
                Pesquisa = pesquisa,
                SelectedUF = uf
            });
        }
    }
}
