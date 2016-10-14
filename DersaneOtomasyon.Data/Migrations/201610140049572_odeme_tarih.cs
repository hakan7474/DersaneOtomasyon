namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class odeme_tarih : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Odeme", "OdemeTarihi", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Odeme", "OdemeTarihi");
        }
    }
}
