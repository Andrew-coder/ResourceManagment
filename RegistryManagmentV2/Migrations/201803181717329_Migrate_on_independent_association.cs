namespace RegistryManagmentV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate_on_independent_association : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Catalogs", "SuperCatalog_Id", "dbo.Catalogs");
            DropForeignKey("dbo.UserGroupCatalogs", "Catalog_Id", "dbo.Catalogs");
            DropForeignKey("dbo.Resources", "Catalog_Id", "dbo.Catalogs");
            DropForeignKey("dbo.UserGroupCatalogs", "UserGroup_Id", "dbo.UserGroups");
            DropForeignKey("dbo.AspNetUsers", "UserGroup_Id", "dbo.UserGroups");
            DropIndex("dbo.Catalogs", new[] { "SuperCatalog_Id" });
            DropIndex("dbo.Resources", new[] { "Catalog_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "UserGroup_Id" });
            DropIndex("dbo.UserGroupCatalogs", new[] { "UserGroup_Id" });
            DropIndex("dbo.UserGroupCatalogs", new[] { "Catalog_Id" });
            RenameColumn(table: "dbo.Catalogs", name: "SuperCatalog_Id", newName: "SuperCatalogId");
            RenameColumn(table: "dbo.Resources", name: "Catalog_Id", newName: "CatalogId");
            DropPrimaryKey("dbo.Catalogs");
            DropPrimaryKey("dbo.UserGroups");
            DropPrimaryKey("dbo.Resources");
            DropPrimaryKey("dbo.UserGroupCatalogs");
            AlterColumn("dbo.Catalogs", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Catalogs", "SuperCatalogId", c => c.Long());
            AlterColumn("dbo.UserGroups", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Resources", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Resources", "CatalogId", c => c.Long());
            AlterColumn("dbo.AspNetUsers", "UserGroup_Id", c => c.Long());
            AlterColumn("dbo.UserGroupCatalogs", "UserGroup_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.UserGroupCatalogs", "Catalog_Id", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Catalogs", "Id");
            AddPrimaryKey("dbo.UserGroups", "Id");
            AddPrimaryKey("dbo.Resources", "Id");
            AddPrimaryKey("dbo.UserGroupCatalogs", new[] { "UserGroup_Id", "Catalog_Id" });
            CreateIndex("dbo.Catalogs", "SuperCatalogId");
            CreateIndex("dbo.Resources", "CatalogId");
            CreateIndex("dbo.AspNetUsers", "UserGroup_Id");
            CreateIndex("dbo.UserGroupCatalogs", "UserGroup_Id");
            CreateIndex("dbo.UserGroupCatalogs", "Catalog_Id");
            AddForeignKey("dbo.Catalogs", "SuperCatalogId", "dbo.Catalogs", "Id");
            AddForeignKey("dbo.UserGroupCatalogs", "Catalog_Id", "dbo.Catalogs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Resources", "CatalogId", "dbo.Catalogs", "Id");
            AddForeignKey("dbo.UserGroupCatalogs", "UserGroup_Id", "dbo.UserGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "UserGroup_Id", "dbo.UserGroups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserGroup_Id", "dbo.UserGroups");
            DropForeignKey("dbo.UserGroupCatalogs", "UserGroup_Id", "dbo.UserGroups");
            DropForeignKey("dbo.Resources", "CatalogId", "dbo.Catalogs");
            DropForeignKey("dbo.UserGroupCatalogs", "Catalog_Id", "dbo.Catalogs");
            DropForeignKey("dbo.Catalogs", "SuperCatalogId", "dbo.Catalogs");
            DropIndex("dbo.UserGroupCatalogs", new[] { "Catalog_Id" });
            DropIndex("dbo.UserGroupCatalogs", new[] { "UserGroup_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "UserGroup_Id" });
            DropIndex("dbo.Resources", new[] { "CatalogId" });
            DropIndex("dbo.Catalogs", new[] { "SuperCatalogId" });
            DropPrimaryKey("dbo.UserGroupCatalogs");
            DropPrimaryKey("dbo.Resources");
            DropPrimaryKey("dbo.UserGroups");
            DropPrimaryKey("dbo.Catalogs");
            AlterColumn("dbo.UserGroupCatalogs", "Catalog_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.UserGroupCatalogs", "UserGroup_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "UserGroup_Id", c => c.Int());
            AlterColumn("dbo.Resources", "CatalogId", c => c.Int());
            AlterColumn("dbo.Resources", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserGroups", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Catalogs", "SuperCatalogId", c => c.Int());
            AlterColumn("dbo.Catalogs", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserGroupCatalogs", new[] { "UserGroup_Id", "Catalog_Id" });
            AddPrimaryKey("dbo.Resources", "Id");
            AddPrimaryKey("dbo.UserGroups", "Id");
            AddPrimaryKey("dbo.Catalogs", "Id");
            RenameColumn(table: "dbo.Resources", name: "CatalogId", newName: "Catalog_Id");
            RenameColumn(table: "dbo.Catalogs", name: "SuperCatalogId", newName: "SuperCatalog_Id");
            CreateIndex("dbo.UserGroupCatalogs", "Catalog_Id");
            CreateIndex("dbo.UserGroupCatalogs", "UserGroup_Id");
            CreateIndex("dbo.AspNetUsers", "UserGroup_Id");
            CreateIndex("dbo.Resources", "Catalog_Id");
            CreateIndex("dbo.Catalogs", "SuperCatalog_Id");
            AddForeignKey("dbo.AspNetUsers", "UserGroup_Id", "dbo.UserGroups", "Id");
            AddForeignKey("dbo.UserGroupCatalogs", "UserGroup_Id", "dbo.UserGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Resources", "Catalog_Id", "dbo.Catalogs", "Id");
            AddForeignKey("dbo.UserGroupCatalogs", "Catalog_Id", "dbo.Catalogs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Catalogs", "SuperCatalog_Id", "dbo.Catalogs", "Id");
        }
    }
}
