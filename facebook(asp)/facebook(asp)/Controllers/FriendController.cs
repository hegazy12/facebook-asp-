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
            int iduser = Convert.ToInt32(Session["Iduser"]);
            int idfriend = Convert.ToInt32(id);
            db.friendRequstes.RemoveRange(db.friendRequstes.Where(m=>m.idsender == iduser && m.idfriend == idfriend).ToList());
            db.SaveChanges();
         
            friendRequstes friendRequstes = new friendRequstes();
            friendRequstes.idsender = iduser;
            friendRequstes.idfriend = idfriend;
            friendRequstes.userinfo = db.userinfos.Find(idfriend);
            db.friendRequstes.Add(friendRequstes);
            db.SaveChanges();
            return RedirectToAction("Index", "userinfoes");
        }


        public ActionResult Accept(int? id)
        {
            int iduser = Convert.ToInt32(Session["Iduser"]);
            int idfriend = Convert.ToInt32(id);
            db.friends.RemoveRange(db.friends.Where(m=>m.iduserinfo == iduser && m.idfriend == idfriend).ToList());
            db.SaveChanges();

            friends friend = new friends();
            friend.idfriend = idfriend;
            friend.iduserinfo = iduser;
            friend.userinfo = db.userinfos.Find(idfriend);
            db.friends.Add(friend);
            db.SaveChanges();
            
            return RedirectToAction("Index", "userinfoes");
        }

    }
}