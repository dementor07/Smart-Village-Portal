namespace smartVillage.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReleationShipCertEdit5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IncomeCertificates", "IssueById", "dbo.Users");
            DropIndex("dbo.IncomeCertificates", new[] { "IssueById" });
            AddColumn("dbo.IncomeCertificates", "AnnualIncome", c => c.Single(nullable: false));
            AddColumn("dbo.IncomeCertificates", "CompanyName", c => c.String(maxLength: 250));
            AddColumn("dbo.IncomeCertificates", "CompanySector", c => c.String(maxLength: 250));
            AddColumn("dbo.IncomeCertificates", "ApproveById", c => c.Long());
            AddColumn("dbo.IncomeCertificates", "StateId", c => c.Long(nullable: false));
            AlterColumn("dbo.IncomeCertificates", "IssueDate", c => c.DateTime());
            AlterColumn("dbo.IncomeCertificates", "IssueById", c => c.Long());
            CreateIndex("dbo.IncomeCertificates", "IssueById");
            CreateIndex("dbo.IncomeCertificates", "ApproveById");
            CreateIndex("dbo.IncomeCertificates", "StateId");
            AddForeignKey("dbo.IncomeCertificates", "ApproveById", "dbo.Users", "Id");
            AddForeignKey("dbo.IncomeCertificates", "StateId", "dbo.States", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IncomeCertificates", "IssueById", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IncomeCertificates", "IssueById", "dbo.Users");
            DropForeignKey("dbo.IncomeCertificates", "StateId", "dbo.States");
            DropForeignKey("dbo.IncomeCertificates", "ApproveById", "dbo.Users");
            DropIndex("dbo.IncomeCertificates", new[] { "StateId" });
            DropIndex("dbo.IncomeCertificates", new[] { "ApproveById" });
            DropIndex("dbo.IncomeCertificates", new[] { "IssueById" });
            AlterColumn("dbo.IncomeCertificates", "IssueById", c => c.Long(nullable: false));
            AlterColumn("dbo.IncomeCertificates", "IssueDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.IncomeCertificates", "StateId");
            DropColumn("dbo.IncomeCertificates", "ApproveById");
            DropColumn("dbo.IncomeCertificates", "CompanySector");
            DropColumn("dbo.IncomeCertificates", "CompanyName");
            DropColumn("dbo.IncomeCertificates", "AnnualIncome");
            CreateIndex("dbo.IncomeCertificates", "IssueById");
            AddForeignKey("dbo.IncomeCertificates", "IssueById", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
