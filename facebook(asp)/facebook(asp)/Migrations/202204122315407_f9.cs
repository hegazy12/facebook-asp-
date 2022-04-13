namespace facebook_asp_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.posts", "role", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.posts", "role");
        }
    }
}
