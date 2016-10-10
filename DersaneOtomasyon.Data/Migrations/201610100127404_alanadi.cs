namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alanadi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alan", "SinifAdi", c => c.String(nullable: false));
            DropColumn("dbo.Alan", "Sayisal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Alan", "Sayisal", c => c.String(nullable: false));
            DropColumn("dbo.Alan", "SinifAdi");
        }
    }
}
