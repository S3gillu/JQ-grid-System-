namespace NewGridSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewCustomers", "Phone", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewCustomers", "Phone");
        }
    }
}
