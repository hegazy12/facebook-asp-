namespace facebook_asp_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.friendRequstes", "idsender", c => c.Int(nullable: false));
            DropColumn("dbo.friendRequstes", "iduserinfo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.friendRequstes", "iduserinfo", c => c.Int(nullable: false));
            DropColumn("dbo.friendRequstes", "idsender");
        }
    }
}
