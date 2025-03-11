namespace smartVillage.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        MobileNo = c.String(maxLength: 50),
                        Email = c.String(maxLength: 250),
                        Address = c.String(maxLength: 500),
                        EmployeeCode = c.String(maxLength: 250),
                        Photo = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        StateId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                        DesignationId = c.Long(nullable: false),
                        DepartmentId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: false)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: false)
                .Index(t => t.StateId)
                .Index(t => t.DistrictId)
                .Index(t => t.VillageId)
                .Index(t => t.DesignationId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.FamilyMembers",
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
                "dbo.Status",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        IsFirst = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FamilyMembers", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.FamilyMembers", "StateId", "dbo.States");
            DropForeignKey("dbo.FamilyMembers", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Employees", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.Employees", "StateId", "dbo.States");
            DropForeignKey("dbo.Employees", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.FamilyMembers", new[] { "VillageId" });
            DropIndex("dbo.FamilyMembers", new[] { "DistrictId" });
            DropIndex("dbo.FamilyMembers", new[] { "StateId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropIndex("dbo.Employees", new[] { "VillageId" });
            DropIndex("dbo.Employees", new[] { "DistrictId" });
            DropIndex("dbo.Employees", new[] { "StateId" });
            DropTable("dbo.Status");
            DropTable("dbo.FamilyMembers");
            DropTable("dbo.Employees");
            DropTable("dbo.Designations");
            DropTable("dbo.Departments");
        }
    }
}
