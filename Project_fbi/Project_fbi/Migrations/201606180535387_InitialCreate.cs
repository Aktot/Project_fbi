namespace Project_fbi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.History",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsDecrypted = c.Boolean(nullable: false),
                        ImageCollection_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ImageCollection", t => t.ImageCollection_ID)
                .Index(t => t.ImageCollection_ID);
            
            CreateTable(
                "dbo.ImageCollection",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Data = c.Binary(),
                        UserCollection_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserCollection", t => t.UserCollection_ID)
                .Index(t => t.UserCollection_ID);
            
            CreateTable(
                "dbo.UserCollection",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageCollection", "UserCollection_ID", "dbo.UserCollection");
            DropForeignKey("dbo.History", "ImageCollection_ID", "dbo.ImageCollection");
            DropIndex("dbo.ImageCollection", new[] { "UserCollection_ID" });
            DropIndex("dbo.History", new[] { "ImageCollection_ID" });
            DropTable("dbo.UserCollection");
            DropTable("dbo.ImageCollection");
            DropTable("dbo.History");
        }
    }
}
