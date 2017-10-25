namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TypSklepus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TypSklepus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Typ = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
