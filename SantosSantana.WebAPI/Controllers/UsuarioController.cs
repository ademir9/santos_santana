using SantosSantana.Dominio.Models;
using System;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SantosSantana.WebAPI.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
           
            
            return View();
        }

        
        public ActionResult Incluir()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Incluir(Usuario usuario)
        {

            return View();
        }
    }
}