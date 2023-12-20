namespace PLatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPointsToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "points", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "points");
        }
    }
}
