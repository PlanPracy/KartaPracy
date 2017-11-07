namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKarta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KartaKontaktus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataSpotkania = c.DateTime(nullable: false),
                        FormaKontaktu = c.String(),
                        Notatki = c.String(),
                        Sklep_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skleps", t => t.Sklep_Id)
                .Index(t => t.Sklep_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KartaKontaktus", "Sklep_Id", "dbo.Skleps");
            DropIndex("dbo.KartaKontaktus", new[] { "Sklep_Id" });
            DropTable("dbo.KartaKontaktus");
        }
    }
}
