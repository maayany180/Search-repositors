using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectAtGitHub.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Search()//search page
        {
            ViewBag.Title = "Home Page";
            Session["BookMark"] = " ";
            return View();
        }

        public ActionResult AddBookMark(string ID)//Add to bookmark
        {
           
           if(Session["BookMark"] == null  || Session["BookMark"].GetType() != typeof(Dictionary<string, string>))
            {
                Session["BookMark"] =new Dictionary<string, string>();
            }

            ((Dictionary<string, string>)Session["BookMark"]).Add(ID,"https://github.com/"+ID);


            return Json(new object(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult action()//Viewing bookmarks
        {
            if (Session["BookMark"].ToString()==" ")
            {
                ViewBag.note = "Once you add repositories to your bookmark, you can view them using the links shown here";
            }
            else
            {
                ViewBag.note = "Links to selected repositories";
            }
            return View();
        }

    }
}
