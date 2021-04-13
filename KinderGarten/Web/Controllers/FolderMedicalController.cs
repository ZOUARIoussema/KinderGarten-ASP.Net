using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;


namespace Web.Controllers
{
    public class FolderMedicalController : Controller
    {
     

        FolderMedicalService folderMedicalService = new FolderMedicalService();

        public FolderMedicalController()
        {

             

        }

        // GET: FolderMedical
        public ActionResult Index()
        {
             

            

            return View(folderMedicalService.GetAll());
        }

        // GET: FolderMedical/Details/5
        public ActionResult Details(int id)
        {
            FolderMedical folderMedical = folderMedicalService.GetById(id);

            if (folderMedical != null)
                {

                    return View(folderMedical);
                }
            

            return View();
        }

        // GET: FolderMedical/Create
        public ActionResult Create()
        {
             


            ViewBag.ChildId = new SelectList(folderMedicalService.getAllChild(), "Id", "Name");


             

            return View();
        }

        // POST: FolderMedical/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Allergy,Particularity,ChildId")]FolderMedical folder)
        {
           


                if (folderMedicalService.Add(folder))
                {
                    return RedirectToAction("Index");
                }

 
           
                return View();
            
        }

        // GET: FolderMedical/Edit/5
        public ActionResult Edit(int id)
        {


            ViewBag.ChildId = new SelectList(folderMedicalService.getAllChild(), "Id", "Name");


            FolderMedical folderMedical = folderMedicalService.GetById(id);




                if (folderMedical != null)
                {

                    return View(folderMedical);
                }
             

            return View();

          
        }

        // POST: FolderMedical/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Id,Allergy,Particularity,ChildId,DateC")] FolderMedical folderMedical)
        {
            
                if (folderMedicalService.UpdateFolder(folderMedical))
                {
                    return RedirectToAction("Index");
                }

           
                return View();
             
        }

        // GET: FolderMedical/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FolderMedical/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            
                if (folderMedicalService.DeleteFolder(id))
                {
                    return RedirectToAction("Index");
                }

                
            
                return View();
             
        }
    }
}
