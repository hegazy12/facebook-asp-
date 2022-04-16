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
            if (Session["Iduser"] == "0" || Session["Iduser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
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
            if (Session["Iduser"] == "0" || Session["Iduser"] == null || id==null)
            {
                return RedirectToAction("Index", "Home");
            }
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

        public ActionResult MyFriends()
        {
            if (Session["Iduser"] == "0" || Session["Iduser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int x1 = Convert.ToInt32(Session["Iduser"]);
            List<friends> friends = db.friends.Where(x => x.id_User == x1).ToList();
            
            return View(friends);
        }

        public ActionResult MyRequests()
        {
            if (Session["Iduser"] == "0" || Session["Iduser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int x1 = Convert.ToInt32(Session["Iduser"]);
            List<friendRequstes> Requstes = db.friendRequstes.Where(x => x.id_userFriend == x1).ToList();
            
            return View(Requstes);
        }

        public ActionResult MyReq()
        {
            if (Session["Iduser"] == "0" || Session["Iduser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int x1 = Convert.ToInt32(Session["Iduser"]);
            List<friendRequstes> Requstes = db.friendRequstes.Where(x => x.id_UserSender == x1).ToList();
            return View(Requstes);

        }



        // GET: Porfile/EditPost/5
        public ActionResult EditPost(int? id)
        {
            if (Session["Iduser"] == "0" || Session["Iduser"] == null || id==null)
            {
                return RedirectToAction("Index", "Home");
            }
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
        public ActionResult EditPost(int? id,FormCollection form)
        {   

            post post = new post();
            post = db.posts.Find(Convert.ToInt32(id));
            post.postone = form["postcon"];
            post.role = Convert.ToInt32(form["role"]);
            post.userinfo = db.userinfos.Find(Convert.ToInt32(Session["Iduser"]));
            post.iduserinfo = Convert.ToInt32(Session["Iduser"]);
            
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