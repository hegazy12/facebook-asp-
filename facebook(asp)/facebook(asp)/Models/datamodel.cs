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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          /*  
           *  modelBuilder.Entity<post>()
                .HasMany(d => d.comments)
                .WithOptional()
                .WillCascadeOnDelete(true);
                
            modelBuilder.Entity<post>()
                .HasMany(d => d.reacts)
                .WithOptional()
                .WillCascadeOnDelete(true);
                
            modelBuilder.Entity<userinfo>()
                .HasMany(d => d.posts)
                .WithOptional()
                .WillCascadeOnDelete(true);
                
            modelBuilder.Entity<userinfo>()
                .HasMany(d => d.Comments)
                .WithOptional()
                .WillCascadeOnDelete(true);
                
            modelBuilder.Entity<userinfo>()
                .HasMany(d => d.friendRequstes)
                .WithOptional(u => u.userinfo)
                .WillCascadeOnDelete(true);
                
            modelBuilder.Entity<userinfo>()
                .HasMany(d => d.friends)
                .WithOptional()
                .WillCascadeOnDelete(true);
                
            modelBuilder.Entity<userinfo>()
                .HasMany(d => d.friendRequstes)
                .WithOptional()
                .WillCascadeOnDelete(true);
                
            modelBuilder.Entity<userinfo>()
                .HasMany(d => d.friendRequstes)
                .WithOptional()
                .WillCascadeOnDelete(true);
                
            modelBuilder.Entity<userinfo>()
                .HasMany(d => d.Reacts)
                .WithOptional()
                .WillCascadeOnDelete(true);
          */
        }
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
        
        public virtual List<reacts> Reacts {get; set;}
        public virtual List<comments> Comments { get; set;} 
        public virtual List<post> posts { get; set; }
        public virtual List<friends> friends { get; set; }
        public virtual List<friendRequstes> friendRequstes { get; set; }
        }

public class post
{
    public int Id {get;set;}
    public string postone {get; set;}
    public int iduserinfo { get; set; }
    public int role { get; set; }
    public virtual userinfo userinfo { get; set; }
    public virtual List<comments> comments { get; set; }
    public virtual List<reacts> reacts { get; set; }
}

public class comments
{
    public int Id { get; set; }
    public string comment { get; set; }


    public int idpost { get; set; }
    public int iduserinfo { get; set; }
    public virtual post post { get; set; }
    public virtual userinfo userinfo { get; set; }
}

public class reacts
{
    public int Id { get; set; }
    public int Like { get; set; }
    public int idpost { get; set; }
    
    public int iduserinfo { get; set; }
    public virtual post post { get; set; }
    public virtual userinfo userinfo { get; set; }
}

public class friends
{
    public int Id { set; get; }
    public int iduserinfo { get; set; }
    public int idfriend { get; set; }
    public virtual userinfo userinfo { get; set; }
}

public class friendRequstes
{
    public int Id {set;get;}
    public int idsender {get;set;}
    public int idfriend {get;set;}
    public virtual userinfo userinfo {get;set;}
}
}