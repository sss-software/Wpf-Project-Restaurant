namespace ProjectContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nulleblcolumndone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Done", c => c.Boolean());
            AlterColumn("dbo.Rations", "Done", c => c.Boolean());
            CreateIndex("dbo.Rations", "OrderId");
            AddForeignKey("dbo.Rations", "OrderId", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rations", "OrderId", "dbo.Orders");
            DropIndex("dbo.Rations", new[] { "OrderId" });
            AlterColumn("dbo.Rations", "Done", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Orders", "Done", c => c.Boolean(nullable: false));
        }
    }
}
