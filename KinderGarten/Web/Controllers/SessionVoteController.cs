using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace Web.Controllers
{
    public class SessionVoteController : Controller
    {
        SessionVoteService sessionVoteService = new SessionVoteService();
        // GET: SessionVote
        public ActionResult Index()
        {
            return View(sessionVoteService.GetAll());
        }

        // GET: SessionVote/Details/5
        public ActionResult Details(int id)
        {
            SessionVote sessionVote = sessionVoteService.getSessionVoteById(id);
            if (sessionVote != null)
            {
                return View(sessionVote);
            }
            return View();
        }

        // GET: SessionVote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SessionVote/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "DateStart,DateEnd")] SessionVote sessionVote)
        {
            if (sessionVoteService.Add(sessionVote))
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: SessionVote/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SessionVote/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "DateStart,DateEnd")] SessionVote sessionVote)
        {
            try
            {
                if (sessionVoteService.Update(id, sessionVote))
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

        // GET: SessionVote/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SessionVote/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (sessionVoteService.deleteSessionVoteById(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}


