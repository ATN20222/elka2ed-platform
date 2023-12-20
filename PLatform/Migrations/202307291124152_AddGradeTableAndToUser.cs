namespace PLatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGradeTableAndToUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Grade_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Grade_Id");
            AddForeignKey("dbo.AspNetUsers", "Grade_Id", "dbo.Grades", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Grade_Id", "dbo.Grades");
            DropIndex("dbo.AspNetUsers", new[] { "Grade_Id" });
            DropColumn("dbo.AspNetUsers", "Grade_Id");
            DropTable("dbo.Grades");
        }
    }
}
