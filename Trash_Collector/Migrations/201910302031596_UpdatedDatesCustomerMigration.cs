namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDatesCustomerMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "startDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "endDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "extraPickUpDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "extraPickUpDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "endDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "startDate", c => c.Int(nullable: false));
        }
    }
}
