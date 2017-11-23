namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZmianaSklepu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skleps", "NrLokalu", c => c.String());
            AddColumn("dbo.Skleps", "Powierzchnia", c => c.String());
            AddColumn("dbo.Skleps", "TypSklepu", c => c.String());
           
            AlterColumn("dbo.Kontakts", "Telefon", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kontakts", "Telefon", c => c.String());
           
            DropColumn("dbo.Skleps", "TypSklepu");
            DropColumn("dbo.Skleps", "Powierzchnia");
            DropColumn("dbo.Skleps", "NrLokalu");
        }
    }
}
