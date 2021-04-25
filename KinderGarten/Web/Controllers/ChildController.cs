using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace Web.Controllers
{
    public class ChildController : Controller
    {
        ChildService childService = new ChildService();
        // GET: Child
        public ActionResult Index()
        {
            return View(childService.getAllChild());
        }
       

        // GET: Child/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Child/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Child/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,DateOfBith,Sex,Age,Picture")] Child child, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                child.Picture = file.FileName;
                if (file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                    file.SaveAs(path);
                }
                if (childService.Add(child))
                {
                    return RedirectToAction("Create","SubscriptionChild") ;
                }
            }
            return View();
        }

        // GET: Child/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Child/Edit/5
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

        // GET: Child/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Child/Delete/5
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
