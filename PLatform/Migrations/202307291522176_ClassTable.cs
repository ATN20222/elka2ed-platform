namespace PLatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        VidSrc = c.String(),
                        Training = c.String(),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .Index(t => t.GradeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "GradeId", "dbo.Grades");
            DropIndex("dbo.Classes", new[] { "GradeId" });
            DropTable("dbo.Classes");
        }
    }
}
