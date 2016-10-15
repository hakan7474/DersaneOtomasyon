namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fiyatlar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Odeme", "Fiyat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Odeme", "OdenenTutar");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Odeme", "OdenenTutar", c => c.Int(nullable: false));
            DropColumn("dbo.Odeme", "Fiyat");
        }
    }
}
