namespace RegistryManagmentV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tagging_capability : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TagValue = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TagValue, unique: true, name: "TagValue_Index");
            
            CreateTable(
                "dbo.TagResources",
                c => new
                    {
                        Tag_Id = c.Long(nullable: false),
                        Resource_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Resource_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Resources", t => t.Resource_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Resource_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagResources", "Resource_Id", "dbo.Resources");
            DropForeignKey("dbo.TagResources", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagResources", new[] { "Resource_Id" });
            DropIndex("dbo.TagResources", new[] { "Tag_Id" });
            DropIndex("dbo.Tags", "TagValue_Index");
            DropTable("dbo.TagResources");
            DropTable("dbo.Tags");
        }
    }
}
