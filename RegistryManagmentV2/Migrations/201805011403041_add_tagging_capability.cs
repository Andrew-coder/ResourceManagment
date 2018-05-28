namespace RegistryManagmentV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tagging_capability : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tags", "TagValue", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.Tags", "TagValue", unique: true, name: "TagValue_Index");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tags", "TagValue_Index");
            AlterColumn("dbo.Tags", "TagValue", c => c.String());
        }
    }
}
