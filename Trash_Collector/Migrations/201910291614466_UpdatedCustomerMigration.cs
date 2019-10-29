namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCustomerMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "startDate", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "endDate", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "extraPickUp", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "extraPickUpDate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "extraPickUpDate");
            DropColumn("dbo.Customers", "extraPickUp");
            DropColumn("dbo.Customers", "endDate");
            DropColumn("dbo.Customers", "startDate");
        }
    }
}
