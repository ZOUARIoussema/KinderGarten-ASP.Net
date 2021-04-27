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
    public class CommentController : Controller
    {
        CommentService commentService = new CommentService();
        public static int idp;
        PublicationService publicationService = new PublicationService();

        // GET: Comment
        public ActionResult Index(int id)
        {
            List<Comment> comment = new List<Comment>();
            idp = id; 
            foreach (var item in commentService.getAllComment()) {
                if (item.Publication.Id == id)
                {
                    comment.Add(item);
                }
            }
            return View(comment);
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Description")] Comment comment)
        {

            Publication p = publicationService.getPublicationById(idp);
            comment.Publication = p;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8081");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/user/findUser/"+Session["id"]).Result;
            User user= new User();
            if (response.IsSuccessStatusCode)
            {

                user = response.Content.ReadAsAsync<User>().Result;
            }
            comment.Parent = user;
            if (commentService.Add(comment))
            {
                return RedirectToAction("Index",new {id = idp });
            }
            return View();
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include ="Description")]Comment comment)
        {
            try
            {
                if (commentService.Update(id, comment)){
                    return RedirectToAction("Index");
                }
                return View();
            } catch
            {
                return View();
            }
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
