namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodajNip : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Skleps",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   Nazwa = c.String(nullable: false, maxLength: 255),
                   Nip = c.String(nullable: true),
                   KontaktId = c.Byte(nullable: false),
                   FormatSklepuId = c.Byte(nullable: false),
               })
               .PrimaryKey(t => t.Id)
               .ForeignKey("dbo.Kontakts", t => t.KontaktId, cascadeDelete: true)
               .Index(t => t.KontaktId)
            .ForeignKey("dbo.FormatSklepus", t => t.FormatSklepuId, cascadeDelete: true)
               .Index(t => t.FormatSklepuId);
          
        }
        
        public override void Down()
        {
           
        }
    }
}
