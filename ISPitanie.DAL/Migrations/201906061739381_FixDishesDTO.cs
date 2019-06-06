namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDishesDTO : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Dishes", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dishes", "Price", c => c.Int(nullable: false));
        }
    }
}
