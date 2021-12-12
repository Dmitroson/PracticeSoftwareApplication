namespace PracticeSoftwareApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserReferenceToTeacherEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Teachers", "ApplicationUserId");
            AddForeignKey("dbo.Teachers", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Teachers", new[] { "ApplicationUserId" });
            DropColumn("dbo.Teachers", "ApplicationUserId");
        }
    }
}
