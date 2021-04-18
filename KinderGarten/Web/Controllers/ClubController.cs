using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace Web.Controllers
{
    public class ClubController : Controller
    {
        ClubService clubService = new ClubService();
        // GET: Club
        public ActionResult Index()
        {
            return View(clubService.GetAll());
        }

        // GET: Club/Details/5
        public ActionResult Details(int id)
        {
            Club club = clubService.getClubById(id);
            if (club != null)
            {
                return View(club);
            }
            return View();
        }

        // GET: Club/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Club/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Description")] Club club)
        {
            if (clubService.Add(club))
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Club/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Club/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Description")] Club club)
        {
            try
            {
                if (clubService.Update(id, club))
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Club/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Club/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (clubService.deleteClubById(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}



