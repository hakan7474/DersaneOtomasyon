namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Odeme", "OdemeTarih");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Odeme", "OdemeTarih", c => c.DateTime(nullable: false));
        }
    }
}
