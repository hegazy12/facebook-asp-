using facebook_asp_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace facebook_asp_.Controllers
{
    public class ReactController : ApiController
    {
        private datamodel db = new datamodel();
        public string post()
        {
            try
            {   
                int iduser = Convert.ToInt32(HttpContext.Current.Request.Form["iduser"]);
                int idpost = Convert.ToInt32(HttpContext.Current.Request.Form["idpost"]);
                int rea = Convert.ToInt32(HttpContext.Current.Request.Form["react"]);
                

                db.reacts.RemoveRange(db.reacts.Where(m=>m.idpost==idpost && m.iduserinfo==idpost).ToList());
                db.SaveChanges();

                reacts react = new reacts();
                react.userinfo = db.userinfos.Find(iduser);
                react.iduserinfo = iduser;
                react.post = db.posts.Find(idpost);
                react.idpost = idpost;
                react.Like = rea;
                db.reacts.Add(react);
                db.SaveChanges();

                return "goodjob";
            }
            catch
            {
                return "badjob";
            } 
        }
    }
}