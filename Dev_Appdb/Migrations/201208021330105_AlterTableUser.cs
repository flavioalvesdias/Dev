namespace Dev_Appdb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Users", "ConfirmPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ConfirmPassword");
            DropColumn("dbo.Users", "Password");
        }
    }
}
