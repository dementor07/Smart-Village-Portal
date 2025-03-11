namespace smartVillage.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReleationShipCertEdit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FamilyMembershipCertificates", "ApproveById", "dbo.Users");
            DropForeignKey("dbo.FamilyMembershipCertificates", "IssueById", "dbo.Users");
            DropIndex("dbo.FamilyMembershipCertificates", new[] { "IssueById" });
            DropIndex("dbo.FamilyMembershipCertificates", new[] { "ApproveById" });
            AlterColumn("dbo.FamilyMembershipCertificates", "Relationship", c => c.String(maxLength: 100));
            AlterColumn("dbo.FamilyMembershipCertificates", "Taluk", c => c.String());
            AlterColumn("dbo.FamilyMembershipCertificates", "Reason", c => c.String(maxLength: 200));
            AlterColumn("dbo.FamilyMembershipCertificates", "IssueById", c => c.Long());
            AlterColumn("dbo.FamilyMembershipCertificates", "ApproveById", c => c.Long());
            CreateIndex("dbo.FamilyMembershipCertificates", "IssueById");
            CreateIndex("dbo.FamilyMembershipCertificates", "ApproveById");
            AddForeignKey("dbo.FamilyMembershipCertificates", "ApproveById", "dbo.Users", "Id");
            AddForeignKey("dbo.FamilyMembershipCertificates", "IssueById", "dbo.Users", "Id");
            DropColumn("dbo.FamilyMembershipCertificates", "FamilyMembership");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FamilyMembershipCertificates", "FamilyMembership", c => c.String());
            DropForeignKey("dbo.FamilyMembershipCertificates", "IssueById", "dbo.Users");
            DropForeignKey("dbo.FamilyMembershipCertificates", "ApproveById", "dbo.Users");
            DropIndex("dbo.FamilyMembershipCertificates", new[] { "ApproveById" });
            DropIndex("dbo.FamilyMembershipCertificates", new[] { "IssueById" });
            AlterColumn("dbo.FamilyMembershipCertificates", "ApproveById", c => c.Long(nullable: false));
            AlterColumn("dbo.FamilyMembershipCertificates", "IssueById", c => c.Long(nullable: false));
            AlterColumn("dbo.FamilyMembershipCertificates", "Reason", c => c.String(maxLength: 100));
            AlterColumn("dbo.FamilyMembershipCertificates", "Taluk", c => c.String(maxLength: 100));
            AlterColumn("dbo.FamilyMembershipCertificates", "Relationship", c => c.String());
            CreateIndex("dbo.FamilyMembershipCertificates", "ApproveById");
            CreateIndex("dbo.FamilyMembershipCertificates", "IssueById");
            AddForeignKey("dbo.FamilyMembershipCertificates", "IssueById", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FamilyMembershipCertificates", "ApproveById", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
