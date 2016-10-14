namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ogrenci", "OgrenciTc", c => c.String(nullable: false));
            AddColumn("dbo.Veli", "VeliTc", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Veli", "VeliTc");
            DropColumn("dbo.Ogrenci", "OgrenciTc");
        }
    }
}
