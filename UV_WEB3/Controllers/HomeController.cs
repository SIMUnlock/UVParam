using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETCore.Encrypt;
using Newtonsoft.Json;
using UV_WEB3.Models;
using Vereyon.Web;

namespace UV_WEB3.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Root()
        {


            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        public IActionResult Index()
        {

            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;



            var list = from e in context.Estaciones select e;


            return View(list);
        }

        

        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> GetStations()
        {

            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

            var results = await
       (from e in context.Estaciones
        where e.Estatus == 1
        select new
        {
            IdEstacion = e.IdEstacion,
            Nombre = e.Nombre,
            Latitud = e.Latitud,
            Longitud = e.Longitud,
            Estatus = e.Estatus

        }).ToListAsync();



            return Json(results);

        }
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]

        [Authorize]
        [HttpGet]
        public async Task<JsonResult> GetStations2()
        {

            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

            var results = await
       (from e in context.Estaciones
        where e.Estatus == 1
        select new
        {
            IdEstacion = e.IdEstacion,
            Nombre = e.Nombre,
            Latitud = e.Latitud,
            Longitud = e.Longitud,
            Estatus = e.Estatus

        }).ToListAsync();


            return Json(results);

        }



        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> GetStationsOne(int? id)
        {

            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

            var results = await
(from e in context.Estaciones
 where e.Estatus == 1 && e.IdEstacion == id
 select new
 {
     IdEstacion = e.IdEstacion,
     Nombre = e.Nombre,
     Latitud = e.Latitud,
     Longitud = e.Longitud,
     Estatus = e.Estatus

 }).ToListAsync();



            return Json(results);

        }



        [Authorize]
        public async Task<int> LongRunningOperationAsync()
        {
            await Task.Delay(5000);
            return 1;
        }

        [Authorize]
        public IActionResult verUsuarios()
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {

                return View();
            }
            return NotFound();
        }


        [Authorize]
        [HttpPost]
        public JsonResult LoadData()
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;
            var list = from e in context.Usuarios select e;

            return Json(list);

        }


        [Authorize]
        [HttpPost]
        public JsonResult desactivateUser(int? id)
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {

                var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

                if (id == null)
                    return Json(data: "No desactivado");

                var user = context.Usuarios.FirstOrDefault(usr => usr.IdUsuario == id) as Usuarios;
                user.Estatus = 2;
                context.Usuarios.Update(user);
                context.SaveChanges();
                return Json(data: "Desactivado");
            }
            return Json(data: "Sin Permisos");

        }


        [Authorize]
        [HttpPost]
        public JsonResult activateUser(int? id)
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {

                var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

                if (id == null)
                    return Json(data: "No activado");

                var user = context.Usuarios.FirstOrDefault(usr => usr.IdUsuario == id) as Usuarios;
                user.Estatus = 1;
                context.Usuarios.Update(user);
                context.SaveChanges();
                return Json(data: "Activado");
            }
            return Json(data: "Sin Permisos");


        }


        [Authorize]
        [HttpGet]
        public ActionResult editarUsuario(int? id)
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            var idUsuario = HttpContext.Session.GetInt32("idUser");
            if (type == 1)
            {

                var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

                if (context.Usuarios.Where(s => s.IdUsuario == id).First() is Usuarios e)
                    return View(e);
                else
                    return NotFound();
            }
            else
            {
               
                    return NotFound();
            }
        }


        [Authorize]
        [HttpPost]
        public IActionResult Edit(Usuarios e)
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;


            // Retrieve entity by id
            // Answer for question #1
            var entity = context.Usuarios.FirstOrDefault(usr => usr.IdUsuario == e.IdUsuario);

            // Validate entity is not null
            if (entity != null)
            {
                // Answer for question #2

                // Make changes on entity
                entity.Nombre = e.Nombre;
                entity.ApellidoPat = e.ApellidoPat;
                entity.ApellitoMat = e.ApellitoMat;
                entity.Password = EncryptProvider.Md5(e.Password);
                entity.Tipo = e.Tipo;
                entity.Usuario = e.Usuario;


                // Update entity in DbSet
                context.Usuarios.Update(entity);

                // Save changes in database
                context.SaveChanges();

            }
            return RedirectToAction("verUsuarios", "Home");

        }


        [Authorize]
        [HttpPost]
        public IActionResult CrearUsuario(Usuarios e)
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

            var usuarioExistente = context.Usuarios.FirstOrDefault(usr => usr.Usuario == e.Usuario);
            if (usuarioExistente == null)
            {
                e.Estatus = 1;
                e.Password= EncryptProvider.Md5(e.Password);
                context.Usuarios.Add(e);
                context.SaveChanges();
                return RedirectToAction("verUsuarios", "Home");
            }
            else
            {
                TempData["mensaje"] = "Hola";
                return RedirectToAction("CrearUsuario", "Home");
            }
           


        }

        [Authorize]
        public IActionResult CrearUsuario()
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {

                return View();
            }
            return NotFound();
        }

        [Authorize]
        public IActionResult verDatos()
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {

                var list = from e in context.Datos select e;


                return View(list);
            }
            return NotFound();
        }


        [Authorize]
        [HttpPost]
        public JsonResult desactivateData(int? id)
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {
                var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

                if (id == null)
                    return Json(data: "No desactivado");

                var datos = context.Datos.FirstOrDefault(usr => usr.IdDato == id) as Datos;
                datos.Estatus = 2;
                context.Datos.Update(datos);
                context.SaveChanges();
                return Json(data: "Desactivado");
            }
            return Json(data: "Sin Permisos");

        }


        [Authorize]
        [HttpPost]
        public JsonResult activateData(int? id)
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {
                var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

                if (id == null)
                    return Json(data: "No activado");

                var datos = context.Datos.FirstOrDefault(usr => usr.IdDato == id) as Datos;
                datos.Estatus = 1;
                context.Datos.Update(datos);
                context.SaveChanges();
                return Json(data: "Activado");
            }
            return Json(data: "Sin Permisos");

        }


        [Authorize]
        [HttpGet]
        public ActionResult editarDato(int? id)
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {

                var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

                if (context.Datos.Where(s => s.IdDato == id).First() is Datos e)
                    return View(e);
                else
                    return NotFound();
            }
            return NotFound();
        }



        [Authorize]
        [HttpPost]
        public IActionResult editarDato(Datos e)
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;
            var entity = context.Datos.FirstOrDefault(usr => usr.IdDato == e.IdDato);

            if (entity != null)
            {
                entity.Nombre = e.Nombre;
                entity.UnidadMedida = e.UnidadMedida;
                context.Datos.Update(entity);
                context.SaveChanges();

            }
            return RedirectToAction("verDatos", "Home");

        }

        [Authorize]
        public IActionResult crearDato()
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {

                return View();
            }
            return NotFound();
        }



        [Authorize]
        [HttpPost]
        public IActionResult crearDato(Datos e)
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

            e.Estatus = 1;
            context.Datos.Add(e);
            context.SaveChanges();
            return RedirectToAction("verDatos", "Home");


        }

        [Authorize]
        public IActionResult verEquipos()
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {

                var list = from e in context.Equipos select e;


                return View(list);
            }
            return NotFound();

        }



        [Authorize]
        [HttpPost]
        public JsonResult desactivateEquip(int? id)
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {
                var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

                if (id == null)
                    return Json(data: "No desactivado");

                var datos = context.Equipos.FirstOrDefault(usr => usr.IdEquipo == id) as Equipos;
                datos.Estatus = 2;
                context.Equipos.Update(datos);
                context.SaveChanges();
                return Json(data: "Desactivado");
            }
            return Json(data: "Sin Permisos");

        }


        [Authorize]
        [HttpPost]
        public JsonResult activateEquip(int? id)
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {
                var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

                if (id == null)
                    return Json(data: "No activado");

                var datos = context.Equipos.FirstOrDefault(usr => usr.IdEquipo == id) as Equipos;
                datos.Estatus = 1;
                context.Equipos.Update(datos);
                context.SaveChanges();
                return Json(data: "Activado");
            }
            return Json(data: "Sin Permisos");

        }


        [Authorize]
        [HttpGet]
        public ActionResult editarEquipo(int? id)
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {

                var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

                if (context.Equipos.Where(s => s.IdEquipo == id).First() is Equipos e)
                    return View(e);
                else
                    return NotFound();
            }
            return NotFound();
        }



        [Authorize]
        [HttpPost]
        public IActionResult editarEquipo(Equipos e)
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;
            var entity = context.Equipos.FirstOrDefault(usr => usr.IdEquipo == e.IdEquipo);

            if (entity != null)
            {
                entity.Modelo = e.Modelo;
                entity.NoSerial = e.NoSerial;
                entity.Rango = e.Rango;
                entity.Presicion = e.Presicion;
                entity.Resolucion = e.Resolucion;
                entity.Estabilidad = e.Estabilidad;

                context.Equipos.Update(entity);
                context.SaveChanges();

            }
            return RedirectToAction("verEquipos", "Home");

        }

        [Authorize]
        public IActionResult crearEquipo()
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {

                return View();
            }
            return NotFound();
        }



        [Authorize]
        [HttpPost]
        public IActionResult crearEquipo(Equipos e)
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

            e.Estatus = 1;
            context.Equipos.Add(e);
            context.SaveChanges();
            return RedirectToAction("verEquipos", "Home");


        }

        [Authorize]
        public IActionResult verEstaciones()
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {

                var list = from e in context.Estaciones select e;


                return View(list);
            }
            return NotFound();

        }



        [Authorize]
        [HttpPost]
        public JsonResult desactivateEstacion(int? id)
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {
                var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

                if (id == null)
                    return Json(data: "No desactivado");

                var datos = context.Estaciones.FirstOrDefault(usr => usr.IdEstacion == id) as Estaciones;
                datos.Estatus = 2;
                context.Estaciones.Update(datos);
                context.SaveChanges();
                return Json(data: "Desactivado");
            }
            return Json(data: "Sin Permisos");

        }


        [Authorize]
        [HttpPost]
        public JsonResult activateEstacion(int? id)
        {

            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {
                var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

                if (id == null)
                    return Json(data: "No activado");

                var datos = context.Estaciones.FirstOrDefault(usr => usr.IdEstacion == id) as Estaciones;
                datos.Estatus = 1;
                context.Estaciones.Update(datos);
                context.SaveChanges();
                return Json(data: "Activado");
            }
            return Json(data: "Sin Permisos");


        }

        [Authorize]
        [HttpGet]
        public ActionResult editarEstacion(int? id)
        {


            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {


                if (context.Estaciones.Where(s => s.IdEstacion == id).First() is Estaciones e)
                    return View(e);
                else
                    return NotFound();
            }
            return NotFound();

        }



        [Authorize]
        [HttpPost]
        public IActionResult editarEstacion(Estaciones e)
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;
            var entity = context.Estaciones.FirstOrDefault(usr => usr.IdEstacion == e.IdEstacion);

            if (entity != null)
            {
                entity.Nombre = e.Nombre;
                entity.Latitud = e.Latitud;
                entity.Longitud = e.Longitud;


                context.Estaciones.Update(entity);
                context.SaveChanges();

            }
            return RedirectToAction("verEstaciones", "Home");

        }


        [Authorize]
        public IActionResult nuevaEstacion()
        {
            return View();

        }

        [Authorize]
        [HttpPost]
        public IActionResult nuevaEstacion(Estaciones e)
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

            e.Estatus = 1;
            context.Estaciones.Add(e);
            context.SaveChanges();

            return RedirectToAction("verEstaciones", "Home");

        }

        [Authorize]
        public IActionResult detalleEstacion(int? id)
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

            ViewBag.id = id;
            var Estacion = context.Estaciones.FirstOrDefault(est => est.IdEstacion == id);
            if (Estacion == null)
                return NotFound();
            ViewBag.nombreEstacion = Estacion.Nombre;
            ViewBag.latitud = Estacion.Latitud;
            ViewBag.longitud = Estacion.Longitud;
            ViewBag.parametros = context.Datos.Where(pr => pr.Nombre != "Presion").Select(parm => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = parm.Nombre,
                Value = parm.Nombre.ToString()
            });

            ViewBag.equipos = context.Equipos.Where(equi => equi.Estatus == 1).Select(parm => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = parm.Modelo,
                Value = parm.IdEquipo.ToString()
            });

            return View();



        }


        [Authorize]
        [HttpGet]
        public async Task<JsonResult> detalleEstacionGet(int id)
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;
            var list = await (from reg in context.Registros
                              join dat in context.Datos on reg.IdDato equals dat.IdDato
                              join est in context.Estaciones on reg.IdEstacion equals est.IdEstacion
                              join equip in context.Equipos on reg.IdEquipo equals equip.IdEquipo
                              where reg.IdEstacion == id && reg.Profundidad % 5 == 0 && dat.Nombre != "Presion"
                              select new
                              {
                                  id = reg.IdRegistro,
                                  noLance = reg.NoLance,
                                  valor = reg.Valor,
                                  nomDato = dat.Nombre,
                                  profundidad = reg.Profundidad,
                                  fechaLance = reg.FechaLance,
                                  hora = reg.Hora,
                                  nomEstacion = est.Nombre,
                                  nomEquipo = equip.Modelo,
                                  estatus = reg.Estatus
                              }).ToListAsync();



            return Json(list);

        }


        [Authorize]
        [HttpPost]
        public JsonResult getSpecificParam(int id)
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;
            var list = (from reg in context.Registros
                        where reg.IdRegistro == id
                        select new
                        {
                            id = reg.IdRegistro,
                            noLance = reg.NoLance,
                            valor = reg.Valor,

                            idDato = reg.IdDato,
                            profundidad = reg.Profundidad,
                            fechaLance = reg.FechaLance,
                            hora = reg.Hora,

                            idEstacion = reg.IdEstacion,

                            idEquipo = reg.IdEquipo,
                            estatus = reg.Estatus
                        });


            var dato = (from datos in context.Datos
                        where datos.Nombre != "Presion"
                        select new
                        {
                            id = datos.IdDato,
                            nombre = datos.Nombre
                        }).ToList();
            var StringFinal = "";
            foreach (var str in dato)
            {
                if (str.id == list.First().idDato)
                {
                    StringFinal = StringFinal + "<option selected value='" + str.id + "'>" + str.nombre + "</option>";
                }
                else
                    StringFinal = StringFinal + "<option value='" + str.id + "'>" + str.nombre + "</option>";
            };
            //Estacion
            var estacion = (from est in context.Estaciones
                            select new
                            {
                                id = est.IdEstacion,
                                nombre = est.Nombre
                            }).ToList();
            var StringFinalEst = "";
            foreach (var str in estacion)
            {
                if (str.id == list.First().idEstacion)
                {
                    StringFinalEst = StringFinalEst + "<option selected value='" + str.id + "'>" + str.nombre + "</option>";
                }
                else
                    StringFinalEst = StringFinalEst + "<option value='" + str.id + "'>" + str.nombre + "</option>";
            };

            //Equipo
            var equipo = (from est in context.Equipos
                          select new
                          {
                              id = est.IdEquipo,
                              nombre = est.Modelo,
                          }).ToList();
            var StringFinalEqu = "";
            foreach (var str in equipo)
            {
                if (str.id == list.First().idEquipo)
                {
                    StringFinalEqu = StringFinalEqu + "<option selected value='" + str.id + "'>" + str.nombre + "</option>";
                }
                else
                    StringFinalEqu = StringFinalEqu + "<option value='" + str.id + "'>" + str.nombre + "</option>";
            };

            var result = new { param = list, datos = StringFinal, estacion = StringFinalEst, equipo = StringFinalEqu };

            return Json(result);

        }

        [Authorize]
        [HttpPost]
        public JsonResult getImportantData()
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;



            var dato = (from datos in context.Datos
                        where datos.Nombre != "Presion"
                        select new
                        {
                            id = datos.IdDato,
                            nombre = datos.Nombre
                        }).ToList();
            var StringFinal = "";
            foreach (var str in dato)
            {

                StringFinal = StringFinal + "<option value='" + str.id + "'>" + str.nombre + "</option>";
            };
            //Estacion
            var estacion = (from est in context.Estaciones
                            select new
                            {
                                id = est.IdEstacion,
                                nombre = est.Nombre
                            }).ToList();
            var StringFinalEst = "";
            foreach (var str in estacion)
            {

                StringFinalEst = StringFinalEst + "<option value='" + str.id + "'>" + str.nombre + "</option>";
            };

            //Equipo
            var equipo = (from est in context.Equipos
                          select new
                          {
                              id = est.IdEquipo,
                              nombre = est.Modelo,
                          }).ToList();
            var StringFinalEqu = "";
            foreach (var str in equipo)
            {

                StringFinalEqu = StringFinalEqu + "<option value='" + str.id + "'>" + str.nombre + "</option>";
            };

            var result = new { datos = StringFinal, estacion = StringFinalEst, equipo = StringFinalEqu };

            return Json(result);

        }



        [Authorize]
        [HttpGet]
        public JsonResult UpdateSpecificParam(String myjson)
        {

            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {
                var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

                Registros registros = JsonConvert.DeserializeObject<Registros>(myjson);
                // Retrieve entity by id
                // Answer for question #1
                var entity = (from reg in context.Registros
                              where reg.IdRegistro == registros.IdRegistro
                              select reg).First();

                // Validate entity is not null
                if (entity != null)
                {
                    entity.IdRegistro = registros.IdRegistro;
                    entity.IdEstacion = registros.IdEstacion;
                    entity.IdEquipo = registros.IdEquipo;
                    entity.Hora = registros.Hora;
                    entity.FechaLance = registros.FechaLance;
                    entity.Valor = registros.Valor;
                    entity.Profundidad = registros.Profundidad;
                    entity.IdDato = registros.IdDato;
                    entity.NoLance = registros.NoLance;
                    context.Registros.Update(entity);

                    // Save changes in database
                    context.SaveChanges();
                    return Json(new { data = true, url = "/Home/detalleEstacion/" + registros.IdEstacion });
                }
            }
            return Json(new { data = false, url = "" });

        }

        [Authorize]
        [HttpGet]
        public JsonResult RequestSpecificData(string myjson)
        {

            var type = HttpContext.Session.GetInt32("tipoUser");

            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;


            if (type == 3)
            {

                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(myjson);

                string nombredato = jsonObj["idDato"];
                var dato = (from e in context.Datos where nombredato == e.Nombre select e).First() as Datos;
                jsonObj["idDato"] = dato.IdDato;

                myjson = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);


            }
            ConsultaDatos consulta = JsonConvert.DeserializeObject<ConsultaDatos>(myjson);
            // Retrieve entity by id
            // Answer for question #1
            var list1 = (from reg in context.Registros
                         where reg.IdEstacion == consulta.idEst && reg.IdDato == consulta.idDato && reg.Profundidad % 5 == 0
                         && DateTime.Parse(reg.FechaLance) >= consulta.fechaIni && DateTime.Parse(reg.FechaLance) <= consulta.fechaFin
                         select new
                         {
                             profundidad = reg.Profundidad,
                             valor = reg.Valor
                         }).ToList();
            var list = list1.OrderBy(o => o.profundidad).ToList();
            // Validate entity is not null
            if (list.Count != 0)
            {
                var listdato = (from dato in context.Datos
                                where dato.IdDato == consulta.idDato
                                select dato).First();

                return Json(new { data = list, nombreDato = listdato.Nombre });
            }
            return Json(new { data = false, nombreDato = "" });

        }






        [Authorize]
        [HttpPost]
        public JsonResult desactivateDato(int? id)
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {
                var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

                if (id == null)
                    return Json(data: "No desactivado");

                var reg = context.Registros.FirstOrDefault(regis => regis.IdRegistro == id) as Registros;
                reg.Estatus = 2;
                context.Registros.Update(reg);
                context.SaveChanges();
                return Json(data: "Desactivado");
            }
            return Json(data: "Sin Permisos");

        }


        [Authorize]
        [HttpPost]
        public JsonResult activateDato(int? id)
        {
            var type = HttpContext.Session.GetInt32("tipoUser");
            if (type != 3)
            {
                var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

                if (id == null)
                    return Json(data: "No activado");

                var reg = context.Registros.FirstOrDefault(regis => regis.IdRegistro == id) as Registros;
                reg.Estatus = 1;
                context.Registros.Update(reg);
                context.SaveChanges();
                return Json(data: "Activado");
            }
            return Json(data: "Sin Permisos");


        }

        [Authorize]
        public IActionResult CompararRegistros()
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

            ViewBag.parametros = context.Datos.Select(parm => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = parm.Nombre,
                Value = parm.Nombre.ToString()
            });
            ViewBag.controlID = 0;
            ViewBag.estaciones = context.Estaciones.Select(est => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = est.Nombre,
                Value = est.IdEstacion.ToString()
            });



            var list = from e in context.Estaciones select e;



            return View(list);
        }

        [HttpPost]

        public async Task<IActionResult> Upload(int idEquipo, int idEstacion, List<IFormFile> files)
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

          
            foreach (var formFile in files)
            {

                using (var reader = new StreamReader(formFile.OpenReadStream()))
                {
                    /* Variables de objeto */
                    string Presion, Profundidad, Temperatura, Salinidad, Densidad, cadena;
                    string Fecha = null, Hora = null, No_lance = null;
                    bool estado_datos = false, estado_fecha = false, estado_lance = false;

                    while ((cadena = reader.ReadLine()) != null)
                    {
                        if (estado_lance)
                        {
                            var ini = cadena.IndexOf("c030311_");

                            cadena = cadena.Substring(ini);
                            ini = cadena.IndexOf("_") + 1;
                            cadena = cadena.Substring(ini);

                            No_lance = cadena.Substring(0, 4);
                            estado_lance = false;
                        }
                        if (estado_fecha)
                        {
                            Fecha = cadena.Substring(15, 10);
                            Hora = cadena.Substring(26, 5);
                            estado_fecha = false;
                        }
                        if (estado_datos)
                        {
                            if (!"* Sea-Bird SBE19plus  Data File:".Equals(cadena))
                            {
                                var registro = new Registros();
                                var registro1 = new Registros();
                                var registro2 = new Registros();
                                var registro3 = new Registros();

                                /* Profundidad */
                                Profundidad = cadena.Substring(27, 6);

                                /* Presion */
                                Presion = cadena.Substring(16, 6);


                                registro.NoLance = Int32.Parse(No_lance);
                                registro.Valor = float.Parse(Presion);
                                registro.IdDato = (from dato in context.Datos
                                                   where dato.Nombre.Equals("Presion")
                                                   select dato.IdDato).First();
                                registro.Profundidad = float.Parse(Profundidad);
                                registro.FechaLance = Fecha;
                                registro.Hora = Hora;
                                registro.IdEstacion = idEstacion;
                                registro.IdEquipo = idEquipo;
                                registro.Estatus = 1;
                                context.Registros.Add(registro);
                                context.SaveChanges();

                                /* Temperatura */

                                Temperatura = cadena.Substring(37, 7);

                                registro1.NoLance = Int32.Parse(No_lance);
                                registro1.Valor = float.Parse(Temperatura);
                                registro1.IdDato = (from dato in context.Datos
                                                    where dato.Nombre.Equals("Temperatura")
                                                    select dato.IdDato).First();
                                registro1.Profundidad = float.Parse(Profundidad);
                                registro1.FechaLance = Fecha;
                                registro1.Hora = Hora;
                                registro1.IdEstacion = idEstacion;
                                registro1.IdEquipo = idEquipo;
                                registro1.Estatus = 1;
                                context.Registros.Add(registro1);
                                context.SaveChanges();


                                /* Salinidad */
                                Salinidad = cadena.Substring(48, 7);

                                registro2.NoLance = Int32.Parse(No_lance);
                                registro2.Valor = float.Parse(Salinidad);
                                registro2.IdDato = (from dato in context.Datos
                                                    where dato.Nombre.Equals("Salinidad")
                                                    select dato.IdDato).First();
                                registro2.Profundidad = float.Parse(Profundidad);
                                registro2.FechaLance = Fecha;
                                registro2.Hora = Hora;
                                registro2.IdEstacion = idEstacion;
                                registro2.IdEquipo = idEquipo;
                                registro2.Estatus = 1;
                                context.Registros.Add(registro2);
                                context.SaveChanges();


                                /* Densidad */

                                Densidad = cadena.Substring(57, 9);

                                registro3.NoLance = Int32.Parse(No_lance);
                                registro3.Valor = float.Parse(Densidad);
                                registro3.IdDato = (from dato in context.Datos
                                                    where dato.Nombre.Equals("Densidad")
                                                    select dato.IdDato).First();
                                registro3.Profundidad = float.Parse(Profundidad);
                                registro3.FechaLance = Fecha;
                                registro3.Hora = Hora;
                                registro3.IdEstacion = idEstacion;
                                registro3.IdEquipo = idEquipo;
                                registro3.Estatus = 1;
                                context.Registros.Add(registro3);
                                context.SaveChanges();


                                /* Guardando */
                                //  Medidas.add(new Medida(Presion, Profundidad, Temperatura, Salinidad, Densidad, Fecha, Hora, No_lance));
                            }
                            else
                            {
                                estado_datos = false;
                            }
                        }
                        if ("*END*".Equals(cadena))
                        {
                            estado_datos = true;
                        }
                        /*cadena.substring(3,13)*/
                        if (("* <StatusData DeviceType='SBE19plus' SerialNumber='01906468'>").Equals(cadena))
                        {
                            estado_fecha = true;
                        }
                        if (("* Sea-Bird SBE19plus  Data File:").Equals(cadena))
                        {

                            estado_lance = true;
                        }
                    }
                }


            }
            return RedirectToAction("detalleEstacion", new
            {
                id = idEstacion,
            });
        }

        [HttpPost("RemoteUpload/{idEquipo}/{idEstacion}")]
        [AllowAnonymous]
        public async Task<IActionResult> Upload2(int idEquipo, int idEstacion, List<IFormFile> files)
        {
            var context = HttpContext.RequestServices.GetService(typeof(uvContext)) as uvContext;

        
            foreach (var formFile in files)
            {

                using (var reader = new StreamReader(formFile.OpenReadStream()))
                {
                    /* Variables de objeto */
                    string Presion, Profundidad, Temperatura, Salinidad, Densidad, cadena;
                    string Fecha = null, Hora = null, No_lance = null;
                    bool estado_datos = false, estado_fecha = false, estado_lance = false;

                    while ((cadena = reader.ReadLine()) != null)
                    {
                        if (estado_lance)
                        {
                            var ini = cadena.IndexOf("c030311_");

                            cadena = cadena.Substring(ini);
                            ini = cadena.IndexOf("_") + 1;
                            cadena = cadena.Substring(ini);

                            No_lance = cadena.Substring(0, 4);
                            estado_lance = false;
                        }
                        if (estado_fecha)
                        {
                            Fecha = cadena.Substring(15, 10);
                            Hora = cadena.Substring(26, 5);
                            estado_fecha = false;
                        }
                        if (estado_datos)
                        {
                            if (!"* Sea-Bird SBE19plus  Data File:".Equals(cadena))
                            {
                                var registro = new Registros();
                                var registro1 = new Registros();
                                var registro2 = new Registros();
                                var registro3 = new Registros();

                                /* Profundidad */
                                Profundidad = cadena.Substring(27, 6);

                                /* Presion */
                                Presion = cadena.Substring(16, 6);


                                registro.NoLance = Int32.Parse(No_lance);
                                registro.Valor = float.Parse(Presion);
                                registro.IdDato = (from dato in context.Datos
                                                   where dato.Nombre.Equals("Presion")
                                                   select dato.IdDato).First();
                                registro.Profundidad = float.Parse(Profundidad);
                                registro.FechaLance = Fecha;
                                registro.Hora = Hora;
                                registro.IdEstacion = idEstacion;
                                registro.IdEquipo = idEquipo;
                                registro.Estatus = 1;
                                context.Registros.Add(registro);
                                context.SaveChanges();

                                /* Temperatura */

                                Temperatura = cadena.Substring(37, 7);

                                registro1.NoLance = Int32.Parse(No_lance);
                                registro1.Valor = float.Parse(Temperatura);
                                registro1.IdDato = (from dato in context.Datos
                                                    where dato.Nombre.Equals("Temperatura")
                                                    select dato.IdDato).First();
                                registro1.Profundidad = float.Parse(Profundidad);
                                registro1.FechaLance = Fecha;
                                registro1.Hora = Hora;
                                registro1.IdEstacion = idEstacion;
                                registro1.IdEquipo = idEquipo;
                                registro1.Estatus = 1;
                                context.Registros.Add(registro1);
                                context.SaveChanges();


                                /* Salinidad */
                                Salinidad = cadena.Substring(48, 7);

                                registro2.NoLance = Int32.Parse(No_lance);
                                registro2.Valor = float.Parse(Salinidad);
                                registro2.IdDato = (from dato in context.Datos
                                                    where dato.Nombre.Equals("Salinidad")
                                                    select dato.IdDato).First();
                                registro2.Profundidad = float.Parse(Profundidad);
                                registro2.FechaLance = Fecha;
                                registro2.Hora = Hora;
                                registro2.IdEstacion = idEstacion;
                                registro2.IdEquipo = idEquipo;
                                registro2.Estatus = 1;
                                context.Registros.Add(registro2);
                                context.SaveChanges();


                                /* Densidad */

                                Densidad = cadena.Substring(57, 9);

                                registro3.NoLance = Int32.Parse(No_lance);
                                registro3.Valor = float.Parse(Densidad);
                                registro3.IdDato = (from dato in context.Datos
                                                    where dato.Nombre.Equals("Densidad")
                                                    select dato.IdDato).First();
                                registro3.Profundidad = float.Parse(Profundidad);
                                registro3.FechaLance = Fecha;
                                registro3.Hora = Hora;
                                registro3.IdEstacion = idEstacion;
                                registro3.IdEquipo = idEquipo;
                                registro3.Estatus = 1;
                                context.Registros.Add(registro3);
                                context.SaveChanges();


                                /* Guardando */
                                //  Medidas.add(new Medida(Presion, Profundidad, Temperatura, Salinidad, Densidad, Fecha, Hora, No_lance));
                            }
                            else
                            {
                                estado_datos = false;
                            }
                        }
                        if ("*END*".Equals(cadena))
                        {
                            estado_datos = true;
                        }
                        /*cadena.substring(3,13)*/
                        if (("* <StatusData DeviceType='SBE19plus' SerialNumber='01906468'>").Equals(cadena))
                        {
                            estado_fecha = true;
                        }
                        if (("* Sea-Bird SBE19plus  Data File:").Equals(cadena))
                        {

                            estado_lance = true;
                        }
                    }
                }


            }
            return Content("Done");


        }




    }
}
