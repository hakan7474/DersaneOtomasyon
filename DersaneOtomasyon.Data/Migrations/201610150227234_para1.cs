namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class para1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ogrenci", "OgrenciTc", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ogrenci", "OgrenciTc", c => c.String());
        }
    }
}
