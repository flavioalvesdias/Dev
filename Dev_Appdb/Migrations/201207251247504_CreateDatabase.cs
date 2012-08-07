namespace Dev_Appdb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50),
                        CreateUserId = c.Int(nullable: false),
                        MenuPaiId = c.Int(),
                        UpdateUserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MenuId)
                .ForeignKey("dbo.Menu", t => t.MenuPaiId)
                .Index(t => t.MenuPaiId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Usuario = c.String(nullable: false, maxLength: 30),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 100),
                        CreateUserId = c.Int(nullable: false),
                        UpdateUserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.View",
                c => new
                    {
                        ViewId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50),
                        ControllerName = c.String(nullable: false, maxLength: 50),
                        ActionName = c.String(nullable: false, maxLength: 25),
                        CreateUserId = c.Int(nullable: false),
                        UpdateUserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ViewId)
                .ForeignKey("dbo.Menu", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.View", new[] { "MenuId" });
            DropIndex("dbo.Menu", new[] { "MenuPaiId" });
            DropForeignKey("dbo.View", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.Menu", "MenuPaiId", "dbo.Menu");
            DropTable("dbo.View");
            DropTable("dbo.Users");
            DropTable("dbo.Menu");
        }
    }
}
