using SiteEmpresarial.Db;
using SiteEmpresarial.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteEmpresarial.Controllers
{
    public class HomeController : Controller
    {
        private ContatoDb ObterDbContext()
        {
            return new ContatoDb();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuemSomos()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contato(Contato contato)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ValidationException("Favor preencher todos os campos obrigatórios");
                }

                using (var db = ObterDbContext())
                {
                    var existeContato = db.Contatos.Where(c => c.Email == contato.Email && c.Nome == contato.Nome).Any();

                    if (existeContato)
                    {
                        throw new ValidationException("Contato inserido já cadastrado, tente outras informações");
                    }

                    db.Contatos.Add(contato);
                    db.SaveChanges();
                }

                return View("ContatoOk");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(contato);
            }
        }
    }
}