
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Lab01_EDII.Controllers
{
    public class AVLController : Controller
    {
        private IHostingEnvironment Environment;
        public AVLController(IHostingEnvironment _environment)
        {
            Environment = _environment;

        }

        // GET: ClientesManualController1
        public ActionResult Index2()

        {
            if (Singleton.Instance.bandera == 1)
            {
                Singleton.Instance.bandera = 0;
                return View(Singleton.Instance.Aux);
            }
            else
            {
                return View(Singleton.Instance.miAVL.ObtenerLista());
            }

        }

        // GET: ClientesManualController1/Details/5
        public ActionResult Details2(string id)
        {
            var ViewAuto = Singleton.Instance.miAVL.ObtenerLista().FirstOrDefault(a => a.Id == id);
            return View(ViewAuto);
        }

        // GET: ClientesManualController1/Create
        public ActionResult Create2()
        {
            return View();
        }

        // POST: ClientesManualController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2(IFormCollection collection)
        {
            try
            {
                var NewAuto = new Models.VehiculoExtModel
                {
                    Id = collection["id"],
                    Email = collection["email"],
                    Propietario = collection["Propietario"],
                    Color = collection["color"],
                    Marca = collection["Marca"],
                    NumSerie = collection["NumSerie"]
                };
                Singleton.Instance.miAVL.Add(NewAuto);
                Singleton.Instance.bandera = 0;
                return RedirectToAction(nameof(Index2));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesManualController1/Edit/5
        public ActionResult Edit2(string id)
        {
            var viewAuto = Singleton.Instance.miAVL.ObtenerLista().FirstOrDefault(a => a.Id == id);
            return View(viewAuto);
        }

        // POST: ClientesManualController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2(string id, IFormCollection collection)
        {
            try
            {
                var ViewAuto = Singleton.Instance.miAVL.ObtenerLista().FirstOrDefault(a => a.Id == id);
                string Auxid = Singleton.Instance.miAVL.ObtenerLista().FirstOrDefault(a => a.Id == id).Id;
                Singleton.Instance.miAVL.Remove(ViewAuto);
                var NewAuto = new Models.VehiculoExtModel
                {
                    Id = Auxid,
                    Email = collection["email"],
                    Propietario = collection["Propietario"],
                    Color = collection["color"],
                    Marca = collection["Marca"],
                    NumSerie = collection["NumSerie"]
                };
                Singleton.Instance.bandera = 0;
                Singleton.Instance.miAVL.Add(NewAuto);
                return RedirectToAction(nameof(Index2));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesManualController1/Delete/5
        public ActionResult Delete2(string id)
        {
            Singleton.Instance.bandera = 0;
            var ViewAuto = Singleton.Instance.miAVL.ObtenerLista().FirstOrDefault(a => a.Id == id);
            return View(ViewAuto);
        }

        // POST: ClientesManualController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete2(string id, IFormCollection collection)
        {
            try
            {
                Singleton.Instance.bandera = 0;
                var ViewAuto = Singleton.Instance.miAVL.ObtenerLista().FirstOrDefault(a => a.Id == id);
                Singleton.Instance.miAVL.Remove(ViewAuto);
                return RedirectToAction(nameof(Index2));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CargarArchivo2(IFormFile File)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            string Id = "", Email = "", Propietario = "", Color = "", Marca = "", NumSerie = "";

            try
            {

                if (File != null)
                {
                    string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string FileName = Path.GetFileName(File.FileName);
                    string FilePath = Path.Combine(path, FileName);
                    using (FileStream stream = new FileStream(FilePath, FileMode.Create))
                    {
                        File.CopyTo(stream);
                    }
                    using (TextFieldParser csvFile = new TextFieldParser(FilePath))
                    {

                        csvFile.CommentTokens = new string[] { "#" };
                        csvFile.SetDelimiters(new string[] { "," });
                        csvFile.HasFieldsEnclosedInQuotes = true;

                        csvFile.ReadLine();

                        while (!csvFile.EndOfData)
                        {
                            string[] fields = csvFile.ReadFields();
                            Id = Convert.ToString(fields[0]);
                            Email = Convert.ToString(fields[1]);
                            Propietario = Convert.ToString(fields[2]);
                            Color = Convert.ToString(fields[3]);
                            Marca = Convert.ToString(fields[4]);
                            NumSerie = Convert.ToString(fields[5]);
                            VehiculoExtModel nuevoVehiculo = new VehiculoExtModel
                            {
                                Id = Id,
                                Email = Email,
                                Propietario = Propietario,
                                Color = Color,
                                Marca = Marca,
                                NumSerie = NumSerie,

                            };
                            Singleton.Instance.miAVL.Add(nuevoVehiculo);
                        }
                    }
                }
                timer.Stop();
                TimeSpan time = timer.Elapsed;
                TempData["TCargaAVL"] = "Tiempo de carga: " + Convert.ToString(time);
                int b = Singleton.Instance.miAVL.GetRotacion();
                TempData["TRot"] = "Existieron: " + Convert.ToString(b) + " rotaciones.";
                return RedirectToAction(nameof(Index2));
            }
            catch (Exception)
            {
                ViewData["Message"] = "Algo sucedio mal";
                return RedirectToAction(nameof(Index2));

            }


            //Imprimir "time" en pantalla


        }

        public ActionResult BuscDPI(string BuscDPI)
        {
            try
            {
                Singleton.Instance.bandera = 1;
                Singleton.Instance.Aux = Singleton.Instance.miAVL.Obtener(a => a.Id == BuscDPI);
                int a = Singleton.Instance.miAVL.GetComparaciones();
                TempData["TComp"] = "Se realizaron: " + Convert.ToString(a) + " comparaciones.";
                return RedirectToAction(nameof(Index2));
            }
            catch (Exception)
            {
                Singleton.Instance.bandera = 0;
                ViewData["Message"] = "No Encontrado";
                return RedirectToAction(nameof(Index2));

            }
        }
        public ActionResult BuscNumSerie(string BuscSerie)
        {
            try
            {
                Singleton.Instance.bandera = 1;
                Singleton.Instance.Aux = Singleton.Instance.miAVL.Obtener(a => a.NumSerie == BuscSerie);
                int a = Singleton.Instance.miAVL.GetComparaciones();
                TempData["TComp2"] = "Se realizaron: " + Convert.ToString(a) + " comparaciones.";
                return RedirectToAction(nameof(Index2));
            }
            catch (Exception)
            {
                Singleton.Instance.bandera = 0;
                ViewData["Message"] = "No Encontrado";
                return RedirectToAction(nameof(Index2));

            }
        }
        public ActionResult BuscCorreo(string BuscCorreo)
        {
            try
            {
                Singleton.Instance.bandera = 1;
                Singleton.Instance.Aux = Singleton.Instance.miAVL.Obtener(a => a.Email == BuscCorreo);
                int a = Singleton.Instance.miAVL.GetComparaciones();
                TempData["TComp3"] = "Se realizaron: " + Convert.ToString(a) + " comparaciones.";
                return RedirectToAction(nameof(Index2));
            }
            catch (Exception)
            {
                Singleton.Instance.bandera = 0;
                ViewData["Message"] = "No Encontrado";
                return RedirectToAction(nameof(Index2));

            }
        }
    }
}
