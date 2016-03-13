﻿using BusinessLogic.Logic;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ResultadoAnalisisController : Controller
    {
        //
        // GET: /ResultadoAnalisis/
        public ActionResult Create(int id)
        {
            
            try
            {
                using (IAnalisisClinicosLogic bl = new AnalisisClinicosLogic())
                {
                    AnalisisClinico analisisClinico = bl.GetAnalisisClinico(id);
                    if (analisisClinico.Paciente.Foto != null)
                    {
                        string imageBase64Data = Convert.ToBase64String(analisisClinico.Paciente.Foto.ToArray());
                        string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                        ViewBag.ImageData = imageDataURL;
                        ViewBag.Doctor = analisisClinico.Doctor;
                        ViewBag.Paciente = analisisClinico.Paciente;
                        ViewBag.AnalisisClinicoID = analisisClinico.AnalisisClinicoID;
                    }
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResultadoAnalisis resultadoAnalisis, FormCollection frm)
        {
            ActionResult result = null;
            try
            {
                if(ModelState.IsValid)
                {
                    int analisiClinicosID = int.Parse(frm["AnalisisClinicosID"]);
                    using(IAnalisisClinicosLogic bl = new AnalisisClinicosLogic())
                    {

                       AnalisisClinico analisisClinico= bl.GetAnalisisClinico(analisiClinicosID);
                       analisisClinico.ListResultadoAnalisis.Add(resultadoAnalisis);
                       bl.Edit(analisisClinico);
                    }

                    result = RedirectToAction("../AnalisisClinico/Index");
                }
                else
                {
                    return View("Error");
                }

            }
            catch (Exception e)
            {
                return View("Error");
            }
            return result;
        }
	}
}