namespace CatWool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTableStatusSize : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO STATUS(ID,NAME) VALUES('TRUE','On Sale')");
            Sql("INSERT INTO STATUS(ID,NAME) VALUES('FALSE','Out Sale')");
            Sql("INSERT INTO SIZES(ID,NAME) VALUES(1,'Large')");
            Sql("INSERT INTO SIZES(ID,NAME) VALUES(2,'Medium')");
            Sql("INSERT INTO SIZES(ID,NAME) VALUES(3,'Small')");
        }
        
        public override void Down()
        {
        }
    }
}
