namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JakiesZmiany : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KartaKontaktus", "Notatki", c => c.String(maxLength: 512));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KartaKontaktus", "Notatki", c => c.String());
        }
    }
}
