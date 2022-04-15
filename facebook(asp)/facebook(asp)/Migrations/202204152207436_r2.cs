namespace facebook_asp_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.friendRequstes", "id_UserSender", c => c.Int(nullable: false));
            AddColumn("dbo.friendRequstes", "id_userFriend", c => c.Int(nullable: false));
            AddColumn("dbo.friendRequstes", "userFriend_Id", c => c.Int());
            AddColumn("dbo.friendRequstes", "UserSender_Id", c => c.Int());
            AddColumn("dbo.friends", "id_User", c => c.Int(nullable: false));
            AddColumn("dbo.friends", "id_userFriend", c => c.Int(nullable: false));
            AddColumn("dbo.friends", "User_Id", c => c.Int());
            AddColumn("dbo.friends", "userFriend_Id", c => c.Int());
            CreateIndex("dbo.friendRequstes", "userFriend_Id");
            CreateIndex("dbo.friendRequstes", "UserSender_Id");
            CreateIndex("dbo.friends", "User_Id");
            CreateIndex("dbo.friends", "userFriend_Id");
            AddForeignKey("dbo.friendRequstes", "userFriend_Id", "dbo.userinfoes", "Id");
            AddForeignKey("dbo.friendRequstes", "UserSender_Id", "dbo.userinfoes", "Id");
            AddForeignKey("dbo.friends", "User_Id", "dbo.userinfoes", "Id");
            AddForeignKey("dbo.friends", "userFriend_Id", "dbo.userinfoes", "Id");
            DropColumn("dbo.friendRequstes", "idsender");
            DropColumn("dbo.friendRequstes", "idfriend");
            DropColumn("dbo.friends", "iduserinfo");
            DropColumn("dbo.friends", "idfriend");
        }
        
        public override void Down()
        {
            AddColumn("dbo.friends", "idfriend", c => c.Int(nullable: false));
            AddColumn("dbo.friends", "iduserinfo", c => c.Int(nullable: false));
            AddColumn("dbo.friendRequstes", "idfriend", c => c.Int(nullable: false));
            AddColumn("dbo.friendRequstes", "idsender", c => c.Int(nullable: false));
            DropForeignKey("dbo.friends", "userFriend_Id", "dbo.userinfoes");
            DropForeignKey("dbo.friends", "User_Id", "dbo.userinfoes");
            DropForeignKey("dbo.friendRequstes", "UserSender_Id", "dbo.userinfoes");
            DropForeignKey("dbo.friendRequstes", "userFriend_Id", "dbo.userinfoes");
            DropIndex("dbo.friends", new[] { "userFriend_Id" });
            DropIndex("dbo.friends", new[] { "User_Id" });
            DropIndex("dbo.friendRequstes", new[] { "UserSender_Id" });
            DropIndex("dbo.friendRequstes", new[] { "userFriend_Id" });
            DropColumn("dbo.friends", "userFriend_Id");
            DropColumn("dbo.friends", "User_Id");
            DropColumn("dbo.friends", "id_userFriend");
            DropColumn("dbo.friends", "id_User");
            DropColumn("dbo.friendRequstes", "UserSender_Id");
            DropColumn("dbo.friendRequstes", "userFriend_Id");
            DropColumn("dbo.friendRequstes", "id_userFriend");
            DropColumn("dbo.friendRequstes", "id_UserSender");
        }
    }
}
