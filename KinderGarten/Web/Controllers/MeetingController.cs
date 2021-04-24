using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace Web.Controllers
{
    public class MeetingController : Controller
    {
        MeetingService meetingService;
        public MeetingController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];

            User usergarten = (User)System.Web.HttpContext.Current.Session["User"];

            meetingService = new MeetingService(token);
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Meeting
        public JsonResult Meetings()
        {
            return new JsonResult { Data = meetingService.GetAll().ToList(), JsonRequestBehavior = JsonRequestBehavior.AllowGet }; 
        }
        public ActionResult IndexAdminGarten()
        {
            return View(meetingService.GetAll());
        }
        // GET: Meeting/Details/5
        public ActionResult Details(int id)
        {
            Meeting meeting = meetingService.getMeetingById(id);
            if (meeting != null)
            {
                return View(meeting);
            }
            return View();
        }

        // GET: Meeting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meeting/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "DateStart,DateEnd")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                if (meetingService.Add(meeting))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();

        }

        // GET: Meeting/Edit/5
        public ActionResult Edit(int id)
        {
            Meeting meeting = meetingService.getMeetingById(id);
            return View(meeting);
        }

        // POST: Meeting/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "DateStart,DateEnd")] Meeting meeting)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (meetingService.Update(id, meeting))
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

        // GET: Meeting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Meeting/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (meetingService.deleteMeetingById(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

