namespace Simple_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        nameCategory = c.String(nullable: false, maxLength: 100),
                        DescCategory = c.String(nullable: false),
                        FileNameIcons = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        TitleCourse = c.String(nullable: false, maxLength: 100),
                        AuthorCourse = c.String(nullable: false, maxLength: 100),
                        AddDate = c.DateTime(nullable: false),
                        ImgName = c.String(maxLength: 100),
                        Desc = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bestseller = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrdersId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        Street = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 100),
                        PostCode = c.String(nullable: false, maxLength: 6),
                        Phone = c.String(),
                        Email = c.String(),
                        Coments = c.String(),
                        AddDate = c.DateTime(nullable: false),
                        OrderState = c.Int(nullable: false),
                        OrderValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrdersId);
            
            CreateTable(
                "dbo.PositionOrder",
                c => new
                    {
                        PositionOrderId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        orders_OrdersId = c.Int(),
                    })
                .PrimaryKey(t => t.PositionOrderId)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.orders_OrdersId)
                .Index(t => t.CourseID)
                .Index(t => t.orders_OrdersId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PositionOrder", "orders_OrdersId", "dbo.Orders");
            DropForeignKey("dbo.PositionOrder", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Course", "CategoryId", "dbo.Category");
            DropIndex("dbo.PositionOrder", new[] { "orders_OrdersId" });
            DropIndex("dbo.PositionOrder", new[] { "CourseID" });
            DropIndex("dbo.Course", new[] { "CategoryId" });
            DropTable("dbo.PositionOrder");
            DropTable("dbo.Orders");
            DropTable("dbo.Course");
            DropTable("dbo.Category");
        }
    }
}
