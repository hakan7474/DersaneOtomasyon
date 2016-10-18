namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Odemetarih : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Odeme", "OdemeTarihi", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Odeme", "OdemeTarihi");
        }
    }
}
