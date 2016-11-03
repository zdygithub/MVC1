namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BlogArtices", newName: "BlogArticles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.BlogArticles", newName: "BlogArtices");
        }
    }
}
