namespace facebook_asp_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        comment = c.String(),
                        idpost = c.Int(nullable: false),
                        iduserinfo = c.Int(nullable: false),
                        post_Id = c.Int(),
                        userinfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.posts", t => t.post_Id)
                .ForeignKey("dbo.userinfoes", t => t.userinfo_Id)
                .Index(t => t.post_Id)
                .Index(t => t.userinfo_Id);
            
            CreateTable(
                "dbo.posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        postone = c.String(),
                        userinfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.userinfoes", t => t.userinfo_Id)
                .Index(t => t.userinfo_Id);
            
            CreateTable(
                "dbo.reacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        react = c.String(),
                        idpost = c.Int(nullable: false),
                        iduserinfo = c.Int(nullable: false),
                        post_Id = c.Int(),
                        userinfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.posts", t => t.post_Id)
                .ForeignKey("dbo.userinfoes", t => t.userinfo_Id)
                .Index(t => t.post_Id)
                .Index(t => t.userinfo_Id);
            
            CreateTable(
                "dbo.userinfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fname = c.String(),
                        lname = c.String(),
                        photo = c.String(),
                        city = c.String(),
                        country = c.String(),
                        email = c.String(),
                        phone = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.friendRequstes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        iduserinfo = c.Int(nullable: false),
                        userinfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.userinfoes", t => t.userinfo_Id)
                .Index(t => t.userinfo_Id);
            
            CreateTable(
                "dbo.friends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        iduserinfo = c.Int(nullable: false),
                        userinfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.userinfoes", t => t.userinfo_Id)
                .Index(t => t.userinfo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.comments", "userinfo_Id", "dbo.userinfoes");
            DropForeignKey("dbo.reacts", "userinfo_Id", "dbo.userinfoes");
            DropForeignKey("dbo.posts", "userinfo_Id", "dbo.userinfoes");
            DropForeignKey("dbo.friends", "userinfo_Id", "dbo.userinfoes");
            DropForeignKey("dbo.friendRequstes", "userinfo_Id", "dbo.userinfoes");
            DropForeignKey("dbo.reacts", "post_Id", "dbo.posts");
            DropForeignKey("dbo.comments", "post_Id", "dbo.posts");
            DropIndex("dbo.friends", new[] { "userinfo_Id" });
            DropIndex("dbo.friendRequstes", new[] { "userinfo_Id" });
            DropIndex("dbo.reacts", new[] { "userinfo_Id" });
            DropIndex("dbo.reacts", new[] { "post_Id" });
            DropIndex("dbo.posts", new[] { "userinfo_Id" });
            DropIndex("dbo.comments", new[] { "userinfo_Id" });
            DropIndex("dbo.comments", new[] { "post_Id" });
            DropTable("dbo.friends");
            DropTable("dbo.friendRequstes");
            DropTable("dbo.userinfoes");
            DropTable("dbo.reacts");
            DropTable("dbo.posts");
            DropTable("dbo.comments");
        }
    }
}
