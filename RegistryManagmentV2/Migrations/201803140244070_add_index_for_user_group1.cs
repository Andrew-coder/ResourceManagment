namespace RegistryManagmentV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_index_for_user_group1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Catalogs", "Name", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Resources", "Title", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resources", "Title", c => c.String());
            AlterColumn("dbo.Catalogs", "Name", c => c.String());
        }
    }
}
