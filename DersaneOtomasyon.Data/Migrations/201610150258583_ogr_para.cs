namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ogr_para : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ogrenci", "Fiyat", c => c.Double(nullable: false));
            AlterColumn("dbo.Odeme", "OdenenTutar", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Odeme", "OdenenTutar", c => c.Int(nullable: false));
            AlterColumn("dbo.Ogrenci", "Fiyat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
