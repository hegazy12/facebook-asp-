using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using facebook_asp_.Models;

namespace facebook_asp_.Controllers
{
    public class userinfoesController : Controller
    {
        private datamodel db = new datamodel();

        // GET: userinfoes
        public ActionResult Index()
        {
            if (Session["Iduser"] == "0" || Session["Iduser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            int x = Convert.ToInt32(Session["Iduser"]);

            List<userinfo> userinfos = db.userinfos.Where(m=>m.Id !=x).ToList();
            List<friends> friends = db.friends.Where(m => m.id_User == x).ToList();
            List<friendRequstes> requstes = db.friendRequstes.Where(m => m.id_UserSender == x).ToList();

            foreach(var item in friends){
                userinfos.Remove(item.userFriend);
            }
            foreach(var item in requstes)
            {
                userinfos.Remove(item.userFriend);
            }
            return View(userinfos);
        }

        // GET: userinfoes/Details/5
        public ActionResult Details(int? id)
        {   
            if (Session["Iduser"] == "0" || Session["Iduser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userinfo userinfo = db.userinfos.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        // GET: userinfoes/Create
        public ActionResult Create()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult Create(userinfo userinfo, string Repass, HttpPostedFileBase photo)
        {   
            if (userinfo.password != Repass)
            {
                return View(userinfo);
            }

            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    string _FileName = Path.GetFileName(photo.FileName);
                    string _path = Path.Combine(Server.MapPath("~/photos"), _FileName);
                    photo.SaveAs(_path);
                    userinfo.photo = "/photos/" + _FileName;
                }

                db.userinfos.Add(userinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userinfo);
        }

        // GET: userinfoes/Edit/5
        public ActionResult Edit()
        {   
            if (Session["Iduser"] == "0" || Session["Iduser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            int id = Convert.ToInt32(Session["Iduser"]);
            userinfo userinfo = db.userinfos.Find(id);
            
            return View(userinfo);
        }
         
        [HttpPost]
        public ActionResult Edit(userinfo userinfo, HttpPostedFileBase photo)
        {
            if(photo != null)
            {
                string _FileName = Path.GetFileName(photo.FileName);
                string _path = Path.Combine(Server.MapPath("~/photos"), _FileName);
                photo.SaveAs(_path);
                userinfo.photo = "/photos/" + _FileName;

            }
             
            if (ModelState.IsValid)
            {
                db.Entry(userinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userinfo);
        }

        // GET: userinfoes/Delete/5
        public ActionResult Delete(int? id)
        {   
            if (Session["Iduser"] == "0" || Session["Iduser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userinfo userinfo = db.userinfos.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }


        // POST: userinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            userinfo userinfo = db.userinfos.Find(id);
            db.userinfos.Remove(userinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
