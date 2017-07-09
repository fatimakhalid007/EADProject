using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
using System.Web;
using System.Web.Mvc;

namespace EADProject.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminIndex()
        {
            return View();
        }
        public ActionResult Tables()
        {
            return View();
        }
        public ActionResult delete()
        {

            return View("AddUser");
        }
        [HttpPost]
        public ActionResult AddRecipie(string name,string r,string c,string recipie ,string detail ,string img)
        {
            Models.RecipieBO re = new Models.RecipieBO();
            re.name = name;
            re.recipie = r;
            re.type = c;
            re.image = img;
            re.recipieDetail = detail;
            re.recipie = recipie;

            Models.RecipieDAL.AddRecipie(re);
            return View();
            

        }
        public ActionResult AddRecipie()
        {

            return View();
        }
        public ActionResult Fast_FoodTable()
        {
            return View();
        }
        public ActionResult AddUser()
        {
            return View();
        }

        public ActionResult DeleteUser(int i)
        {
            Models.LogInDAL.delete(i);
            return View("Tables");
        }
        [HttpPost]
        public ActionResult AddUser(string n, string e, string p, string rp)
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
               // Session["logIn"] = e.Trim();
                ViewBag.Msg = "successfully signed in";
                return Redirect("~/Admin/AddUser");
            }
            else
            ViewBag.Msg = "Enter correct email";
            return View();
        }
    }
}
