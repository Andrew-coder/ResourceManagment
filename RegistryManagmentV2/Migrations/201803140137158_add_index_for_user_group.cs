namespace RegistryManagmentV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_index_for_user_group : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserGroups", "Name", c => c.String(maxLength: 30));
            CreateIndex("dbo.UserGroups", "Name");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserGroups", new[] { "Name" });
            AlterColumn("dbo.UserGroups", "Name", c => c.String());
        }
    }
}
