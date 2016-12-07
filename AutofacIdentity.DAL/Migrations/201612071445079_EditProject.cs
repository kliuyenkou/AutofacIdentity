namespace AutofacIdentity.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditProject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "CreatorId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "CreatorId" });
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Projects", "Description", c => c.String(maxLength: 256));
            AlterColumn("dbo.Projects", "CreatorId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Projects", "CreatorId");
            AddForeignKey("dbo.Projects", "CreatorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "CreatorId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "CreatorId" });
            AlterColumn("dbo.Projects", "CreatorId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Projects", "Description", c => c.String());
            AlterColumn("dbo.Projects", "Title", c => c.String());
            CreateIndex("dbo.Projects", "CreatorId");
            AddForeignKey("dbo.Projects", "CreatorId", "dbo.AspNetUsers", "Id");
        }
    }
}
