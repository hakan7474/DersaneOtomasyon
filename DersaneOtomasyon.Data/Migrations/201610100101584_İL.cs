namespace DersaneOtomasyon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class İL : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Il", "OgrenciId", "dbo.Ogrenci");
            DropIndex("dbo.Il", new[] { "OgrenciId" });
            DropTable("dbo.Il");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Il",
                c => new
                    {
                        IlId = c.Int(nullable: false, identity: true),
                        İlAdi = c.String(nullable: false),
                        OgrenciId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IlId);
            
            CreateIndex("dbo.Il", "OgrenciId");
            AddForeignKey("dbo.Il", "OgrenciId", "dbo.Ogrenci", "OgrenciId", cascadeDelete: true);
        }
    }
}
