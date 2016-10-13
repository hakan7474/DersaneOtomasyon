namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yeni : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alan",
                c => new
                    {
                        AlanId = c.Int(nullable: false, identity: true),
                        AlanAdi = c.String(nullable: false),
                        AlanAciklama = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AlanId);
            
            CreateTable(
                "dbo.Ogrenci",
                c => new
                    {
                        OgrenciId = c.Int(nullable: false, identity: true),
                        OgrenciAdi = c.String(nullable: false),
                        OgrenciSoyadi = c.String(nullable: false),
                        Okul = c.String(nullable: false),
                        AlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OgrenciId)
                .ForeignKey("dbo.Alan", t => t.AlanId, cascadeDelete: true)
                .Index(t => t.AlanId);
            
            CreateTable(
                "dbo.Odeme",
                c => new
                    {
                        OdemeId = c.Int(nullable: false, identity: true),
                        OdemeAciklama = c.String(nullable: false),
                        TaksitSayisi = c.Int(nullable: false),
                        ToplamUcret = c.Int(nullable: false),
                        OgrenciId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OdemeId)
                .ForeignKey("dbo.Ogrenci", t => t.OgrenciId, cascadeDelete: true)
                .Index(t => t.OgrenciId);
            
            CreateTable(
                "dbo.Veli",
                c => new
                    {
                        VeliId = c.Int(nullable: false, identity: true),
                        VeliAdi = c.String(nullable: false),
                        VeliAdres = c.String(nullable: false),
                        OgrenciId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VeliId)
                .ForeignKey("dbo.Ogrenci", t => t.OgrenciId, cascadeDelete: true)
                .Index(t => t.OgrenciId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Veli", "OgrenciId", "dbo.Ogrenci");
            DropForeignKey("dbo.Odeme", "OgrenciId", "dbo.Ogrenci");
            DropForeignKey("dbo.Ogrenci", "AlanId", "dbo.Alan");
            DropIndex("dbo.Veli", new[] { "OgrenciId" });
            DropIndex("dbo.Odeme", new[] { "OgrenciId" });
            DropIndex("dbo.Ogrenci", new[] { "AlanId" });
            DropTable("dbo.Veli");
            DropTable("dbo.Odeme");
            DropTable("dbo.Ogrenci");
            DropTable("dbo.Alan");
        }
    }
}
