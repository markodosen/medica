namespace Medica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JMBGchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Korisniks", "JMBG", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Korisniks", "JMBG", c => c.Int(nullable: false));
        }
    }
}
