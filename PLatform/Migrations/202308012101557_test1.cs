namespace PLatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "GradeId", "dbo.Grades");
            DropIndex("dbo.AspNetUsers", new[] { "GradeId" });
            DropColumn("dbo.AspNetUsers", "GradeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "GradeId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "GradeId");
            AddForeignKey("dbo.AspNetUsers", "GradeId", "dbo.Grades", "Id");
        }
    }
}
