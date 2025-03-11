namespace smartVillage.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        MobileNo = c.String(maxLength: 50),
                        Email = c.String(maxLength: 250),
                        Address = c.String(maxLength: 500),
                        Photo = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        StateId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: false)
                .Index(t => t.StateId)
                .Index(t => t.DistrictId)
                .Index(t => t.VillageId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        StateId = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Villages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        StateId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .Index(t => t.StateId)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserName = c.String(maxLength: 100),
                        PasswordSalt = c.String(maxLength: 256),
                        Password = c.String(maxLength: 256),
                        IsActive = c.Boolean(nullable: false),
                        Role = c.String(maxLength: 50),
                        IsBlocked = c.Boolean(nullable: false),
                        CustomerId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.UserSessions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Token = c.String(maxLength: 256),
                        SessionTimeStamp = c.DateTime(nullable: false),
                        ExpiresInMinutes = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        UserSessionStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSessions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.Villages", "StateId", "dbo.States");
            DropForeignKey("dbo.Villages", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Customers", "StateId", "dbo.States");
            DropForeignKey("dbo.Customers", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "StateId", "dbo.States");
            DropIndex("dbo.UserSessions", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "CustomerId" });
            DropIndex("dbo.Villages", new[] { "DistrictId" });
            DropIndex("dbo.Villages", new[] { "StateId" });
            DropIndex("dbo.Districts", new[] { "StateId" });
            DropIndex("dbo.Customers", new[] { "VillageId" });
            DropIndex("dbo.Customers", new[] { "DistrictId" });
            DropIndex("dbo.Customers", new[] { "StateId" });
            DropTable("dbo.UserSessions");
            DropTable("dbo.Users");
            DropTable("dbo.Villages");
            DropTable("dbo.States");
            DropTable("dbo.Districts");
            DropTable("dbo.Customers");
        }
    }
}
