namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlogArticles", "Subject", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.BlogArticles", "Body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlogArticles", "Body", c => c.String());
            AlterColumn("dbo.BlogArticles", "Subject", c => c.String());
        }
    }
}
