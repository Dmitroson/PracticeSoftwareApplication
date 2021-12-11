namespace PracticeSoftwareApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeachersAndSubjectsTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        SubjectId = c.Guid(nullable: false),
                        WorkPlace = c.String(),
                        ImagePath = c.String(),
                        Votes = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Teachers", new[] { "SubjectId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
        }
    }
}
