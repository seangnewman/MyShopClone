namespace MyShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product : DbMigration
    {
        public override void Up()
        {
            CreateTable(
     "dbo.ProductCategories",
     c => new
     {
         Id = c.String(nullable: false, maxLength: 128),
         Category = c.String(),
         CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
     })
     .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(maxLength: 20),
                    Description = c.String(),
                    Price = c.String(),
                    Category = c.String(),
                    Image = c.String(),
                    CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                })
                .PrimaryKey(t => t.Id);
            CreateTable(
    "dbo.BasketItems",
    c => new
    {
        Id = c.String(nullable: false, maxLength: 128),
        BasketId = c.String(maxLength: 128),
        ProductID = c.String(),
        Quantity = c.Int(nullable: false),
        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
    })
    .PrimaryKey(t => t.Id)
    .ForeignKey("dbo.Baskets", t => t.BasketId)
    .Index(t => t.BasketId);

            CreateTable(
                "dbo.Baskets",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");

            DropForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets");
            DropIndex("dbo.BasketItems", new[] { "BasketId" });
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketItems");
        }
    }
}
