namespace Medica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        KorisnikID = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 15),
                        Prezime = c.String(nullable: false, maxLength: 15),
                        JMBG = c.Int(nullable: false),
                        Mail = c.String(nullable: false),
                        Sifra = c.String(nullable: false),
                        Telefon = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KorisnikID);
            
            CreateTable(
                "dbo.Pregleds",
                c => new
                    {
                        PregledID = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        VrijemePocetka = c.Double(nullable: false),
                        VrijemeZavrsetka = c.Double(nullable: false),
                        Korisnik_KorisnikID = c.Int(),
                        Usluga_UslugaID = c.Int(),
                    })
                .PrimaryKey(t => t.PregledID)
                .ForeignKey("dbo.Korisniks", t => t.Korisnik_KorisnikID)
                .ForeignKey("dbo.Uslugas", t => t.Usluga_UslugaID)
                .Index(t => t.Korisnik_KorisnikID)
                .Index(t => t.Usluga_UslugaID);
            
            CreateTable(
                "dbo.Uslugas",
                c => new
                    {
                        UslugaID = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 100),
                        Cijena = c.Double(nullable: false),
                        Trajanje = c.Double(nullable: false),
                        Opis = c.String(),
                        ZaposleniID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UslugaID)
                .ForeignKey("dbo.Zaposlenis", t => t.ZaposleniID, cascadeDelete: true)
                .Index(t => t.ZaposleniID);
            
            CreateTable(
                "dbo.Zaposlenis",
                c => new
                    {
                        ZaposleniID = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 15),
                        Prezime = c.String(nullable: false, maxLength: 15),
                        Mail = c.String(nullable: false),
                        Sifra = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Opis = c.String(),
                        UlogaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZaposleniID)
                .ForeignKey("dbo.Ulogas", t => t.UlogaID, cascadeDelete: true)
                .Index(t => t.UlogaID);
            
            CreateTable(
                "dbo.RadnoVrijemes",
                c => new
                    {
                        RadnoVrijemeID = c.Int(nullable: false, identity: true),
                        Dan = c.Int(nullable: false),
                        SatiOd = c.Double(nullable: false),
                        SatiDo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RadnoVrijemeID);
            
            CreateTable(
                "dbo.Ulogas",
                c => new
                    {
                        UlogaID = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 50),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.UlogaID);
            
            CreateTable(
                "dbo.RadnoVrijemeZaposlenis",
                c => new
                    {
                        RadnoVrijeme_RadnoVrijemeID = c.Int(nullable: false),
                        Zaposleni_ZaposleniID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RadnoVrijeme_RadnoVrijemeID, t.Zaposleni_ZaposleniID })
                .ForeignKey("dbo.RadnoVrijemes", t => t.RadnoVrijeme_RadnoVrijemeID, cascadeDelete: true)
                .ForeignKey("dbo.Zaposlenis", t => t.Zaposleni_ZaposleniID, cascadeDelete: true)
                .Index(t => t.RadnoVrijeme_RadnoVrijemeID)
                .Index(t => t.Zaposleni_ZaposleniID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Uslugas", "ZaposleniID", "dbo.Zaposlenis");
            DropForeignKey("dbo.Zaposlenis", "UlogaID", "dbo.Ulogas");
            DropForeignKey("dbo.RadnoVrijemeZaposlenis", "Zaposleni_ZaposleniID", "dbo.Zaposlenis");
            DropForeignKey("dbo.RadnoVrijemeZaposlenis", "RadnoVrijeme_RadnoVrijemeID", "dbo.RadnoVrijemes");
            DropForeignKey("dbo.Pregleds", "Usluga_UslugaID", "dbo.Uslugas");
            DropForeignKey("dbo.Pregleds", "Korisnik_KorisnikID", "dbo.Korisniks");
            DropIndex("dbo.RadnoVrijemeZaposlenis", new[] { "Zaposleni_ZaposleniID" });
            DropIndex("dbo.RadnoVrijemeZaposlenis", new[] { "RadnoVrijeme_RadnoVrijemeID" });
            DropIndex("dbo.Zaposlenis", new[] { "UlogaID" });
            DropIndex("dbo.Uslugas", new[] { "ZaposleniID" });
            DropIndex("dbo.Pregleds", new[] { "Usluga_UslugaID" });
            DropIndex("dbo.Pregleds", new[] { "Korisnik_KorisnikID" });
            DropTable("dbo.RadnoVrijemeZaposlenis");
            DropTable("dbo.Ulogas");
            DropTable("dbo.RadnoVrijemes");
            DropTable("dbo.Zaposlenis");
            DropTable("dbo.Uslugas");
            DropTable("dbo.Pregleds");
            DropTable("dbo.Korisniks");
        }
    }
}
