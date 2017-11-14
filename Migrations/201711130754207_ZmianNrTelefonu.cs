namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZmianNrTelefonu : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kontakts", "Telefon", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kontakts", "Telefon", c => c.String());
        }
    }
}
