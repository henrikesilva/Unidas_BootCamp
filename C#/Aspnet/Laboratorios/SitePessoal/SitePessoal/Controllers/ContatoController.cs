using SitePessoal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace SitePessoal.Controllers
{
    public class ContatoController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Concluido = false;

            return View();
        }

        [HttpPost]
        public ActionResult Salvar(Contato contato)
        {
            try
            {
                if (string.IsNullOrEmpty(contato.Email)
                    || string.IsNullOrEmpty(contato.Nome)
                    || string.IsNullOrEmpty(contato.Mensagem))
                {
                    throw new ValidationException("Favor preencher todo o formulário");
                }

                var pathVirtual = "~/contatos.txt";
                var pathFisico = Server.MapPath(pathVirtual);
                
                using (var sw = new StreamWriter(pathFisico, true))
                {
                    sw.Write(contato.Nome + ";");
                    sw.Write(contato.Email + ";");
                    sw.Write(contato.Mensagem + ";");
                    sw.Write(DateTime.Now + ";\n");
                }

                ViewBag.Concluido = true;
            }
            catch (ValidationException ve)
            {
                ViewBag.ErroMsg = ve.Message;
                ViewBag.Concluido = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ViewBag.ErroMsg = "Ocorreu um erro ao salvar o arquivo, entre em contato com o administrador do sistema.";
                ViewBag.Concluido = false;
            }
            return View("Index");
        }
    }
}