namespace NewGridSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NewCustomers", "Phone");
            DropColumn("dbo.NewCustomers", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewCustomers", "Email", c => c.String());
            AddColumn("dbo.NewCustomers", "Phone", c => c.Long(nullable: false));
        }
    }
}
