namespace KartaPracy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TworzenieTabeli : DbMigration
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
            
            CreateTable(
                "dbo.KartaKontaktus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SklepId = c.Int(nullable: false),
                        DataSpotkania = c.DateTime(nullable: false),
                        FormaKontaktu = c.String(),
                        Notatki = c.String(maxLength: 512),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skleps", t => t.SklepId, cascadeDelete: true)
                .Index(t => t.SklepId);
            
            CreateTable(
                "dbo.Skleps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false, maxLength: 255),
                        KontaktId = c.Byte(nullable: false),
                        FormatSklepuId = c.Byte(nullable: false),
                        Nip = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FormatSklepus", t => t.FormatSklepuId, cascadeDelete: true)
                .ForeignKey("dbo.Kontakts", t => t.KontaktId, cascadeDelete: true)
                .Index(t => t.KontaktId)
                .Index(t => t.FormatSklepuId);
            
            CreateTable(
                "dbo.Kontakts",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Nazwisko = c.String(nullable: false),
                        OsobaDoKontaktu = c.String(),
                        Telefon = c.String(),
                        Email = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.KartaKontaktus", "SklepId", "dbo.Skleps");
            DropForeignKey("dbo.Skleps", "KontaktId", "dbo.Kontakts");
            DropForeignKey("dbo.Skleps", "FormatSklepuId", "dbo.FormatSklepus");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Skleps", new[] { "FormatSklepuId" });
            DropIndex("dbo.Skleps", new[] { "KontaktId" });
            DropIndex("dbo.KartaKontaktus", new[] { "SklepId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Kontakts");
            DropTable("dbo.Skleps");
            DropTable("dbo.KartaKontaktus");
            DropTable("dbo.FormatSklepus");
        }
    }
}
