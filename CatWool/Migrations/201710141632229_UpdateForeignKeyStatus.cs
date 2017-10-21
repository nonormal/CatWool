namespace CatWool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForeignKeyStatus : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Products", "StatusId");
            AddForeignKey("dbo.Products", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Status", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Products", "StatusId", "dbo.Status");
            DropIndex("dbo.Products", new[] { "StatusId" });
        }
    }
}
