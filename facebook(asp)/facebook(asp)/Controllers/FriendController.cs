using facebook_asp_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace facebook_asp_.Controllers
{
    public class FriendController : Controller
    {
        private datamodel db = new datamodel();

        public ActionResult Addfriend(int? id)
        {
            friendRequstes friendRequstes = new friendRequstes();
            friendRequstes.idsender = Convert.ToInt32(Session["Iduser"]);
            friendRequstes.userinfo = db.userinfos.Find(id);
            db.friendRequstes.Add(friendRequstes);
            db.SaveChanges();
            return RedirectToAction("Index", "userinfoes");
        }
    }
}