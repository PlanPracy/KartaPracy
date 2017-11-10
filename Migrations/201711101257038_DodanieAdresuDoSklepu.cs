namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieAdresuDoSklepu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skleps", "Miejscowosc", c => c.String(nullable: false));
            AddColumn("dbo.Skleps", "Ulica", c => c.String(nullable: false));
            AddColumn("dbo.Skleps", "Kod", c => c.String());
            AddColumn("dbo.Skleps", "Uwagi", c => c.String());
            AddColumn("dbo.Skleps", "TypParking", c => c.String());
            AddColumn("dbo.Skleps", "CzySieciowy", c => c.Boolean(nullable: false));
            AddColumn("dbo.Skleps", "DataUtworzeniaSklepu", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skleps", "DataUtworzeniaSklepu");
            DropColumn("dbo.Skleps", "CzySieciowy");
            DropColumn("dbo.Skleps", "TypParking");
            DropColumn("dbo.Skleps", "Uwagi");
            DropColumn("dbo.Skleps", "Kod");
            DropColumn("dbo.Skleps", "Ulica");
            DropColumn("dbo.Skleps", "Miejscowosc");
        }
    }
}
