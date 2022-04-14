namespace facebook_asp_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f14 : DbMigration
    {
        public override void Up()
        {
            AddColumn( "dbo.reacts" , "Like" ,c=>c.Int(nullable: false));
            AddColumn( "dbo.reacts" , "Dislike" , c=>c.Int(nullable: false));
            DropColumn( "dbo.reacts" , "react" );
        }
        
        public override void Down()
        {
            AddColumn("dbo.reacts","react",c=>c.String());
            DropColumn("dbo.reacts","Dislike");
            DropColumn("dbo.reacts","Like");
        }
    }
}
