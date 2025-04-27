namespace ThomasHarper_Cs_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoHubEmployeeTasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        TaskTitle = c.String(),
                        TaskDescription = c.String(),
                        TaskAssignedTo = c.String(),
                        TaskAssignedBy = c.String(),
                    })
                .PrimaryKey(t => t.TaskID);
            
            CreateTable(
                "dbo.CargoHubProducts",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductCategory = c.String(),
                        ProductQuantity = c.Int(nullable: false),
                        ProductCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductReplenishTime = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.CargoHubUsers",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserPassword = c.String(),
                        IsUserAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoHubUsers");
            DropTable("dbo.CargoHubProducts");
            DropTable("dbo.CargoHubEmployeeTasks");
        }
    }
}
