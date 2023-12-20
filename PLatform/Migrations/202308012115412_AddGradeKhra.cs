namespace PLatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGradeKhra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GradeId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "GradeId");
            AddForeignKey("dbo.AspNetUsers", "GradeId", "dbo.Grades", "Id", cascadeDelete: true);
        
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "GradeId", "dbo.Grades");
            DropIndex("dbo.AspNetUsers", new[] { "GradeId" });
            DropColumn("dbo.AspNetUsers", "GradeId");
        }
    }
}
