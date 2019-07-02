namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDocs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        SellerId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        ResponsiblePerson = c.String(),
                        ConclusionDate = c.DateTime(nullable: false),
                        PeriodInMonths = c.Int(nullable: false),
                        File = c.Binary(),
                        Total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerId, cascadeDelete: true)
                .Index(t => t.SellerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ContractId = c.Int(nullable: false),
                        File = c.Binary(),
                        Shipper = c.String(),
                        Consignee = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        AmountOfKids = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                        File = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "SellerId", "dbo.Sellers");
            DropForeignKey("dbo.Contracts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Menus", new[] { "InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "ContractId" });
            DropIndex("dbo.Contracts", new[] { "CustomerId" });
            DropIndex("dbo.Contracts", new[] { "SellerId" });
            DropTable("dbo.Menus");
            DropTable("dbo.Invoices");
            DropTable("dbo.Contracts");
        }
    }
}
