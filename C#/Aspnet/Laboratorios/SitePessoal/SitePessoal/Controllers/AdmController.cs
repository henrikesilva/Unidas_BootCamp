﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SitePessoal.Models;
using System.ComponentModel.DataAnnotations;

namespace SitePessoal.Controllers
{
    public class AdmController : Controller
    {
        public ActionResult ListarContato()
        {
            var pathVirtual = "~/contatos.txt";
            var pathFisico = Server.MapPath(pathVirtual);

            if (string.IsNullOrEmpty(pathFisico))
            {
                throw new ValidationException();
            }

            List<Contato> contatos = new List<Contato>();
            Contato contato = null;

            using (var sr = new StreamReader(pathFisico))
            {
                while (sr.Peek() >= 0)
                {
                    var linha = sr.ReadLine();
                    var campos = linha.Split(';');

                    if(campos.Count() > 0)
                    {
                        contato = new Contato();

                        if (!string.IsNullOrEmpty(campos[0]))
                        {
                            contato.Nome = campos[0];
                        }

                        if (!string.IsNullOrEmpty(campos[1]))
                        {
                            contato.Email = campos[1];
                        }

                        if (!string.IsNullOrEmpty(campos[2]))
                        {
                            contato.Mensagem = campos[2];
                        }

                        if (!string.IsNullOrEmpty(campos[3]))
                        {
                            contato.Data = DateTime.Parse(campos[3]);
                        }
                        contatos.Add(contato);
                    }
                }
            }

            ViewBag.Contatos = contatos;
               
            return View();
        }
    }
}