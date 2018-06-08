namespace NewsBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Replies", "Comment_Id", "dbo.Comments");
            DropIndex("dbo.Replies", new[] { "Comment_Id" });
            RenameColumn(table: "dbo.Comments", name: "Id", newName: "CommentId");
            DropTable("dbo.Replies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(nullable: false),
                        CommentBody = c.String(),
                        CommentTime = c.DateTime(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        UserId = c.String(),
                        Comment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            RenameColumn(table: "dbo.Comments", name: "CommentId", newName: "Id");
            CreateIndex("dbo.Replies", "Comment_Id");
            AddForeignKey("dbo.Replies", "Comment_Id", "dbo.Comments", "Id");
        }
    }
}
