namespace smartVillage.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReleationShipCertEdit6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NativityCertificates", "IssueById", "dbo.Users");
            DropIndex("dbo.NativityCertificates", new[] { "IssueById" });
            AddColumn("dbo.NativityCertificates", "ApproveById", c => c.Long());
            AlterColumn("dbo.NativityCertificates", "IssueDate", c => c.DateTime());
            AlterColumn("dbo.NativityCertificates", "IssueById", c => c.Long());
            CreateIndex("dbo.NativityCertificates", "IssueById");
            CreateIndex("dbo.NativityCertificates", "ApproveById");
            AddForeignKey("dbo.NativityCertificates", "ApproveById", "dbo.Users", "Id");
            AddForeignKey("dbo.NativityCertificates", "IssueById", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NativityCertificates", "IssueById", "dbo.Users");
            DropForeignKey("dbo.NativityCertificates", "ApproveById", "dbo.Users");
            DropIndex("dbo.NativityCertificates", new[] { "ApproveById" });
            DropIndex("dbo.NativityCertificates", new[] { "IssueById" });
            AlterColumn("dbo.NativityCertificates", "IssueById", c => c.Long(nullable: false));
            AlterColumn("dbo.NativityCertificates", "IssueDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.NativityCertificates", "ApproveById");
            CreateIndex("dbo.NativityCertificates", "IssueById");
            AddForeignKey("dbo.NativityCertificates", "IssueById", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
