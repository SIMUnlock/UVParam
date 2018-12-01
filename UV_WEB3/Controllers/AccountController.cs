using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Security.Claims;
using UV_WEB3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Web;
using UV_WEB3.Models;
using Microsoft.AspNetCore.Http;
using NETCore.Encrypt;

namespace UV_WEB3.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnURL)
        {
            if (returnURL != null)
                ViewData.Add("ReturnURL", returnURL);
            else
                ViewData.Add("ReturnURL", "");

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

            model.Password = EncryptProvider.Md5(model.Password);
            var usuario = (from usr in context.Usuarios where usr.Usuario == model.Usuario && usr.Password == model.Password
                       select usr ).FirstOrDefault() as Usuarios;

            if (usuario != null)
            {
                if (model.Usuario == usuario.Usuario && model.Password == usuario.Password)
                {
                   ;
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, model.Usuario));

                    var userIdentity = new ClaimsIdentity(claims, "login");
                    var principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync("PKAT", principal);

                    if (model.ReturnURL == null)
                        model.ReturnURL = "/Home/Index";

                    HttpContext.Session.SetString("nomUsuario", usuario.Nombre);
                    HttpContext.Session.SetString("apeUsuario", usuario.ApellidoPat);
                    HttpContext.Session.SetInt32("tipoUser", usuario.Tipo);
                    HttpContext.Session.SetInt32("idUser", usuario.IdUsuario);


                    InformesUsuarios LoginUsuario = new InformesUsuarios();
                    LoginUsuario.IdUsuario = usuario.IdUsuario;
                    LoginUsuario.Nombre = usuario.Nombre;
                    LoginUsuario.Password = usuario.Password;
                    LoginUsuario.Estatus = usuario.Estatus;
                    LoginUsuario.Fecha = DateTime.Now;
                    LoginUsuario.Usuario = usuario.Usuario;
                    context.Entry(LoginUsuario).CurrentValues.SetValues(context.InformesUsuarios);
                    context.InformesUsuarios.AsNoTracking();
                    await context.InformesUsuarios.AddAsync(LoginUsuario);
                    await context.SaveChangesAsync();
                    
                    return Redirect(model.ReturnURL);
                }
            }
            TempData["login"] = "Hola";

            return View();
        }

        bool LoginUser(string username, string password)
        {
            return true;
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("PKAT");
            HttpContext.Session.Clear();
            return Redirect("/Account/Login");
        }
    }
}