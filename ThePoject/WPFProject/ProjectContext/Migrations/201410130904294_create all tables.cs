namespace ProjectContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createalltables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Sum = c.Double(nullable: false),
                        OrderDone = c.Boolean(),
                        TableId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Tables", t => t.TableId, cascadeDelete: true)
                .Index(t => t.TableId);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        TableId = c.Int(nullable: false, identity: true),
                        Plasace = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TableId);
            
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
                        RationDone = c.Boolean(),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RationId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rations", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "TableId", "dbo.Tables");
            DropIndex("dbo.Rations", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "TableId" });
            DropTable("dbo.Rations");
            DropTable("dbo.People");
            DropTable("dbo.Tables");
            DropTable("dbo.Orders");
        }
    }
}
