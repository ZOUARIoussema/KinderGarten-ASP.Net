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
        VoteService voteService;
        public VoteController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];

            User usergarten = (User)System.Web.HttpContext.Current.Session["User"];

            voteService = new VoteService(token);
        }
        // GET: Vote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vote/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Voter,VotedFor")] VoteForm vote, int idVotedFor)
        {
            vote.Voter = 7;
            vote.VotedFor = idVotedFor;
            if (voteService.Add(vote,idVotedFor))
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        public ActionResult Index()
        {
            return View(voteService.GetAll());
        }
        public ActionResult Validate()
        {
            User u = voteService.delegatorsElection(3);
            if (u != null)
            {
                return View(u);
            }
            return View();
        }
    }
}
;