namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class odeme_tarih1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Odeme", "OdemeTarihi", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Odeme", "OdemeTarihi", c => c.Int(nullable: false));
        }
    }
}
