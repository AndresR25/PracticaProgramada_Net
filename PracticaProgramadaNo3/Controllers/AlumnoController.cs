using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaProgramadaNo3.Models;

namespace PracticaProgramadaNo3.Controllers
{
    public class AlumnoController : Controller
    {
        
        // GET: Alumno
        public ActionResult Index(PracticaProgramadaNo3.Models.ViewModel.AlumnoModelo model)
        {
            if(model == null)
            {
                model=new Models.ViewModel.AlumnoModelo();
            }
            return View();
        }

        public ActionResult Guardar(PracticaProgramadaNo3.Models.ViewModel.AlumnoModelo model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", model);
            }

            Alumno alumno = new Alumno();
            alumno.carnet = model.carnet;
            alumno.nombre= model.nombre;
            alumno.apellido = model.apellido;
            alumno.genero = model.genero;
            alumno.email = model.email;
            alumno.telefono=model.telefono;
            alumno.FechaNacimiento = model.FechaNacimiento;
            PracticaNo3Entities db = new PracticaNo3Entities();
            db.Alumno.Add(alumno);
            db.SaveChanges();

            return View("Exito",model);
        }

        public ActionResult Exito()
        {
            return View();
        }
    }
}