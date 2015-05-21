namespace Medica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PregledStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pregleds", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pregleds", "Status");
        }
    }
}
