namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodajKontaktTelefonIMail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kontakts", "OsobaDoKontaktu", c => c.String());
            AddColumn("dbo.Kontakts", "Telefon", c => c.String());
            AddColumn("dbo.Kontakts", "Email", c => c.String());
            AddColumn("dbo.Kontakts", "Opis", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kontakts", "Opis");
            DropColumn("dbo.Kontakts", "Email");
            DropColumn("dbo.Kontakts", "Telefon");
            DropColumn("dbo.Kontakts", "OsobaDoKontaktu");
        }
    }
}
