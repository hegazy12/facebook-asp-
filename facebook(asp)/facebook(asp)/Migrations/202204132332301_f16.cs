namespace facebook_asp_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f16 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.reacts", "Dislike");
        }
        
        public override void Down()
        {
            AddColumn("dbo.reacts", "Dislike", c => c.Int(nullable: false));
        }
    }
}