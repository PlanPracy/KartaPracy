namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuńFormatSklepu : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Skleps", "FormatSklep");
            DropColumn("dbo.Skleps", "FormatTypSklep");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skleps", "FormatTypSklep", c => c.Int(nullable: false));
            AddColumn("dbo.Skleps", "FormatSklep", c => c.String());
        }
    }
}
