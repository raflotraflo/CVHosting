namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cvFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CVFile", "FileName", c => c.String());
            AddColumn("dbo.CVFile", "ContentType", c => c.String());
            AddColumn("dbo.CVFile", "ContentLength", c => c.Int(nullable: false));
            AlterColumn("dbo.CVFile", "Content", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CVFile", "Content", c => c.Binary(nullable: false));
            DropColumn("dbo.CVFile", "ContentLength");
            DropColumn("dbo.CVFile", "ContentType");
            DropColumn("dbo.CVFile", "FileName");
        }
    }
}
