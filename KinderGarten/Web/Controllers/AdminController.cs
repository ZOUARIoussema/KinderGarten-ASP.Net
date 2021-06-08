using Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Service;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Drawing;
using Rotativa;
using PagedList;
using System.Web.UI;

namespace Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ClaimsService claimservice;
        private UserAdminService useradminservice;
        private UserService userservice = new UserService();
      

        public AdminController()
        {
            String token = (String)System.Web.HttpContext.Current.Session["AccessToken"];
            // userservice = new UserService(token);

            claimservice = new ClaimsService(token);
            useradminservice = new UserAdminService(token);
        }


       

        public ActionResult PrintPartialViewToPdf(int id)
        {

            Claim c = claimservice.getClaimById(id);

                var report = new PartialViewAsPdf("~/Views/Admin/detailsPDF.cshtml", c);
                return report;
            
        }

       
      


        public ActionResult detailsPDF(int id)
        {
            return View(claimservice.getClaimById(id));
        }


        public ActionResult Kindergarten()
        {
            return View(useradminservice.GetAllKinder());
        }


        [Authorize]
        // GET: Admin
        public ActionResult Index()
        {   
            MaxScoreEval maxscore = useradminservice.getMaxScoreEval();

            ViewBag.ChildsSubscribed = useradminservice.ChildSubscribed();

            ViewBag.NbrUsersRegistered = useradminservice.UsersRegistred();

            ViewBag.NbrUsersRegisteredThisMonth = useradminservice.UsersRegistredThisMonth();

            ViewBag.maxscore = maxscore.MaxScore;

            ViewBag.namekindergarten = maxscore.Name.ToString();

            return View();
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "Id,FirstName,LastName,Email,Password,ConfirmPassword,Address,Tel")] User usertomodify)
        {
            if (ModelState.IsValid)
            {
                HttpClient httpclientprofile = new HttpClient();
                httpclientprofile.BaseAddress = new Uri("http://localhost:8081/");

                httpclientprofile.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var APIResponse = httpclientprofile.PutAsJsonAsync<User>(Statics.baseAddress + "user/update",
                 usertomodify).Result;


                System.Diagnostics.Debug.WriteLine("email user to modify " + usertomodify.Email);

                if (APIResponse.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine(usertomodify.ToString());

                    ViewBag.Message = "Account updated  successfully !";

                    return View();
                }
            }

            return View();
        }


        public ActionResult ParentsByKinderGarten()
        {
            return View(useradminservice.getParentsByKinderGarten());
        }


        public ActionResult EditProfile(int id)
        {
            System.Diagnostics.Debug.WriteLine("******iduserprofile" + id);

            User userp = userservice.findUserById(id);

            System.Diagnostics.Debug.WriteLine(userp.ToString());

            if (userp != null)
            {

                return View(userp);
            }


            return View();
        }





   
        [Authorize]
        public ActionResult Claims(String searchbyparent )
        {



            if (String.IsNullOrEmpty(searchbyparent))
            {

                return View(claimservice.GetAll());
            }
         else
            {
           
                return View(claimservice.getClaimsByParent(searchbyparent));
            }
             
        }

        public ActionResult Users(int? Page_No)
        {
            IEnumerable<User> listusers = useradminservice.getAll();

            int size_of_page = 4;
            int No_Of_Page = (Page_No ?? 1);

            return View(listusers.ToPagedList(No_Of_Page,size_of_page));
        }

      

        [HttpPost]
        public ActionResult ChangeState(int idclaim)
        {
            String response = claimservice.ChangeStateClaim(idclaim);

           // ViewBag.message = response;

            return RedirectToAction("Claims", "Admin");
        }


        // GET: Admin/Details/5
        public ActionResult DetailsClaim(int id)
        {
            return View(claimservice.getClaimById(id));
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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


        public ActionResult deleteUser(int id)
        {
             if (useradminservice.DeleteUser(id))
                {
                    return RedirectToAction("Users", "Admin");
                }


          return Json(new { Status = "error", Message = "Error occured , verify !" });
        }

        [HttpPost]
        public ActionResult changestateuser(int iduser)
        {
            String response  = useradminservice.changeStateUser(iduser);
          
            return RedirectToAction("Users", "Admin");
        }




    }
}
