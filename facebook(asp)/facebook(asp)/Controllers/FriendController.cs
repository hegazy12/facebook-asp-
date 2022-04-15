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
            db.friendRequstes.RemoveRange(db.friendRequstes.Where(m=>m.id_UserSender == iduser && m.id_userFriend == idfriend).ToList());
            db.SaveChanges();
         
            friendRequstes friendRequstes = new friendRequstes();
            friendRequstes.id_UserSender = iduser;
            friendRequstes.UserSender = db.userinfos.Find(iduser);

            friendRequstes.id_userFriend = idfriend;
            friendRequstes.userFriend = db.userinfos.Find(idfriend);
            

            db.friendRequstes.Add(friendRequstes);
            db.SaveChanges();
            return RedirectToAction("Index", "userinfoes");
        }


        public ActionResult Accept(int? id)
        {
            int iduser = Convert.ToInt32(Session["Iduser"]);
            int idfriend = Convert.ToInt32(id);
            db.friends.RemoveRange(db.friends.Where(m=>m.id_User == iduser && m.id_userFriend == idfriend).ToList());
            db.SaveChanges();

            friends friend = new friends();
            
            friend.id_User = iduser;
            friend.User = db.userinfos.Find(iduser);

            friend.id_userFriend = idfriend;
            friend.userFriend = db.userinfos.Find(idfriend);

            db.friends.Add(friend);
            db.SaveChanges();
            
            return RedirectToAction("Index", "userinfoes");
        }

    }
}