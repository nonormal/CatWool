namespace CatWool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableSizeStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Boolean(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "SizeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Products", "StatusId", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Products", "SizeId");
            AddForeignKey("dbo.Products", "SizeId", "dbo.Sizes", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Size", c => c.String());
            DropForeignKey("dbo.Products", "SizeId", "dbo.Sizes");
            DropIndex("dbo.Products", new[] { "SizeId" });
            DropColumn("dbo.Products", "StatusId");
            DropColumn("dbo.Products", "SizeId");
            DropTable("dbo.Status");
            DropTable("dbo.Sizes");
        }
    }
}
