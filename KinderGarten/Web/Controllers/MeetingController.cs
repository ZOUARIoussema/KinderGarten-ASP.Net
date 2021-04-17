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
        MeetingService meetingService = new MeetingService();
        // GET: Meeting
        public ActionResult Index()
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
            if (meetingService.Add(meeting))
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Meeting/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Meeting/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "DateStart,DateEnd")] Meeting meeting)
        {
            try
            {
                if (meetingService.Update(id, meeting))
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

