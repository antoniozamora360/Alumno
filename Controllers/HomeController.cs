using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Alumno.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Alumno.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(AlumnoModel model)
        {
            if (ModelState.IsValid)
            {
                GuardarAlumno(model);
            }
            else
            {
                model.Generos = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Masculino", Value = "1Masculino"},
                    new SelectListItem {Text = "Femenino", Value = "Femenino"}
                };
            }
            return View(model);
        }
        public IActionResult Index()
        {
            var vm = new AlumnoModel();
            vm.Generos = new List<SelectListItem>
            {
                new SelectListItem {Text = "Masculino", Value = "1Masculino"},
                new SelectListItem {Text = "Femenino", Value = "Femenino"}
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private void GuardarAlumno(AlumnoModel model)
        {
            string path = _hostingEnvironment.ContentRootPath + "/Alumnos/" + model.RFC + ".txt";
            if (!System.IO.File.Exists(path))
            {
                using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                }
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
            {
                string s = "Nombre: " + model.Nombre + "| Apellido Paterno: " + model.Apellido_Paterno + "| Apellido Materno" + model.Apellido_Materno + "| Fecha de Nacimiento: " + model.Fecha_Nacimiento + "| Genero: " + model.Genero + "| Fecha de Ingreso: " + model.Fecha_Ingreso + "| Activo: " + model.Activo + "| RFC: " + model.RFC;
                file.WriteLine(s);
            }
        }
    }
}
