namespace NewsBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
        }
    }
}
