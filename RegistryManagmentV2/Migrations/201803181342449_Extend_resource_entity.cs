namespace RegistryManagmentV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Extend_resource_entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resources", "ResourceStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Resources", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resources", "Location");
            DropColumn("dbo.Resources", "ResourceStatus");
        }
    }
}
