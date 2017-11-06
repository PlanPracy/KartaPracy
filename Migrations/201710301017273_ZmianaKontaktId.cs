namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZmianaKontaktId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skleps", "KontaktId", "dbo.Kontakts");
            DropIndex("dbo.Skleps", new[] { "KontaktId" });
            AlterColumn("dbo.Skleps", "KontaktId", c => c.Byte());
            CreateIndex("dbo.Skleps", "KontaktId");
            AddForeignKey("dbo.Skleps", "KontaktId", "dbo.Kontakts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skleps", "KontaktId", "dbo.Kontakts");
            DropIndex("dbo.Skleps", new[] { "KontaktId" });
            AlterColumn("dbo.Skleps", "KontaktId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Skleps", "KontaktId");
            AddForeignKey("dbo.Skleps", "KontaktId", "dbo.Kontakts", "Id", cascadeDelete: true);
        }
    }
}
