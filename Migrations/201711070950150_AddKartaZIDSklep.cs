namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKartaZIDSklep : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KartaKontaktus", "Sklep_Id", "dbo.Skleps");
            DropIndex("dbo.KartaKontaktus", new[] { "Sklep_Id" });
            RenameColumn(table: "dbo.KartaKontaktus", name: "Sklep_Id", newName: "SklepId");
            AlterColumn("dbo.KartaKontaktus", "SklepId", c => c.Int(nullable: false));
            CreateIndex("dbo.KartaKontaktus", "SklepId");
            AddForeignKey("dbo.KartaKontaktus", "SklepId", "dbo.Skleps", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KartaKontaktus", "SklepId", "dbo.Skleps");
            DropIndex("dbo.KartaKontaktus", new[] { "SklepId" });
            AlterColumn("dbo.KartaKontaktus", "SklepId", c => c.Int());
            RenameColumn(table: "dbo.KartaKontaktus", name: "SklepId", newName: "Sklep_Id");
            CreateIndex("dbo.KartaKontaktus", "Sklep_Id");
            AddForeignKey("dbo.KartaKontaktus", "Sklep_Id", "dbo.Skleps", "Id");
        }
    }
}
