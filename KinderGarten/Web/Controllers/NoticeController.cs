using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace Web.Controllers
{
    public class NoticeController : Controller
    {
        NoticeService noticeService = new NoticeService();
        // GET: Notice
        public ActionResult Index()
        {
            return View(noticeService.getNoticeByScore());
        }

        // GET: Notice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Notice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notice/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Notice/Edit/5
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

        // GET: Notice/Delete/5
        public ActionResult Delete(int id)
        {
            Notice notice = noticeService.getNoticeById(id);


            if (notice != null)
            {

                return View(notice);
            }

            return View();
        }

        // POST: Notice/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (noticeService.deleteNoticeById(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
