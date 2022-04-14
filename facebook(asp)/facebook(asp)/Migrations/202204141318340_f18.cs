namespace facebook_asp_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.friends", "idfriend", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.friends", "idfriend");
        }
    }
}
