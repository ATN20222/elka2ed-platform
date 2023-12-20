namespace PLatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExamTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DurationInMinutes = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        CorrectOptionIndex = c.Int(nullable: false),
                        ExamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .Index(t => t.ExamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Exams", "ClassId", "dbo.Classes");
            DropIndex("dbo.Questions", new[] { "ExamId" });
            DropIndex("dbo.Exams", new[] { "ClassId" });
            DropTable("dbo.Questions");
            DropTable("dbo.Exams");
        }
    }
}
