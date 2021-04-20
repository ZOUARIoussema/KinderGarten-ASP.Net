using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace Web.Controllers
{
    public class PublicationController : Controller
    {
        PublicationService publicationService = new PublicationService();
        public PublicationController()
        {
        }
        // GET: Publication
        public ActionResult Index()
        {
            return View(publicationService.getAllPublicationDesc());
        }

        // GET: Publication/Details/5
        public ActionResult Details(int id)
        {
            Publication publication = publicationService.GetById(id);
            if (publication != null)
            {
                return View(publication);
            }
            return View();
        }

        // GET: Publication/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publication/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Description,Attachement")] Publication publication)
        {
            if (publicationService.Add(publication))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Publication/Edit/5
        public ActionResult Edit(int id)
        {
            Publication publication = publicationService.GetById(id);

            if (publication != null)
            {

                return View(publication);
            }

            return View();
        }

        // POST: Publication/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Id,Description,Attachement,NumberLike,NumberDislike")]Publication publication)
        {
            if (publicationService.UpdatePublication(publication))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Publication/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Publication/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (publicationService.DeletePublication(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: Publication
        public ActionResult AddComment()
        {
            return View(@"/Views/Comment/Create.cshtml");
        }

    }
}
