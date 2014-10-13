namespace ProjectContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropalltables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "IdTable", "dbo.Tables");
            DropForeignKey("dbo.Rations", "OrderId", "dbo.Orders");
            DropIndex("dbo.Orders", new[] { "IdTable" });
            DropIndex("dbo.Rations", new[] { "OrderId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Tables");
            DropTable("dbo.People");
            DropTable("dbo.Rations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rations",
                c => new
                    {
                        RationId = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        Done = c.Boolean(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RationId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        PersonType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        IdTable = c.Int(nullable: false, identity: true),
                        Plasace = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTable);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Sum = c.Double(nullable: false),
                        Done = c.Boolean(nullable: false),
                        IdTable = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateIndex("dbo.Rations", "OrderId");
            CreateIndex("dbo.Orders", "IdTable");
            AddForeignKey("dbo.Rations", "OrderId", "dbo.Orders", "OrderID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "IdTable", "dbo.Tables", "IdTable", cascadeDelete: true);
        }
    }
}
