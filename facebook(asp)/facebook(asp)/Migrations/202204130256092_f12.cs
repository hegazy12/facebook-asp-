namespace facebook_asp_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.comments", "post_Id", "dbo.posts");
            AddForeignKey("dbo.comments", "post_Id", "dbo.posts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.comments", "post_Id", "dbo.posts");
            AddForeignKey("dbo.comments", "post_Id", "dbo.posts", "Id", cascadeDelete: true);
        }
    }
}
