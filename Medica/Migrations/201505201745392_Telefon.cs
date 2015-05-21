namespace Medica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Telefon : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Korisniks", "Telefon", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Korisniks", "Telefon", c => c.Int(nullable: false));
        }
    }
}
