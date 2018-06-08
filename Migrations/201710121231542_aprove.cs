namespace NewsBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aprove : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "isAprove", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "isAprove");
        }
    }
}
