using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Model;
using Service;

namespace Web.Controllers
{
    public class VoteController : Controller
    {
        VoteService voteService;
        KinderGartenService kinderGartenService;

        public VoteController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];
            kinderGartenService = new KinderGartenService(token);
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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/user/findUser/" + Session["id"]).Result;
            User user = new User();
            if (response.IsSuccessStatusCode)
            {
                user = response.Content.ReadAsAsync<User>().Result;
            }
            vote.Voter = user.Id;
            vote.VotedFor = idVotedFor;
            if (voteService.Add(vote,idVotedFor))
            {
                return RedirectToAction("IndexParent");
            }
            return View();

        }
        public ActionResult Index()
        {
            return View(voteService.GetAll());
        }

        public ActionResult IndexParent()
        {
            return View(voteService.GetAllforparent());
        }


        public ActionResult Validate()
        {
            KinderGarten k = kinderGartenService.findUserByIdK((int)Session["id"]);

            User u = voteService.delegatorsElection(k.Id);
            if (u != null)
            {
                return View(u);
            }
            return View();
        }
    }
}
;