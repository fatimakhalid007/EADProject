using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EADProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult about()
        {
            return View();
        }
        public ActionResult contact()
        {
            return View();
        }
        public ActionResult Recipies()
        {
            return View();
        }
        public ActionResult Tips_And_Tricks()
        {
            return View();
        }
        public ActionResult Fast_Foods()
        {
            return View();
        }
        public ActionResult Deserts()
        {
            return View();
        }
        public ActionResult Continental()
        {
            return View();
        }
        public ActionResult Page(int id)
        {
            Models.RecipieBO b = new Models.RecipieBO();
            Models.RecipieDAL d = new Models.RecipieDAL();
             b=  d.getRecipiesFast_Food(id);
             ViewData["f1"] = b.name;
             ViewData["f2"] = b.recipie;
             ViewData["f3"] = b.recipieFile;
             ViewData["f4"] = b.type;
             ViewData["f5"] = b.recipieDetail;
             return View();
     }

 
   
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(string e,string p)
        {
           Models.LogInBO l = new Models.LogInBO();
           l.setemail(e.Trim());
           l.setpass(p.Trim());
           if (l.getemail() == "Admin")
               return Redirect("~/Admin/AdminIndex");
           if (Models.LogInDAL.validateUser(l))
           {
               Session["logIn"] = e.Trim();
               if (l.getemail() == "Admin")
                   return Redirect("~/Admin/AdminIndex");
               return Redirect("~/Home/Index1");
           }
            
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string n, string e, string p, string rp)
        {
            Models.SignUpBO s = new Models.SignUpBO();
            s.username = n;
            s.email = e;
            s.pass = p;
            s.repass = rp;
            if (p != rp)
            {
                ViewBag.Msg = "password does not match!";
            }
            if (Models.LogInDAL.AddUser(s))
            {
                Session["logIn"] = e.Trim();
                ViewBag.Msg = "successfully signed in";
                return Redirect("~/Home/Index1");
            }
            else
            ViewBag.Msg = "Enter correct email";
            return View("Index1");
        }
        public ActionResult LogOut()
        {
            Session["logIn"] = null;
            Session.Abandon();
            return View("Index");
        }
        public ActionResult Index1()
        {
            if (Session["logIn"] == null)
            {
                return Redirect("~/Home/LogIn");
            }
            return View();
        }
  
    }
}
