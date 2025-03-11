namespace smartVillage.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTablesPensions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgricultureWorkersPensions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        PensionCode = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                        CareOf = c.String(maxLength: 100),
                        Gender = c.String(maxLength: 100),
                        WardNumber = c.String(maxLength: 100),
                        HouseNumber = c.String(maxLength: 100),
                        Address = c.String(maxLength: 100),
                        PostOffice = c.String(maxLength: 100),
                        Pincode = c.String(maxLength: 100),
                        MobileNumber = c.String(maxLength: 100),
                        RationCardNumber = c.String(maxLength: 100),
                        Income = c.Single(nullable: false),
                        WardMemberName = c.String(maxLength: 100),
                        ModeOfPayment = c.String(maxLength: 100),
                        IsServicePension = c.Boolean(nullable: false),
                        IsIncomeTaxPayable = c.Boolean(nullable: false),
                        IsEmployeeProvidentPensionTaker = c.Boolean(nullable: false),
                        LandOwnership = c.String(maxLength: 100),
                        ResidingYears = c.String(maxLength: 100),
                        IssueDate = c.DateTime(),
                        IssueById = c.Long(),
                        ApproveById = c.Long(),
                        CustomerId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApproveById)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IssueById)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: true)
                .Index(t => t.IssueById)
                .Index(t => t.ApproveById)
                .Index(t => t.CustomerId)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.IndiraGandhiNationalDisabilityPensions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        PensionCode = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                        CareOf = c.String(maxLength: 100),
                        Gender = c.String(maxLength: 100),
                        WardNumber = c.String(maxLength: 100),
                        HouseNumber = c.String(maxLength: 100),
                        Address = c.String(maxLength: 200),
                        PostOffice = c.String(maxLength: 100),
                        Pincode = c.String(maxLength: 100),
                        MobileNumber = c.String(maxLength: 100),
                        RationCardNumber = c.String(maxLength: 100),
                        Income = c.Single(nullable: false),
                        WardMemberName = c.String(maxLength: 100),
                        ModeOfPayment = c.String(maxLength: 100),
                        IsServicePension = c.Boolean(nullable: false),
                        IsIncomeTaxPayable = c.Boolean(nullable: false),
                        IsEmployeeProvidentPensionTaker = c.Boolean(nullable: false),
                        LandOwnership = c.String(maxLength: 100),
                        ResidingYears = c.String(maxLength: 100),
                        IssueDate = c.DateTime(),
                        IssueById = c.Long(),
                        ApproveById = c.Long(),
                        CustomerId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApproveById)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IssueById)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: true)
                .Index(t => t.IssueById)
                .Index(t => t.ApproveById)
                .Index(t => t.CustomerId)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.IndiraGandhiNationalOldAgePensions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        PensionCode = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                        CareOf = c.String(maxLength: 100),
                        Gender = c.String(maxLength: 100),
                        WardNumber = c.String(maxLength: 100),
                        HouseNumber = c.String(maxLength: 100),
                        Address = c.String(maxLength: 100),
                        PostOffice = c.String(maxLength: 100),
                        Pincode = c.String(maxLength: 100),
                        MobileNumber = c.String(maxLength: 100),
                        RationCardNumber = c.String(maxLength: 100),
                        Income = c.Single(nullable: false),
                        WardMemberName = c.String(maxLength: 100),
                        ModeOfPayment = c.String(maxLength: 100),
                        IsServicePension = c.Boolean(nullable: false),
                        IsIncomeTaxPayable = c.Boolean(nullable: false),
                        IsEmployeeProvidentPensionTaker = c.Boolean(nullable: false),
                        LandOwnership = c.String(maxLength: 100),
                        ResidingYears = c.String(maxLength: 100),
                        IssueDate = c.DateTime(),
                        IssueById = c.Long(),
                        ApproveById = c.Long(),
                        CustomerId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                        IsHealthCondition = c.String(maxLength: 100),
                        IsPoor = c.Boolean(nullable: false),
                        IsBeggar = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApproveById)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IssueById)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: true)
                .Index(t => t.IssueById)
                .Index(t => t.ApproveById)
                .Index(t => t.CustomerId)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.IndiraGandhiNationalWidowPensions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        PensionCode = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                        CareOf = c.String(maxLength: 100),
                        Gender = c.String(maxLength: 100),
                        WardNumber = c.String(maxLength: 100),
                        HouseNumber = c.String(maxLength: 100),
                        Address = c.String(maxLength: 100),
                        PostOffice = c.String(maxLength: 100),
                        Pincode = c.String(maxLength: 100),
                        MobileNumber = c.String(maxLength: 100),
                        RationCardNumber = c.String(maxLength: 100),
                        Income = c.Single(nullable: false),
                        WardMemberName = c.String(maxLength: 100),
                        ModeOfPayment = c.String(maxLength: 100),
                        IsServicePension = c.Boolean(nullable: false),
                        IsIncomeTaxPayable = c.Boolean(nullable: false),
                        IsEmployeeProvidentPensionTaker = c.Boolean(nullable: false),
                        LandOwnership = c.String(maxLength: 100),
                        ResidingYears = c.String(maxLength: 100),
                        IssueDate = c.DateTime(),
                        IssueById = c.Long(),
                        ApproveById = c.Long(),
                        CustomerId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApproveById)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IssueById)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: true)
                .Index(t => t.IssueById)
                .Index(t => t.ApproveById)
                .Index(t => t.CustomerId)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Mediseps",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 100),
                        MobileNo = c.String(maxLength: 100),
                        Age = c.Int(nullable: false),
                        Gender = c.String(maxLength: 100),
                        DOB = c.DateTime(nullable: false),
                        RetirementDate = c.DateTime(nullable: false),
                        Post = c.String(maxLength: 100),
                        Office = c.String(maxLength: 100),
                        PenNo = c.String(maxLength: 100),
                        PPO = c.String(maxLength: 100),
                        Treasury = c.String(maxLength: 100),
                        Agency = c.String(maxLength: 200),
                        PensionSchemesAvailed = c.String(maxLength: 200),
                        AadharNo = c.String(maxLength: 100),
                        IdNo = c.String(maxLength: 100),
                        PANno = c.String(maxLength: 100),
                        BloodGroup = c.String(maxLength: 100),
                        IsSchemeUser = c.Boolean(nullable: false),
                        SchemeNo = c.String(maxLength: 100),
                        PermanentAddress = c.String(maxLength: 300),
                        IsAllowanceGranted = c.Boolean(nullable: false),
                        Allowance = c.String(maxLength: 100),
                        IsChildScheme = c.Boolean(nullable: false),
                        PartnerName = c.String(maxLength: 100),
                        PartnerAadharNo = c.String(maxLength: 100),
                        PartnerIdNo = c.String(maxLength: 100),
                        PartnerBloodGroup = c.String(maxLength: 100),
                        ChildName = c.String(maxLength: 200),
                        ChildAadhar = c.String(maxLength: 100),
                        ChildIDno = c.String(maxLength: 100),
                        ChildDOB = c.DateTime(nullable: false),
                        ChildGender = c.String(maxLength: 100),
                        ChildBloodGroup = c.String(maxLength: 100),
                        IssueDate = c.DateTime(),
                        IssueById = c.Long(),
                        ApproveById = c.Long(),
                        CustomerId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApproveById)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IssueById)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: true)
                .Index(t => t.IssueById)
                .Index(t => t.ApproveById)
                .Index(t => t.CustomerId)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Snehapoorvams",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 100),
                        MobileNo = c.String(maxLength: 100),
                        Address = c.String(maxLength: 300),
                        PinCode = c.String(maxLength: 100),
                        DOB = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        School = c.String(maxLength: 200),
                        NatureOfSchool = c.String(maxLength: 100),
                        ClassStudied = c.String(maxLength: 100),
                        SchoolDistrict = c.String(maxLength: 100),
                        JobType = c.String(maxLength: 100),
                        RevenueDistrict = c.String(maxLength: 100),
                        FatherName = c.String(maxLength: 100),
                        IsFatherAlive = c.Boolean(nullable: false),
                        MotherName = c.String(maxLength: 100),
                        IsMotherAlive = c.Boolean(nullable: false),
                        GuardianName = c.String(maxLength: 100),
                        GuardianNameNo = c.String(maxLength: 100),
                        GuardianAddress = c.String(maxLength: 300),
                        RelationshipwithStudent = c.String(maxLength: 100),
                        IssueDate = c.DateTime(),
                        IssueById = c.Long(),
                        ApproveById = c.Long(),
                        CustomerId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApproveById)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IssueById)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: true)
                .Index(t => t.IssueById)
                .Index(t => t.ApproveById)
                .Index(t => t.CustomerId)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.UnmarriedWomenPensions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        PensionCode = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                        CareOf = c.String(maxLength: 100),
                        Gender = c.String(maxLength: 100),
                        WardNumber = c.String(maxLength: 100),
                        HouseNumber = c.String(maxLength: 100),
                        Address = c.String(maxLength: 100),
                        PostOffice = c.String(maxLength: 100),
                        Pincode = c.String(maxLength: 100),
                        MobileNumber = c.String(maxLength: 100),
                        RationCardNumber = c.String(maxLength: 100),
                        Income = c.Single(nullable: false),
                        WardMemberName = c.String(maxLength: 100),
                        ModeOfPayment = c.String(maxLength: 100),
                        IsServicePension = c.Boolean(nullable: false),
                        IsIncomeTaxPayable = c.Boolean(nullable: false),
                        IsEmployeeProvidentPensionTaker = c.Boolean(nullable: false),
                        LandOwnership = c.String(maxLength: 100),
                        ResidingYears = c.String(maxLength: 100),
                        IssueDate = c.DateTime(),
                        IssueById = c.Long(),
                        ApproveById = c.Long(),
                        CustomerId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApproveById)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IssueById)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: true)
                .Index(t => t.IssueById)
                .Index(t => t.ApproveById)
                .Index(t => t.CustomerId)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Vayomadhurams",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 100),
                        DOB = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        PermanentAddress = c.String(maxLength: 300),
                        PresentAddress = c.String(maxLength: 300),
                        MobileNo = c.String(maxLength: 100),
                        AadharNo = c.String(maxLength: 100),
                        RationCardNo = c.String(maxLength: 100),
                        RationPriority = c.String(maxLength: 100),
                        IsSelfAttested = c.Boolean(nullable: false),
                        IsDiabetic = c.Boolean(nullable: false),
                        IsGlucoseMeterUser = c.Boolean(nullable: false),
                        HospitalName = c.String(maxLength: 200),
                        DiabeticPeriod = c.String(maxLength: 100),
                        DocName = c.String(maxLength: 100),
                        IdMark = c.String(maxLength: 100),
                        TreatmentDuration = c.String(maxLength: 100),
                        Designation = c.String(maxLength: 100),
                        RegNo = c.String(maxLength: 100),
                        Place = c.String(maxLength: 100),
                        IssueDate = c.DateTime(),
                        IssueById = c.Long(),
                        ApproveById = c.Long(),
                        CustomerId = c.Long(nullable: false),
                        VillageId = c.Long(nullable: false),
                        DistrictId = c.Long(nullable: false),
                        StateId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApproveById)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IssueById)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.Villages", t => t.VillageId, cascadeDelete: true)
                .Index(t => t.IssueById)
                .Index(t => t.ApproveById)
                .Index(t => t.CustomerId)
                .Index(t => t.VillageId)
                .Index(t => t.DistrictId)
                .Index(t => t.StateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vayomadhurams", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.Vayomadhurams", "StateId", "dbo.States");
            DropForeignKey("dbo.Vayomadhurams", "IssueById", "dbo.Users");
            DropForeignKey("dbo.Vayomadhurams", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Vayomadhurams", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Vayomadhurams", "ApproveById", "dbo.Users");
            DropForeignKey("dbo.UnmarriedWomenPensions", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.UnmarriedWomenPensions", "StateId", "dbo.States");
            DropForeignKey("dbo.UnmarriedWomenPensions", "IssueById", "dbo.Users");
            DropForeignKey("dbo.UnmarriedWomenPensions", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.UnmarriedWomenPensions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.UnmarriedWomenPensions", "ApproveById", "dbo.Users");
            DropForeignKey("dbo.Snehapoorvams", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.Snehapoorvams", "StateId", "dbo.States");
            DropForeignKey("dbo.Snehapoorvams", "IssueById", "dbo.Users");
            DropForeignKey("dbo.Snehapoorvams", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Snehapoorvams", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Snehapoorvams", "ApproveById", "dbo.Users");
            DropForeignKey("dbo.Mediseps", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.Mediseps", "StateId", "dbo.States");
            DropForeignKey("dbo.Mediseps", "IssueById", "dbo.Users");
            DropForeignKey("dbo.Mediseps", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Mediseps", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Mediseps", "ApproveById", "dbo.Users");
            DropForeignKey("dbo.IndiraGandhiNationalWidowPensions", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.IndiraGandhiNationalWidowPensions", "StateId", "dbo.States");
            DropForeignKey("dbo.IndiraGandhiNationalWidowPensions", "IssueById", "dbo.Users");
            DropForeignKey("dbo.IndiraGandhiNationalWidowPensions", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.IndiraGandhiNationalWidowPensions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.IndiraGandhiNationalWidowPensions", "ApproveById", "dbo.Users");
            DropForeignKey("dbo.IndiraGandhiNationalOldAgePensions", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.IndiraGandhiNationalOldAgePensions", "StateId", "dbo.States");
            DropForeignKey("dbo.IndiraGandhiNationalOldAgePensions", "IssueById", "dbo.Users");
            DropForeignKey("dbo.IndiraGandhiNationalOldAgePensions", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.IndiraGandhiNationalOldAgePensions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.IndiraGandhiNationalOldAgePensions", "ApproveById", "dbo.Users");
            DropForeignKey("dbo.IndiraGandhiNationalDisabilityPensions", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.IndiraGandhiNationalDisabilityPensions", "StateId", "dbo.States");
            DropForeignKey("dbo.IndiraGandhiNationalDisabilityPensions", "IssueById", "dbo.Users");
            DropForeignKey("dbo.IndiraGandhiNationalDisabilityPensions", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.IndiraGandhiNationalDisabilityPensions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.IndiraGandhiNationalDisabilityPensions", "ApproveById", "dbo.Users");
            DropForeignKey("dbo.AgricultureWorkersPensions", "VillageId", "dbo.Villages");
            DropForeignKey("dbo.AgricultureWorkersPensions", "StateId", "dbo.States");
            DropForeignKey("dbo.AgricultureWorkersPensions", "IssueById", "dbo.Users");
            DropForeignKey("dbo.AgricultureWorkersPensions", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.AgricultureWorkersPensions", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.AgricultureWorkersPensions", "ApproveById", "dbo.Users");
            DropIndex("dbo.Vayomadhurams", new[] { "StateId" });
            DropIndex("dbo.Vayomadhurams", new[] { "DistrictId" });
            DropIndex("dbo.Vayomadhurams", new[] { "VillageId" });
            DropIndex("dbo.Vayomadhurams", new[] { "CustomerId" });
            DropIndex("dbo.Vayomadhurams", new[] { "ApproveById" });
            DropIndex("dbo.Vayomadhurams", new[] { "IssueById" });
            DropIndex("dbo.UnmarriedWomenPensions", new[] { "StateId" });
            DropIndex("dbo.UnmarriedWomenPensions", new[] { "DistrictId" });
            DropIndex("dbo.UnmarriedWomenPensions", new[] { "VillageId" });
            DropIndex("dbo.UnmarriedWomenPensions", new[] { "CustomerId" });
            DropIndex("dbo.UnmarriedWomenPensions", new[] { "ApproveById" });
            DropIndex("dbo.UnmarriedWomenPensions", new[] { "IssueById" });
            DropIndex("dbo.Snehapoorvams", new[] { "StateId" });
            DropIndex("dbo.Snehapoorvams", new[] { "DistrictId" });
            DropIndex("dbo.Snehapoorvams", new[] { "VillageId" });
            DropIndex("dbo.Snehapoorvams", new[] { "CustomerId" });
            DropIndex("dbo.Snehapoorvams", new[] { "ApproveById" });
            DropIndex("dbo.Snehapoorvams", new[] { "IssueById" });
            DropIndex("dbo.Mediseps", new[] { "StateId" });
            DropIndex("dbo.Mediseps", new[] { "DistrictId" });
            DropIndex("dbo.Mediseps", new[] { "VillageId" });
            DropIndex("dbo.Mediseps", new[] { "CustomerId" });
            DropIndex("dbo.Mediseps", new[] { "ApproveById" });
            DropIndex("dbo.Mediseps", new[] { "IssueById" });
            DropIndex("dbo.IndiraGandhiNationalWidowPensions", new[] { "StateId" });
            DropIndex("dbo.IndiraGandhiNationalWidowPensions", new[] { "DistrictId" });
            DropIndex("dbo.IndiraGandhiNationalWidowPensions", new[] { "VillageId" });
            DropIndex("dbo.IndiraGandhiNationalWidowPensions", new[] { "CustomerId" });
            DropIndex("dbo.IndiraGandhiNationalWidowPensions", new[] { "ApproveById" });
            DropIndex("dbo.IndiraGandhiNationalWidowPensions", new[] { "IssueById" });
            DropIndex("dbo.IndiraGandhiNationalOldAgePensions", new[] { "StateId" });
            DropIndex("dbo.IndiraGandhiNationalOldAgePensions", new[] { "DistrictId" });
            DropIndex("dbo.IndiraGandhiNationalOldAgePensions", new[] { "VillageId" });
            DropIndex("dbo.IndiraGandhiNationalOldAgePensions", new[] { "CustomerId" });
            DropIndex("dbo.IndiraGandhiNationalOldAgePensions", new[] { "ApproveById" });
            DropIndex("dbo.IndiraGandhiNationalOldAgePensions", new[] { "IssueById" });
            DropIndex("dbo.IndiraGandhiNationalDisabilityPensions", new[] { "StateId" });
            DropIndex("dbo.IndiraGandhiNationalDisabilityPensions", new[] { "DistrictId" });
            DropIndex("dbo.IndiraGandhiNationalDisabilityPensions", new[] { "VillageId" });
            DropIndex("dbo.IndiraGandhiNationalDisabilityPensions", new[] { "CustomerId" });
            DropIndex("dbo.IndiraGandhiNationalDisabilityPensions", new[] { "ApproveById" });
            DropIndex("dbo.IndiraGandhiNationalDisabilityPensions", new[] { "IssueById" });
            DropIndex("dbo.AgricultureWorkersPensions", new[] { "StateId" });
            DropIndex("dbo.AgricultureWorkersPensions", new[] { "DistrictId" });
            DropIndex("dbo.AgricultureWorkersPensions", new[] { "VillageId" });
            DropIndex("dbo.AgricultureWorkersPensions", new[] { "CustomerId" });
            DropIndex("dbo.AgricultureWorkersPensions", new[] { "ApproveById" });
            DropIndex("dbo.AgricultureWorkersPensions", new[] { "IssueById" });
            DropTable("dbo.Vayomadhurams");
            DropTable("dbo.UnmarriedWomenPensions");
            DropTable("dbo.Snehapoorvams");
            DropTable("dbo.Mediseps");
            DropTable("dbo.IndiraGandhiNationalWidowPensions");
            DropTable("dbo.IndiraGandhiNationalOldAgePensions");
            DropTable("dbo.IndiraGandhiNationalDisabilityPensions");
            DropTable("dbo.AgricultureWorkersPensions");
        }
    }
}
