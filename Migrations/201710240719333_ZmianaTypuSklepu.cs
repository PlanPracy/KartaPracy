namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZmianaTypuSklepu : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Skleps", "FormatSklep", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Skleps", "FormatSklep", c => c.String(nullable: false));
        }
    }
}
