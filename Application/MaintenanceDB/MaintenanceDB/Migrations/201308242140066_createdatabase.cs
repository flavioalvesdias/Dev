namespace MaintenanceDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysMenu",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100),
                        MenuPaiId = c.Int(),
                        CreateUserId = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateUserId = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MenuId)
                .ForeignKey("dbo.SysMenu", t => t.MenuPaiId)
                .Index(t => t.MenuPaiId);
            
            CreateTable(
                "dbo.SysView",
                c => new
                    {
                        ViewId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100),
                        ControllerName = c.String(nullable: false, maxLength: 50),
                        ActionName = c.String(nullable: false, maxLength: 25),
                        CreateUserId = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateUserId = c.String(),
                        Active = c.Boolean(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ViewId)
                .ForeignKey("dbo.SysMenu", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.MyUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.UserSecrets",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Secret = c.String(),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey });
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SysView", "MenuId", "dbo.SysMenu");
            DropForeignKey("dbo.SysMenu", "MenuPaiId", "dbo.SysMenu");
            DropIndex("dbo.SysView", new[] { "MenuId" });
            DropIndex("dbo.SysMenu", new[] { "MenuPaiId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserSecrets");
            DropTable("dbo.UserClaims");
            DropTable("dbo.MyUsers");
            DropTable("dbo.SysView");
            DropTable("dbo.SysMenu");
        }
    }
}
