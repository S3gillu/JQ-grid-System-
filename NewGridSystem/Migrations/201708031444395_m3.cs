namespace NewGridSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewCustomers", "Phone", c => c.Long(nullable: false));
            AddColumn("dbo.NewCustomers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewCustomers", "Email");
            DropColumn("dbo.NewCustomers", "Phone");
        }
    }
}
