namespace RegistryManagmentV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_security_level : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Catalogs", "SecurityLevel", c => c.Int(nullable: false, defaultValue: 5));
            AddColumn("dbo.UserGroups", "SecurityLevel", c => c.Int(nullable: false, defaultValue: 5));
            AddColumn("dbo.Resources", "SecurityLevel", c => c.Int(nullable: false, defaultValue: 5));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resources", "SecurityLevel");
            DropColumn("dbo.UserGroups", "SecurityLevel");
            DropColumn("dbo.Catalogs", "SecurityLevel");
        }
    }
}
