namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alan",
                c => new
                    {
                        AlanId = c.Int(nullable: false, identity: true),
                        Sayisal = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AlanId);
            
            CreateTable(
                "dbo.Ogrenci",
                c => new
                    {
                        OgrenciId = c.Int(nullable: false, identity: true),
                        OgrenciAdi = c.String(nullable: false),
                        Soyadi = c.String(nullable: false),
                        DogumTarihi = c.DateTime(nullable: false),
                        KayitTarihi = c.DateTime(nullable: false),
                        AktifMi = c.Boolean(nullable: false),
                        AlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OgrenciId)
                .ForeignKey("dbo.Alan", t => t.AlanId, cascadeDelete: true)
                .Index(t => t.AlanId);
            
            CreateTable(
                "dbo.Il",
                c => new
                    {
                        IlId = c.Int(nullable: false, identity: true),
                        İlAdi = c.String(nullable: false),
                        OgrenciId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IlId)
                .ForeignKey("dbo.Ogrenci", t => t.OgrenciId, cascadeDelete: true)
                .Index(t => t.OgrenciId);
            
            CreateTable(
                "dbo.Odeme",
                c => new
                    {
                        OdemeId = c.Int(nullable: false, identity: true),
                        ToplamUcret = c.Int(nullable: false),
                        TaksitSayisi = c.Int(nullable: false),
                        OdemeAktif = c.Boolean(nullable: false),
                        OgrenciId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OdemeId)
                .ForeignKey("dbo.Ogrenci", t => t.OgrenciId, cascadeDelete: true)
                .Index(t => t.OgrenciId);
            
            CreateTable(
                "dbo.OgrenciResim",
                c => new
                    {
                        OgrResimId = c.Int(nullable: false, identity: true),
                        ResimAdi = c.String(nullable: false),
                        IcerikTipi = c.String(nullable: false),
                        Icerik = c.Binary(nullable: false),
                        OgrenciId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OgrResimId)
                .ForeignKey("dbo.Ogrenci", t => t.OgrenciId, cascadeDelete: true)
                .Index(t => t.OgrenciId);
            
            CreateTable(
                "dbo.Okul",
                c => new
                    {
                        OkulId = c.Int(nullable: false, identity: true),
                        OkulAdi = c.String(nullable: false),
                        OgrenciId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OkulId)
                .ForeignKey("dbo.Ogrenci", t => t.OgrenciId, cascadeDelete: true)
                .Index(t => t.OgrenciId);
            
            CreateTable(
                "dbo.Veli",
                c => new
                    {
                        VeliId = c.Int(nullable: false, identity: true),
                        VeliAd = c.String(nullable: false),
                        VeliSoyad = c.String(nullable: false),
                        Adres = c.String(nullable: false),
                        OgrenciId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VeliId)
                .ForeignKey("dbo.Ogrenci", t => t.OgrenciId, cascadeDelete: true)
                .Index(t => t.OgrenciId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Veli", "OgrenciId", "dbo.Ogrenci");
            DropForeignKey("dbo.Okul", "OgrenciId", "dbo.Ogrenci");
            DropForeignKey("dbo.OgrenciResim", "OgrenciId", "dbo.Ogrenci");
            DropForeignKey("dbo.Odeme", "OgrenciId", "dbo.Ogrenci");
            DropForeignKey("dbo.Il", "OgrenciId", "dbo.Ogrenci");
            DropForeignKey("dbo.Ogrenci", "AlanId", "dbo.Alan");
            DropIndex("dbo.Veli", new[] { "OgrenciId" });
            DropIndex("dbo.Okul", new[] { "OgrenciId" });
            DropIndex("dbo.OgrenciResim", new[] { "OgrenciId" });
            DropIndex("dbo.Odeme", new[] { "OgrenciId" });
            DropIndex("dbo.Il", new[] { "OgrenciId" });
            DropIndex("dbo.Ogrenci", new[] { "AlanId" });
            DropTable("dbo.Veli");
            DropTable("dbo.Okul");
            DropTable("dbo.OgrenciResim");
            DropTable("dbo.Odeme");
            DropTable("dbo.Il");
            DropTable("dbo.Ogrenci");
            DropTable("dbo.Alan");
        }
    }
}
