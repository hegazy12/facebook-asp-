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
            
            int x = Convert.ToInt32(Session["Iduser"]);

            userinfo userinfo = new userinfo();
            userinfo = db.userinfos.Find(x);
            userinfo.posts = db.posts.Where(m => m.iduserinfo == x).ToList();

            if (userinfo == null)
            {
                return RedirectToAction("Index", "Home");
            }
            
            return View(userinfo);
        }

        [HttpGet]
        public ActionResult creatpost()
        {

            return View();
        }

        [HttpPost]
        public ActionResult creatpost(string postcon)
        {
            try
            {
                int x = Convert.ToInt32(Session["Iduser"]);
                userinfo userinfo = db.userinfos.Find(Convert.ToInt32(Session["Iduser"]));
                post post = new post { postone = postcon, userinfo = userinfo };
                post.iduserinfo = x;
                db.posts.Add(post);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }



            return RedirectToAction("Index", "porfile");
        }
    }
}