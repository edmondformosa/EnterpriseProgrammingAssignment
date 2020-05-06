namespace EnterpriseProgrammingAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnterpriseProgrammingAssignmentApplicationDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetCategories",
                c => new
                    {
                        Category_Id = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Category_Id);
            
            CreateTable(
                "dbo.AspNetItemType",
                c => new
                    {
                        ItemType_Id = c.Long(nullable: false, identity: true),
                        Category_Id = c.Long(nullable: false),
                        ItemName = c.String(nullable: false),
                        ImageUrl = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ItemType_Id)
                .ForeignKey("dbo.AspNetCategories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.AspNetItemDetails",
                c => new
                    {
                        Item_Id = c.Long(nullable: false, identity: true),
                        ItemType_Id = c.Long(nullable: false),
                        Quality_Id = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Item_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.AspNetItemType", t => t.ItemType_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetQuality", t => t.Quality_Id, cascadeDelete: true)
                .Index(t => t.ItemType_Id)
                .Index(t => t.Quality_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetQuality",
                c => new
                    {
                        Quality_Id = c.Int(nullable: false, identity: true),
                        QualityType = c.String(),
                    })
                .PrimaryKey(t => t.Quality_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetItemDetails", "Quality_Id", "dbo.AspNetQuality");
            DropForeignKey("dbo.AspNetItemDetails", "ItemType_Id", "dbo.AspNetItemType");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetItemDetails", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetItemType", "Category_Id", "dbo.AspNetCategories");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetItemDetails", new[] { "User_Id" });
            DropIndex("dbo.AspNetItemDetails", new[] { "Quality_Id" });
            DropIndex("dbo.AspNetItemDetails", new[] { "ItemType_Id" });
            DropIndex("dbo.AspNetItemType", new[] { "Category_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetQuality");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetItemDetails");
            DropTable("dbo.AspNetItemType");
            DropTable("dbo.AspNetCategories");
        }
    }
}
