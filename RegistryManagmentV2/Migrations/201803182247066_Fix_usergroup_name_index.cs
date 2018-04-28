namespace RegistryManagmentV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix_usergroup_name_index : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserGroups", new[] { "Name" });
            CreateIndex("dbo.UserGroups", "Name", unique: true, name: "GroupName_Index");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserGroups", "GroupName_Index");
            CreateIndex("dbo.UserGroups", "Name");
        }
    }
}
