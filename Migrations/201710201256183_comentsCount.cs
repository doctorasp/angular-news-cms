namespace NewsBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comentsCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "CommentsCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "CommentsCount");
        }
    }
}
