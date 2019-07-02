namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfieldcustomerseller : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "NameCompany", c => c.String());
            AddColumn("dbo.Customers", "FullNameCompany", c => c.String());
            AddColumn("dbo.Customers", "AddressCompany", c => c.String());
            AddColumn("dbo.Customers", "KPP", c => c.Long(nullable: false));
            AddColumn("dbo.Customers", "BIK", c => c.Long(nullable: false));
            AddColumn("dbo.Customers", "Bank", c => c.String());
            AddColumn("dbo.Customers", "PersonalAccount", c => c.String());
            AddColumn("dbo.Customers", "BankAccount", c => c.String());
            AddColumn("dbo.Customers", "NameCustomer", c => c.String());
            AddColumn("dbo.Customers", "NameCustomerSpec", c => c.String());
            AddColumn("dbo.Sellers", "NameCompany", c => c.String());
            AddColumn("dbo.Sellers", "FullNameCompany", c => c.String());
            AddColumn("dbo.Sellers", "AddressCompany", c => c.String());
            AddColumn("dbo.Sellers", "Email", c => c.String());
            AddColumn("dbo.Sellers", "PhoneNumber", c => c.String());
            AddColumn("dbo.Sellers", "KPP", c => c.Long(nullable: false));
            AddColumn("dbo.Sellers", "BIK", c => c.Long(nullable: false));
            AddColumn("dbo.Sellers", "Bank", c => c.String());
            AddColumn("dbo.Sellers", "PersonalAccount", c => c.String());
            AddColumn("dbo.Sellers", "BankAccount", c => c.String());
            AddColumn("dbo.Sellers", "CorrespondentAccount", c => c.String());
            AddColumn("dbo.Sellers", "NameSeller", c => c.String());
            AddColumn("dbo.Sellers", "NameSellerSpec", c => c.String());
            DropColumn("dbo.Customers", "Name");
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Sellers", "Name");
            DropColumn("dbo.Sellers", "Address");
            DropColumn("dbo.Sellers", "Shipper");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sellers", "Shipper", c => c.String());
            AddColumn("dbo.Sellers", "Address", c => c.String());
            AddColumn("dbo.Sellers", "Name", c => c.String());
            AddColumn("dbo.Customers", "Address", c => c.String());
            AddColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.Sellers", "NameSellerSpec");
            DropColumn("dbo.Sellers", "NameSeller");
            DropColumn("dbo.Sellers", "CorrespondentAccount");
            DropColumn("dbo.Sellers", "BankAccount");
            DropColumn("dbo.Sellers", "PersonalAccount");
            DropColumn("dbo.Sellers", "Bank");
            DropColumn("dbo.Sellers", "BIK");
            DropColumn("dbo.Sellers", "KPP");
            DropColumn("dbo.Sellers", "PhoneNumber");
            DropColumn("dbo.Sellers", "Email");
            DropColumn("dbo.Sellers", "AddressCompany");
            DropColumn("dbo.Sellers", "FullNameCompany");
            DropColumn("dbo.Sellers", "NameCompany");
            DropColumn("dbo.Customers", "NameCustomerSpec");
            DropColumn("dbo.Customers", "NameCustomer");
            DropColumn("dbo.Customers", "BankAccount");
            DropColumn("dbo.Customers", "PersonalAccount");
            DropColumn("dbo.Customers", "Bank");
            DropColumn("dbo.Customers", "BIK");
            DropColumn("dbo.Customers", "KPP");
            DropColumn("dbo.Customers", "AddressCompany");
            DropColumn("dbo.Customers", "FullNameCompany");
            DropColumn("dbo.Customers", "NameCompany");
        }
    }
}
