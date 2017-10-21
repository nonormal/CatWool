namespace CatWool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableSize : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO SIZES(ID,NAME) VALUES(1,'Large')");
            Sql("INSERT INTO SIZES(ID,NAME) VALUES(2,'Medium')");
            Sql("INSERT INTO SIZES(ID,NAME) VALUES(3,'Small')");
        }
        
        public override void Down()
        {
        }
    }
}
