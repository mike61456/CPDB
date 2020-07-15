namespace CPD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Product", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "OwnerId", c => c.Guid(nullable: false));
        }
    }
}
