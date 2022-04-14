using facebook_asp_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        public ActionResult Myfriend(int? id)
        {
            userinfo userinfo = new userinfo();

            try
            {
                userinfo = db.userinfos.Find(Convert.ToInt32(id));
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

            return View(userinfo);
        }
        public ActionResult MyFriends(int? id)
        {
            return View();
        }

        // GET: posts/EditPost/5
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost]
        public ActionResult EditPost(FormCollection form)
        {


            post post = new post();
            post.postone = form["postcon"];
            post.role = Convert.ToInt32(form["role"]);
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

    }
}