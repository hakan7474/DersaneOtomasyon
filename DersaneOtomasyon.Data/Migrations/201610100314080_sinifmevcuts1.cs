namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sinifmevcuts1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ogrenci", "DogumTarihi");
            DropColumn("dbo.Ogrenci", "KayitTarihi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ogrenci", "KayitTarihi", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ogrenci", "DogumTarihi", c => c.DateTime(nullable: false));
        }
    }
}
