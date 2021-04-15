using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace Web.Controllers
{
    public class ConsultationMedicalController : Controller
    {

        private ConsultationService consultationService = new ConsultationService();
        private FolderMedicalService folderMedicalService = new FolderMedicalService();

        // GET: ConsultationMedical
        public ActionResult Index()
        {
            return View(consultationService.GetAll());
        }

        // GET: ConsultationMedical/Details/5
        public ActionResult Details(int id)
        {

            Consultation consultation = consultationService.GetById(id);

            if(consultation != null)
            {

                return View(consultation);
            }

            return View();
        }

        // GET: ConsultationMedical/Create
        public ActionResult Create()
        {

            ViewBag.folder = new SelectList(folderMedicalService.GetAll(), "Id", "Id");

            return View();
        }

        // POST: ConsultationMedical/Create
        [HttpPost]
        public ActionResult Create([Bind (Include =("Description,Weight,Height"))]Consultation consultation)
        {
            
                if (consultationService.Add(consultation))
                {

                    return RedirectToAction("Index");
                }
             
             
                return View();
             
        }

        // GET: ConsultationMedical/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ConsultationMedical/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ConsultationMedical/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ConsultationMedical/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
