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
        private static FolderMedical folderMedical = new FolderMedical();
        private static User doctor = new User();

        

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

            Consultation consultation = consultationService.GetById(id);

            if (consultation != null)
            {
                folderMedical = consultation.FolderMedical;
                doctor = consultation.Doctor;
               

                return View(consultation);
            }


            return View();
        }

        // POST: ConsultationMedical/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = ("Description,Weight,Height,DateC,Id"))] Consultation consultation)
        {

             
            consultation.Doctor=doctor;
            consultation.FolderMedical=folderMedical;
            

            System.Diagnostics.Debug.WriteLine("edit d" + consultation.FolderMedical.Id);
            System.Diagnostics.Debug.WriteLine("edit f" + consultation.FolderMedical.Id);

            if (consultationService.Update(consultation))
            {

                return RedirectToAction("Index");
            }
                
             
             
                return View();
            
        }

        // GET: ConsultationMedical/Delete/5
        public ActionResult Delete(int id)
        {
            Consultation consultation = consultationService.GetById(id);

            if (consultation != null)
            {
               

                return View(consultation);
            }
            return View();
        }

        // POST: ConsultationMedical/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {


            if (consultationService.DeleteConsultation(id))
            {
                return RedirectToAction("Index");
            }
               
            
                return View();
             
        }
    }
}
