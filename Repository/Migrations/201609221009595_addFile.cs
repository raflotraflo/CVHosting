namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFile : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CVApplication", "CVFileId");
            AddForeignKey("dbo.CVApplication", "CVFileId", "dbo.CVFile", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CVApplication", "CVFileId", "dbo.CVFile");
            DropIndex("dbo.CVApplication", new[] { "CVFileId" });
        }
    }
}
