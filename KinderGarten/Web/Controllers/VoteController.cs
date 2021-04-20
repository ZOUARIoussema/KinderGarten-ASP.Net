using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace Web.Controllers
{
    public class VoteController : Controller
    {
        VoteService voteService = new VoteService();
        // GET: Vote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vote/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Voter,VotedFor")] VoteForm vote,int id, int idsession)
        {
            if (voteService.Add(vote,id,idsession))
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        public ActionResult Index()
        {
            return View(voteService.GetAll());
        }

    }
}
