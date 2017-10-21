namespace CatWool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableStatus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO STATUS(ID,NAME) VALUES('TRUE','On Sale')");
            Sql("INSERT INTO STATUS(ID,NAME) VALUES('FALSE','Out Sale')");
        }
        
        public override void Down()
        {
        }
    }
}
