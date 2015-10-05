namespace LoveMeBetter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId_Name", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "ProductId_Name" });
            RenameColumn(table: "dbo.OrderDetails", name: "OrderId_Id", newName: "Order_Id");
            RenameColumn(table: "dbo.OrderDetails", name: "ProductId_Name", newName: "Product_Name");
            RenameIndex(table: "dbo.OrderDetails", name: "IX_OrderId_Id", newName: "IX_Order_Id");
            DropPrimaryKey("dbo.Products");
            CreateTable(
                "dbo.RandomizedProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            AddColumn("dbo.Orders", "TimeStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "DiscountType", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "TransactionStatusEnum", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "PriceWhenBought", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "RandomizedProductCategory_Id", c => c.Int());
            AddColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "IsSubscriptionProduct", c => c.Boolean(nullable: false));
            AlterColumn("dbo.OrderDetails", "Product_Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 100));
            AddPrimaryKey("dbo.Products", "Name");
            CreateIndex("dbo.OrderDetails", "Product_Name");
            CreateIndex("dbo.OrderDetails", "RandomizedProductCategory_Id");
            AddForeignKey("dbo.OrderDetails", "RandomizedProductCategory_Id", "dbo.RandomizedProductCategories", "Id");
            AddForeignKey("dbo.OrderDetails", "Product_Name", "dbo.Products", "Name", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Product_Name", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "RandomizedProductCategory_Id", "dbo.RandomizedProductCategories");
            DropIndex("dbo.RandomizedProductCategories", new[] { "Name" });
            DropIndex("dbo.OrderDetails", new[] { "RandomizedProductCategory_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Product_Name" });
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.OrderDetails", "Product_Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Products", "IsSubscriptionProduct");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.OrderDetails", "RandomizedProductCategory_Id");
            DropColumn("dbo.OrderDetails", "PriceWhenBought");
            DropColumn("dbo.OrderDetails", "Quantity");
            DropColumn("dbo.Orders", "TransactionStatusEnum");
            DropColumn("dbo.Orders", "DiscountType");
            DropColumn("dbo.Orders", "TimeStamp");
            DropTable("dbo.RandomizedProductCategories");
            AddPrimaryKey("dbo.Products", "Name");
            RenameIndex(table: "dbo.OrderDetails", name: "IX_Order_Id", newName: "IX_OrderId_Id");
            RenameColumn(table: "dbo.OrderDetails", name: "Product_Name", newName: "ProductId_Name");
            RenameColumn(table: "dbo.OrderDetails", name: "Order_Id", newName: "OrderId_Id");
            CreateIndex("dbo.OrderDetails", "ProductId_Name");
            AddForeignKey("dbo.OrderDetails", "ProductId_Name", "dbo.Products", "Name", cascadeDelete: true);
        }
    }
}
