namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmienTYp6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skleps", "FormatTypSklep", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skleps", "FormatTypSklep");
        }
    }
}
