using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;


namespace Web.Controllers
{
    public class EventController : Controller
    {
        EventService eventService = new EventService();
        CategoryService categoryService = new CategoryService();
        // GET: Event
        public ActionResult Index()
        {
            return View(eventService.GetAll());
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            Event Event = eventService.getEventById(id);
            if (Event != null)
            {
                return View(Event);
            }
            return View();
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Description");
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Description,Date,Price,Object,CategoryId")] Event e)
        {
            if (ModelState.IsValid)
            {
                if (eventService.Add(e))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();

        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Description");
            return View();
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Description,Date,Price,Object,CategoryId")] Event e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (eventService.Update(id, e))
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (eventService.deleteEventById(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}


