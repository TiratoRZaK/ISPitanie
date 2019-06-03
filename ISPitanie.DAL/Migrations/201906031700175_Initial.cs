namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Norm = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Vitamine_C = c.Int(),
                        Fat = c.Int(),
                        Protein = c.Int(),
                        Carbohydrate = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UnitId = c.Int(nullable: false),
                        Norm = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Vitamine_C = c.Int(),
                        Protein = c.Int(),
                        Fat = c.Int(),
                        Carbohydrate = c.Int(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductsDishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DishId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Norm = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.DishId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductsDishes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductsDishes", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.Products", "UnitId", "dbo.Units");
            DropIndex("dbo.ProductsDishes", new[] { "ProductId" });
            DropIndex("dbo.ProductsDishes", new[] { "DishId" });
            DropIndex("dbo.Products", new[] { "UnitId" });
            DropTable("dbo.ProductsDishes");
            DropTable("dbo.Units");
            DropTable("dbo.Products");
            DropTable("dbo.Dishes");
        }
    }
}
