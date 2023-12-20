namespace PLatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateExamQuestsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "mark", c => c.Int(nullable: false));
            AddColumn("dbo.Exams", "totalMark", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exams", "totalMark");
            DropColumn("dbo.Questions", "mark");
        }
    }
}
