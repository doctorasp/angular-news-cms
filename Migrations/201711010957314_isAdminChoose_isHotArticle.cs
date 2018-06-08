namespace NewsBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isAdminChoose_isHotArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "isAdminChoose", c => c.Boolean(nullable: false));
            AddColumn("dbo.Articles", "isHotArticle", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "isHotArticle");
            DropColumn("dbo.Articles", "isAdminChoose");
        }
    }
}
