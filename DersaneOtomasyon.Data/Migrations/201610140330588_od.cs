namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class od : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Odeme", "OdemeTarih", c => c.DateTime(nullable: false));
            DropColumn("dbo.Odeme", "OdemeTarihi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Odeme", "OdemeTarihi", c => c.Int(nullable: false));
            DropColumn("dbo.Odeme", "OdemeTarih");
        }
    }
}
