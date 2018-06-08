namespace NewsBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coversModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoverPaths",
                c => new
                    {
                        CoverPathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ArticleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CoverPathId)
                .ForeignKey("dbo.Articles", t => t.ArticleID, cascadeDelete: true)
                .Index(t => t.ArticleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoverPaths", "ArticleID", "dbo.Articles");
            DropIndex("dbo.CoverPaths", new[] { "ArticleID" });
            DropTable("dbo.CoverPaths");
        }
    }
}
