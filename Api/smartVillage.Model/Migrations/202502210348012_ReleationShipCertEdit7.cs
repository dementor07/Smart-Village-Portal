namespace smartVillage.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReleationShipCertEdit7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DomicileCertificates", "CasteId", "dbo.Castes");
            DropForeignKey("dbo.DomicileCertificates", "ReligionId", "dbo.Religions");
            DropForeignKey("dbo.CommunityCertificates", "ApproveById", "dbo.Users");
            DropForeignKey("dbo.CommunityCertificates", "IssueById", "dbo.Users");
            DropForeignKey("dbo.DomicileCertificates", "ApproveById", "dbo.Users");
            DropIndex("dbo.CommunityCertificates", new[] { "IssueById" });
            DropIndex("dbo.CommunityCertificates", new[] { "ApproveById" });
            DropIndex("dbo.DomicileCertificates", new[] { "ApproveById" });
            DropIndex("dbo.DomicileCertificates", new[] { "ReligionId" });
            DropIndex("dbo.DomicileCertificates", new[] { "CasteId" });
            AlterColumn("dbo.CommunityCertificates", "IssueDate", c => c.DateTime());
            AlterColumn("dbo.CommunityCertificates", "IssueById", c => c.Long());
            AlterColumn("dbo.CommunityCertificates", "ApproveById", c => c.Long());
            AlterColumn("dbo.DomicileCertificates", "IssueDate", c => c.DateTime());
            AlterColumn("dbo.DomicileCertificates", "ApproveById", c => c.Long());
            CreateIndex("dbo.CommunityCertificates", "IssueById");
            CreateIndex("dbo.CommunityCertificates", "ApproveById");
            CreateIndex("dbo.DomicileCertificates", "ApproveById");
            AddForeignKey("dbo.CommunityCertificates", "ApproveById", "dbo.Users", "Id");
            AddForeignKey("dbo.CommunityCertificates", "IssueById", "dbo.Users", "Id");
            AddForeignKey("dbo.DomicileCertificates", "ApproveById", "dbo.Users", "Id");
            DropColumn("dbo.DomicileCertificates", "ReligionId");
            DropColumn("dbo.DomicileCertificates", "CasteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DomicileCertificates", "CasteId", c => c.Long(nullable: false));
            AddColumn("dbo.DomicileCertificates", "ReligionId", c => c.Long(nullable: false));
            DropForeignKey("dbo.DomicileCertificates", "ApproveById", "dbo.Users");
            DropForeignKey("dbo.CommunityCertificates", "IssueById", "dbo.Users");
            DropForeignKey("dbo.CommunityCertificates", "ApproveById", "dbo.Users");
            DropIndex("dbo.DomicileCertificates", new[] { "ApproveById" });
            DropIndex("dbo.CommunityCertificates", new[] { "ApproveById" });
            DropIndex("dbo.CommunityCertificates", new[] { "IssueById" });
            AlterColumn("dbo.DomicileCertificates", "ApproveById", c => c.Long(nullable: false));
            AlterColumn("dbo.DomicileCertificates", "IssueDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CommunityCertificates", "ApproveById", c => c.Long(nullable: false));
            AlterColumn("dbo.CommunityCertificates", "IssueById", c => c.Long(nullable: false));
            AlterColumn("dbo.CommunityCertificates", "IssueDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.DomicileCertificates", "CasteId");
            CreateIndex("dbo.DomicileCertificates", "ReligionId");
            CreateIndex("dbo.DomicileCertificates", "ApproveById");
            CreateIndex("dbo.CommunityCertificates", "ApproveById");
            CreateIndex("dbo.CommunityCertificates", "IssueById");
            AddForeignKey("dbo.DomicileCertificates", "ApproveById", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CommunityCertificates", "IssueById", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CommunityCertificates", "ApproveById", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DomicileCertificates", "ReligionId", "dbo.Religions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DomicileCertificates", "CasteId", "dbo.Castes", "Id", cascadeDelete: true);
        }
    }
}
