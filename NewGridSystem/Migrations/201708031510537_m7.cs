namespace NewGridSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewCustomers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewCustomers", "Email");
        }
    }
}
