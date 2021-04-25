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



        private ConsultationService consultationService;
        private FolderMedicalService folderMedicalService;
        

        public ConsultationMedicalController()
        {

            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];

            consultationService = new ConsultationService(token);
             folderMedicalService = new FolderMedicalService(token);


        }

        

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

            ViewBag.FolderMedicalId = new SelectList(folderMedicalService.GetAll(), "Id", "Id");

            return View();
        }

        // POST: ConsultationMedical/Create
        [HttpPost]
        public ActionResult Create([Bind (Include =("Description,Weight,Height,FolderMedicalId"))]Consultation consultation)
        {


            consultation.FolderMedical = folderMedicalService.GetById((int)consultation.FolderMedicalId);
            consultation.Doctor = (User)Session["User"];
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
                 
                ViewBag.FolderMedicalId = new SelectList(folderMedicalService.GetAll(), "Id", "Id");

                return View(consultation);
            }


            return View();
        }

        // POST: ConsultationMedical/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = ("Description,Weight,Height,DateC,Id,FolderMedicalId"))] Consultation consultation)
        {


            consultation.Doctor =(User) Session["User"];

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
