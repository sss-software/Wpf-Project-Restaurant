namespace ProjectContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changenamefileds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderDone", c => c.Boolean());
            AddColumn("dbo.Rations", "RationDone", c => c.Boolean());
            DropColumn("dbo.Orders", "Done");
            DropColumn("dbo.Rations", "Done");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rations", "Done", c => c.Boolean());
            AddColumn("dbo.Orders", "Done", c => c.Boolean());
            DropColumn("dbo.Rations", "RationDone");
            DropColumn("dbo.Orders", "OrderDone");
        }
    }
}
