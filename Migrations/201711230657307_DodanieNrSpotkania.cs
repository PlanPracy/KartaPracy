namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodanieNrSpotkania : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KartaKontaktus", "NrSpotkania", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KartaKontaktus", "NrSpotkania");
        }
    }
}
