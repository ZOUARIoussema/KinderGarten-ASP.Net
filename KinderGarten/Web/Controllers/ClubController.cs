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
        CategoryService categoryService;
        ClubService clubService;
        public ClubController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];

            User usergarten = (User)System.Web.HttpContext.Current.Session["User"];

            categoryService = new CategoryService(token);
            clubService = new ClubService(token);
        }
        // GET: Club
        public ActionResult Index()
        {
            return View(clubService.GetAll());
        }
      
        // GET: Club/Details/5
        public ActionResult Details(int id)
        {
            Club Club = clubService.getClubById(id);
            if (Club != null)
            {
                return View(Club);
            }
            return View();
        }

        // GET: Club/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Description");
            return View();
        }

        // POST: Club/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Description,CategoryId")] Club club)
        {
            if (ModelState.IsValid)
            {
                if (clubService.Add(club))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();

        }

        // GET: Club/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(categoryService.GetAll(), "Id", "Description");
         //   Club club = clubService.getClubById(id);
            return View();
        }

        // POST: Club/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Description,CategoryId")] Club club)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (clubService.Update(id, club))
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



