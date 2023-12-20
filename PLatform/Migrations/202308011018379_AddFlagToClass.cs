namespace PLatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFlagToClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "IsAvailable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Classes", "IsAvailable");
        }
    }
}
