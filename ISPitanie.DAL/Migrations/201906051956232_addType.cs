namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InfoStatics",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Balance", c => c.Int());
            AddColumn("dbo.Products", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "TypeId");
            AddForeignKey("dbo.Products", "TypeId", "dbo.Types", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Count", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "TypeId", "dbo.Types");
            DropIndex("dbo.Products", new[] { "TypeId" });
            DropColumn("dbo.Products", "TypeId");
            DropColumn("dbo.Products", "Balance");
            DropTable("dbo.Types");
            DropTable("dbo.InfoStatics");
        }
    }
}
