using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace facebook_asp_.Models
{
    public class datamodel : DbContext
    {
        public datamodel() : base("fasebookdb")
        {
        }
        public DbSet<userinfo> userinfos {get; set;}
        public DbSet<post> posts {get;set;}
        public DbSet<comments> comments {get;set;}
        public DbSet<reacts> reacts { get; set; }
        public DbSet<friends> friends { get; set; }
        public DbSet<friendRequstes> friendRequstes { get; set; }
    } 


    public class userinfo
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string lname { get; set; }
        public string photo { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public List<post> posts { get; set; }
        public List<friends> friends { get; set; }
        public List<friendRequstes> friendRequstes { get; set; }
        }

public class post
{
    public int Id {get;set;}
    public string postone {get; set;}
    public int iduserinfo { get; set; }
    public userinfo userinfo { get; set; }
    public List<comments> comments { get; set; }
    public List<reacts> reacts { get; set; }
}

public class comments
{
    public int Id { get; set; }
    public string comment { get; set; }


    public int idpost { get; set; }
    public int iduserinfo { get; set; }
    public post post { get; set; }
    public userinfo userinfo { get; set; }
}

public class reacts
{
    public int Id { get; set; }
    public string react { get; set; }


    public int idpost { get; set; }
    public int iduserinfo { get; set; }
    public post post { get; set; }
    public userinfo userinfo { get; set; }
}

public class friends
{
    public int Id { set; get; }
    public int iduserinfo { get; set; }
    public userinfo userinfo { get; set; }
}

public class friendRequstes
{
    public int Id { set; get; }
    public int iduserinfo { get; set; }
    public userinfo userinfo { get; set; }
}
}