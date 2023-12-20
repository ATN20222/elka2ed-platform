namespace PLatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnswersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        QuestionsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionsId, cascadeDelete: true)
                .Index(t => t.QuestionsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuestionsId", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "QuestionsId" });
            DropTable("dbo.Answers");
        }
    }
}
