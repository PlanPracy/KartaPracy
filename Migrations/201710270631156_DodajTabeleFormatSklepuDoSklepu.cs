namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodajTabeleFormatSklepuDoSklepu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FormatSklepus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        JakiFormatSklepu = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
           
        }
        
        public override void Down()
        {
           
        }
    }
}
