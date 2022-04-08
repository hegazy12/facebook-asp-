using facebook_asp_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace facebook_asp_.Controllers
{
    public class PorfileController : Controller
    {
        private datamodel db = new datamodel();

        // GET: Porfile
        public ActionResult Index()
        {
            if(Session["Iduser"] == "0" || Session["Iduser"] == null)
            {
                return RedirectToAction("Index","Home");
            }
            userinfo userinfo = db.userinfos.Find(Convert.ToInt32(Session["Iduser"]));
            if (userinfo == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(userinfo);
        }


        public ActionResult creatpost(string postcon)
        {

            if (Session["Iduser"] == "0" || Session["Iduser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                userinfo userinfo = db.userinfos.Find(Convert.ToInt32(Session["Iduser"]));
                post post = new post { postone = postcon, userinfo = userinfo };
                db.posts.Add(post);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }
    }
}