namespace NewsBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Replies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ParentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "ParentId");
        }
    }
}
