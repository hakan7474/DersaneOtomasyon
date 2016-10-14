namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ogrenci", "OgrenciTc", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ogrenci", "OgrenciTc", c => c.String(nullable: false));
        }
    }
}
