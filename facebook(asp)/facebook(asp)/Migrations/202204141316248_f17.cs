namespace facebook_asp_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.friendRequstes", "idfriend", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.friendRequstes", "idfriend");
        }
    }
}
