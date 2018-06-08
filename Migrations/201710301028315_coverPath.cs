namespace NewsBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coverPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "CoverPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "CoverPath");
        }
    }
}
