namespace NewsBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class localImg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CoverPaths", "ArticleID", "dbo.Articles");
            DropIndex("dbo.CoverPaths", new[] { "ArticleID" });
            DropColumn("dbo.Articles", "Cover");
            DropTable("dbo.CoverPaths");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CoverPaths",
                c => new
                    {
                        CoverPathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ArticleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CoverPathId);
            
            AddColumn("dbo.Articles", "Cover", c => c.Binary());
            CreateIndex("dbo.CoverPaths", "ArticleID");
            AddForeignKey("dbo.CoverPaths", "ArticleID", "dbo.Articles", "ID", cascadeDelete: true);
        }
    }
}
