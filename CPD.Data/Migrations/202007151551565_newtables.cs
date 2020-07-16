namespace CPD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtables : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Product");
            AddColumn("dbo.Product", "ProductID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Product", "ProjectID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Product", "ProductID");
            CreateIndex("dbo.Project", "CustomerID");
            CreateIndex("dbo.Product", "ProjectID");
            AddForeignKey("dbo.Project", "CustomerID", "dbo.Customer", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.Product", "ProjectID", "dbo.Project", "ProjectID", cascadeDelete: true);
            DropColumn("dbo.Product", "ItemID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "ItemID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Product", "ProjectID", "dbo.Project");
            DropForeignKey("dbo.Project", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Product", new[] { "ProjectID" });
            DropIndex("dbo.Project", new[] { "CustomerID" });
            DropPrimaryKey("dbo.Product");
            DropColumn("dbo.Product", "ProjectID");
            DropColumn("dbo.Product", "ProductID");
            AddPrimaryKey("dbo.Product", "ItemID");
        }
    }
}
