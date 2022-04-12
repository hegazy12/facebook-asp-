namespace facebook_asp_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.posts", "iduserinfo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.posts", "iduserinfo");
        }
    }
}
