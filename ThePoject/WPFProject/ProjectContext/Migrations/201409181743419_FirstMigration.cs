namespace ProjectContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Sum = c.Double(nullable: false),
                        Done = c.Boolean(nullable: false),
                        IdTable = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Tables", t => t.IdTable, cascadeDelete: true)
                .Index(t => t.IdTable);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        IdTable = c.Int(nullable: false, identity: true),
                        Plasace = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTable);
            
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
                "dbo.Rations",
                c => new
                    {
                        RationId = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RationId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rations", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "IdTable", "dbo.Tables");
            DropIndex("dbo.Rations", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "IdTable" });
            DropTable("dbo.Rations");
            DropTable("dbo.People");
            DropTable("dbo.Tables");
            DropTable("dbo.Orders");
        }
    }
}
