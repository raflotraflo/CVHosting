namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CVApplication", "CVFileId", "dbo.CVFile");
            DropIndex("dbo.CVApplication", new[] { "CVFileId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.CVApplication", "CVFileId");
            AddForeignKey("dbo.CVApplication", "CVFileId", "dbo.CVFile", "Id");
        }
    }
}
