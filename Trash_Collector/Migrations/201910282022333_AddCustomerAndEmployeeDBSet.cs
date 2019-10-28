namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerAndEmployeeDBSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        streetAddress = c.String(),
                        city = c.String(),
                        state = c.String(),
                        zipCode = c.Int(nullable: false),
                        pickupDay = c.String(),
                        balance = c.Int(nullable: false),
                        monthlyCharge = c.Int(nullable: false),
                        pickupConfirmed = c.Boolean(nullable: false),
                        start = c.Boolean(nullable: false),
                        end = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        zipCode = c.Int(nullable: false),
                        firstName = c.String(),
                        lastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
        }
    }
}
