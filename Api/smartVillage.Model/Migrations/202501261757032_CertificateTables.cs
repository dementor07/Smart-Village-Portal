namespace smartVillage.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CertificateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CasteCertificates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Gender = c.String(maxLength: 50),
                        Age = c.Int(nullable: false),
                        FatherName = c.String(maxLength: 100),
                        Address = c.String(maxLength: 200),
                        Pincode = c.String(maxLength: 100),
                        PostOffice = c.String(maxLength: 100),
                        Location = c.String(maxLength: 100),
                        Taluk = c.String(maxLength: 100),
                        Date = c.DateTime(nullable: false),
                        IssueDate = c.DateTime(),
                        Reason = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                        IssueById = c.Long(),
                        ApproveById = c.Long(),
                        CustomerId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                        ReligionId = c.Long(nullable: false),
                        CasteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApproveById)
                .ForeignKey("dbo.Castes", t => t.CasteId, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.IssueById)
                .ForeignKey("dbo.Religions", t => t.ReligionId, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: false)
                .Index(t => t.IssueById)
                .Index(t => t.ApproveById)
                .Index(t => t.CustomerId)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.StateId)
                .Index(t => t.ReligionId)
                .Index(t => t.CasteId);
            
            CreateTable(
                "dbo.Castes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Religions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CommunityCertificates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Gender = c.String(maxLength: 50),
                        Age = c.Int(nullable: false),
                        FatherName = c.String(maxLength: 100),
                        Address = c.String(maxLength: 200),
                        Pincode = c.String(),
                        PostOffice = c.String(maxLength: 100),
                        Location = c.String(maxLength: 100),
                        Taluk = c.String(),
                        Date = c.DateTime(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        Reason = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IssueById = c.Long(nullable: false),
                        ApproveById = c.Long(nullable: false),
                        CustomerId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                        ReligionId = c.Long(nullable: false),
                        CasteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApproveById, cascadeDelete: false)
                .ForeignKey("dbo.Castes", t => t.CasteId, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.IssueById, cascadeDelete: false)
                .ForeignKey("dbo.Religions", t => t.ReligionId, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: false)
                .Index(t => t.IssueById)
                .Index(t => t.ApproveById)
                .Index(t => t.CustomerId)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.StateId)
                .Index(t => t.ReligionId)
                .Index(t => t.CasteId);
            
            CreateTable(
                "dbo.DomicileCertificates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Gender = c.String(maxLength: 50),
                        Age = c.Int(nullable: false),
                        FatherName = c.String(maxLength: 100),
                        Address = c.String(maxLength: 200),
                        Pincode = c.String(maxLength: 50),
                        PostOffice = c.String(maxLength: 100),
                        Location = c.String(maxLength: 100),
                        Taluk = c.String(),
                        Date = c.DateTime(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        Reason = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IssueById = c.Long(),
                        ApproveById = c.Long(nullable: false),
                        CustomerId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                        ReligionId = c.Long(nullable: false),
                        CasteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApproveById, cascadeDelete: false)
                .ForeignKey("dbo.Castes", t => t.CasteId, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.IssueById)
                .ForeignKey("dbo.Religions", t => t.ReligionId, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: false)
                .Index(t => t.IssueById)
                .Index(t => t.ApproveById)
                .Index(t => t.CustomerId)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.StateId)
                .Index(t => t.ReligionId)
                .Index(t => t.CasteId);
            
            CreateTable(
                "dbo.FamilyMembershipCertificates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Gender = c.String(maxLength: 50),
                        Age = c.Int(nullable: false),
                        FatherName = c.String(maxLength: 100),
                        Address = c.String(maxLength: 200),
                        Pincode = c.String(),
                        PostOffice = c.String(maxLength: 100),
                        Location = c.String(maxLength: 100),
                        Taluk = c.String(),
                        Date = c.DateTime(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        Reason = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IssueById = c.Long(nullable: false),
                        ApproveById = c.Long(nullable: false),
                        CustomerId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApproveById, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.IssueById, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: false)
                .Index(t => t.IssueById)
                .Index(t => t.ApproveById)
                .Index(t => t.CustomerId)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.IncomeCertificates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Gender = c.String(maxLength: 100),
                        Age = c.Int(nullable: false),
                        FatherName = c.String(maxLength: 100),
                        Address = c.String(maxLength: 250),
                        PostOffice = c.String(maxLength: 100),
                        Pincode = c.String(maxLength: 100),
                        Taluk = c.String(maxLength: 100),
                        Reason = c.String(maxLength: 250),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        IssueById = c.Long(nullable: false),
                        CustomerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.IssueById, cascadeDelete: false)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: false)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.IssueById)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.NativityCertificates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Gender = c.String(maxLength: 100),
                        Age = c.Int(nullable: false),
                        FatherName = c.String(maxLength: 100),
                        Address = c.String(maxLength: 250),
                        PostOffice = c.String(maxLength: 100),
                        Pincode = c.String(maxLength: 100),
                        Taluk = c.String(maxLength: 100),
                        Reason = c.String(maxLength: 250),
                        ReligionId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        IssueById = c.Long(nullable: false),
                        CustomerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.IssueById, cascadeDelete: false)
                .ForeignKey("dbo.Religions", t => t.ReligionId, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: false)
                .Index(t => t.ReligionId)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.StateId)
                .Index(t => t.IssueById)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.NonCreamyLayerCertificates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Gender = c.String(maxLength: 100),
                        Age = c.Int(nullable: false),
                        FatherName = c.String(maxLength: 100),
                        Address = c.String(maxLength: 250),
                        PostOffice = c.String(maxLength: 100),
                        Pincode = c.String(maxLength: 100),
                        Taluk = c.String(maxLength: 100),
                        Reason = c.String(maxLength: 250),
                        CasteId = c.Long(nullable: false),
                        ReligionId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        IssueById = c.Long(nullable: false),
                        CustomerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Castes", t => t.CasteId, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.IssueById, cascadeDelete: false)
                .ForeignKey("dbo.Religions", t => t.ReligionId, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: false)
                .Index(t => t.CasteId)
                .Index(t => t.ReligionId)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.StateId)
                .Index(t => t.IssueById)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.RelationshipCertificates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Gender = c.String(maxLength: 100),
                        Age = c.Int(nullable: false),
                        FatherName = c.String(maxLength: 100),
                        Address = c.String(maxLength: 250),
                        PostOffice = c.String(maxLength: 100),
                        Pincode = c.String(maxLength: 100),
                        Taluk = c.String(maxLength: 100),
                        RelativeName = c.String(maxLength: 100),
                        Relationship = c.String(maxLength: 100),
                        Reason = c.String(maxLength: 250),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        IssueById = c.Long(nullable: false),
                        CustomerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.IssueById, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: false)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.StateId)
                .Index(t => t.IssueById)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Students",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.Students", "StateId", "dbo.States");
            DropForeignKey("dbo.Students", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.RelationshipCertificates", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.RelationshipCertificates", "StateId", "dbo.States");
            DropForeignKey("dbo.RelationshipCertificates", "IssueById", "dbo.Users");
            DropForeignKey("dbo.RelationshipCertificates", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.RelationshipCertificates", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.NonCreamyLayerCertificates", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.NonCreamyLayerCertificates", "StateId", "dbo.States");
            DropForeignKey("dbo.NonCreamyLayerCertificates", "ReligionId", "dbo.Religions");
            DropForeignKey("dbo.NonCreamyLayerCertificates", "IssueById", "dbo.Users");
            DropForeignKey("dbo.NonCreamyLayerCertificates", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.NonCreamyLayerCertificates", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.NonCreamyLayerCertificates", "CasteId", "dbo.Castes");
            DropForeignKey("dbo.NativityCertificates", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.NativityCertificates", "StateId", "dbo.States");
            DropForeignKey("dbo.NativityCertificates", "ReligionId", "dbo.Religions");
            DropForeignKey("dbo.NativityCertificates", "IssueById", "dbo.Users");
            DropForeignKey("dbo.NativityCertificates", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.NativityCertificates", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.IncomeCertificates", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.IncomeCertificates", "IssueById", "dbo.Users");
            DropForeignKey("dbo.IncomeCertificates", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.IncomeCertificates", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.FamilyMembershipCertificates", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.FamilyMembershipCertificates", "StateId", "dbo.States");
            DropForeignKey("dbo.FamilyMembershipCertificates", "IssueById", "dbo.Users");
            DropForeignKey("dbo.FamilyMembershipCertificates", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.FamilyMembershipCertificates", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.FamilyMembershipCertificates", "ApproveById", "dbo.Users");
            DropForeignKey("dbo.DomicileCertificates", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.DomicileCertificates", "StateId", "dbo.States");
            DropForeignKey("dbo.DomicileCertificates", "ReligionId", "dbo.Religions");
            DropForeignKey("dbo.DomicileCertificates", "IssueById", "dbo.Users");
            DropForeignKey("dbo.DomicileCertificates", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.DomicileCertificates", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.DomicileCertificates", "CasteId", "dbo.Castes");
            DropForeignKey("dbo.DomicileCertificates", "ApproveById", "dbo.Users");
            DropForeignKey("dbo.CommunityCertificates", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.CommunityCertificates", "StateId", "dbo.States");
            DropForeignKey("dbo.CommunityCertificates", "ReligionId", "dbo.Religions");
            DropForeignKey("dbo.CommunityCertificates", "IssueById", "dbo.Users");
            DropForeignKey("dbo.CommunityCertificates", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.CommunityCertificates", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CommunityCertificates", "CasteId", "dbo.Castes");
            DropForeignKey("dbo.CommunityCertificates", "ApproveById", "dbo.Users");
            DropForeignKey("dbo.CasteCertificates", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.CasteCertificates", "StateId", "dbo.States");
            DropForeignKey("dbo.CasteCertificates", "ReligionId", "dbo.Religions");
            DropForeignKey("dbo.CasteCertificates", "IssueById", "dbo.Users");
            DropForeignKey("dbo.CasteCertificates", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.CasteCertificates", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CasteCertificates", "CasteId", "dbo.Castes");
            DropForeignKey("dbo.CasteCertificates", "ApproveById", "dbo.Users");
            DropIndex("dbo.Students", new[] { "VillageId" });
            DropIndex("dbo.Students", new[] { "DistrictId" });
            DropIndex("dbo.Students", new[] { "StateId" });
            DropIndex("dbo.RelationshipCertificates", new[] { "CustomerId" });
            DropIndex("dbo.RelationshipCertificates", new[] { "IssueById" });
            DropIndex("dbo.RelationshipCertificates", new[] { "StateId" });
            DropIndex("dbo.RelationshipCertificates", new[] { "DistrictId" });
            DropIndex("dbo.RelationshipCertificates", new[] { "VillageId" });
            DropIndex("dbo.NonCreamyLayerCertificates", new[] { "CustomerId" });
            DropIndex("dbo.NonCreamyLayerCertificates", new[] { "IssueById" });
            DropIndex("dbo.NonCreamyLayerCertificates", new[] { "StateId" });
            DropIndex("dbo.NonCreamyLayerCertificates", new[] { "DistrictId" });
            DropIndex("dbo.NonCreamyLayerCertificates", new[] { "VillageId" });
            DropIndex("dbo.NonCreamyLayerCertificates", new[] { "ReligionId" });
            DropIndex("dbo.NonCreamyLayerCertificates", new[] { "CasteId" });
            DropIndex("dbo.NativityCertificates", new[] { "CustomerId" });
            DropIndex("dbo.NativityCertificates", new[] { "IssueById" });
            DropIndex("dbo.NativityCertificates", new[] { "StateId" });
            DropIndex("dbo.NativityCertificates", new[] { "DistrictId" });
            DropIndex("dbo.NativityCertificates", new[] { "VillageId" });
            DropIndex("dbo.NativityCertificates", new[] { "ReligionId" });
            DropIndex("dbo.IncomeCertificates", new[] { "CustomerId" });
            DropIndex("dbo.IncomeCertificates", new[] { "IssueById" });
            DropIndex("dbo.IncomeCertificates", new[] { "DistrictId" });
            DropIndex("dbo.IncomeCertificates", new[] { "VillageId" });
            DropIndex("dbo.FamilyMembershipCertificates", new[] { "StateId" });
            DropIndex("dbo.FamilyMembershipCertificates", new[] { "DistrictId" });
            DropIndex("dbo.FamilyMembershipCertificates", new[] { "VillageId" });
            DropIndex("dbo.FamilyMembershipCertificates", new[] { "CustomerId" });
            DropIndex("dbo.FamilyMembershipCertificates", new[] { "ApproveById" });
            DropIndex("dbo.FamilyMembershipCertificates", new[] { "IssueById" });
            DropIndex("dbo.DomicileCertificates", new[] { "CasteId" });
            DropIndex("dbo.DomicileCertificates", new[] { "ReligionId" });
            DropIndex("dbo.DomicileCertificates", new[] { "StateId" });
            DropIndex("dbo.DomicileCertificates", new[] { "DistrictId" });
            DropIndex("dbo.DomicileCertificates", new[] { "VillageId" });
            DropIndex("dbo.DomicileCertificates", new[] { "CustomerId" });
            DropIndex("dbo.DomicileCertificates", new[] { "ApproveById" });
            DropIndex("dbo.DomicileCertificates", new[] { "IssueById" });
            DropIndex("dbo.CommunityCertificates", new[] { "CasteId" });
            DropIndex("dbo.CommunityCertificates", new[] { "ReligionId" });
            DropIndex("dbo.CommunityCertificates", new[] { "StateId" });
            DropIndex("dbo.CommunityCertificates", new[] { "DistrictId" });
            DropIndex("dbo.CommunityCertificates", new[] { "VillageId" });
            DropIndex("dbo.CommunityCertificates", new[] { "CustomerId" });
            DropIndex("dbo.CommunityCertificates", new[] { "ApproveById" });
            DropIndex("dbo.CommunityCertificates", new[] { "IssueById" });
            DropIndex("dbo.CasteCertificates", new[] { "CasteId" });
            DropIndex("dbo.CasteCertificates", new[] { "ReligionId" });
            DropIndex("dbo.CasteCertificates", new[] { "StateId" });
            DropIndex("dbo.CasteCertificates", new[] { "DistrictId" });
            DropIndex("dbo.CasteCertificates", new[] { "VillageId" });
            DropIndex("dbo.CasteCertificates", new[] { "CustomerId" });
            DropIndex("dbo.CasteCertificates", new[] { "ApproveById" });
            DropIndex("dbo.CasteCertificates", new[] { "IssueById" });
            DropTable("dbo.Students");
            DropTable("dbo.RelationshipCertificates");
            DropTable("dbo.NonCreamyLayerCertificates");
            DropTable("dbo.NativityCertificates");
            DropTable("dbo.IncomeCertificates");
            DropTable("dbo.FamilyMembershipCertificates");
            DropTable("dbo.DomicileCertificates");
            DropTable("dbo.CommunityCertificates");
            DropTable("dbo.Religions");
            DropTable("dbo.Castes");
            DropTable("dbo.CasteCertificates");
        }
    }
}
