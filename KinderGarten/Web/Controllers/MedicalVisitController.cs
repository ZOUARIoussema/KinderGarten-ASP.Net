using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;

namespace Web.Controllers
{
    public class MedicalVisitController : Controller
    {

        MedicalVisitService medicalVisitService ;

        public MedicalVisitController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];
            medicalVisitService = new MedicalVisitService(token);

        }

        // GET: MedicalVisit
        public ActionResult Index()
        {
            return View();
        }

       
        public JsonResult GetEvents()
        {


            
           return new JsonResult { Data = medicalVisitService.GetAll().ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
             


            

        }


        [HttpPost]
        public JsonResult SaveEvent(MedicalVisitKinderGarten m)
        {

            

            System.Diagnostics.Debug.WriteLine("**** " + m);
            var status = false;

            if (m.Id > 0)
            {
                //Update the event
                var v = medicalVisitService.GetAll().Where(a => a.Id == m.Id).FirstOrDefault();
                if (v != null)
                {
                    v.Subject = m.Subject;
                    v.DateStart = m.DateStart;
                    v.DateEnd = m.DateEnd;
                    v.Description = m.Description;
                    v.IsFullDay = m.IsFullDay;
                    v.ThemeColor = m.ThemeColor;
                    medicalVisitService.Update(v);


                }
            }
            else
            {

                medicalVisitService.AddMedicalVisit(m);




                status = true;
            }
            
            return new JsonResult { Data = new { status = status } };
        }


        [HttpPost]
        public JsonResult DeleteEvent(int id)
        {
            var status = false;
            
                
                if (medicalVisitService.Delete(id))
                {
                    
                    status = true;
                }
             
            return new JsonResult { Data = new { status = status } };
        }


    }
}