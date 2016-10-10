namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sinifmevcut : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alan", "SinifMevcut", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Alan", "SinifMevcut");
        }
    }
}
