namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editContext : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductsDishes", newName: "ProductDishes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProductDishes", newName: "ProductsDishes");
        }
    }
}
