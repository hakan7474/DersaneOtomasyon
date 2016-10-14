namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class odeme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Odeme", "TaksitNo", c => c.Int(nullable: false));
            AddColumn("dbo.Odeme", "OdenenTutar", c => c.Int(nullable: false));
            DropColumn("dbo.Odeme", "TaksitSayisi");
            DropColumn("dbo.Odeme", "ToplamUcret");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Odeme", "ToplamUcret", c => c.Int(nullable: false));
            AddColumn("dbo.Odeme", "TaksitSayisi", c => c.Int(nullable: false));
            DropColumn("dbo.Odeme", "OdenenTutar");
            DropColumn("dbo.Odeme", "TaksitNo");
        }
    }
}
