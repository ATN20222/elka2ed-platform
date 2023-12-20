namespace PLatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExamUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentExams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        IsSubmitted = c.Boolean(nullable: false),
                        ExamId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .Index(t => t.ExamId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentExams", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.StudentExams", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.StudentExams", new[] { "ApplicationUserId" });
            DropIndex("dbo.StudentExams", new[] { "ExamId" });
            DropTable("dbo.StudentExams");
        }
    }
}
