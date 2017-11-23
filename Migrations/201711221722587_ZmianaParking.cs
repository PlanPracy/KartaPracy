namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZmianaParking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skleps", "CzyParking", c => c.Boolean(nullable: false));
            DropColumn("dbo.Skleps", "TypParking");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skleps", "TypParking", c => c.Boolean(nullable: false));
            DropColumn("dbo.Skleps", "CzyParking");
        }
    }
}
