namespace smartVillage.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReleationShipCertEdit3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RelationshipCertificates", "IssueById", "dbo.Users");
            DropIndex("dbo.RelationshipCertificates", new[] { "IssueById" });
            AddColumn("dbo.RelationshipCertificates", "ApproveById", c => c.Long());
            AlterColumn("dbo.RelationshipCertificates", "Gender", c => c.String());
            AlterColumn("dbo.RelationshipCertificates", "Address", c => c.String(maxLength: 200));
            AlterColumn("dbo.RelationshipCertificates", "Reason", c => c.String(maxLength: 200));
            AlterColumn("dbo.RelationshipCertificates", "IssueDate", c => c.DateTime());
            AlterColumn("dbo.RelationshipCertificates", "IssueById", c => c.Long());
            CreateIndex("dbo.RelationshipCertificates", "IssueById");
            CreateIndex("dbo.RelationshipCertificates", "ApproveById");
            AddForeignKey("dbo.RelationshipCertificates", "ApproveById", "dbo.Users", "Id");
            AddForeignKey("dbo.RelationshipCertificates", "IssueById", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RelationshipCertificates", "IssueById", "dbo.Users");
            DropForeignKey("dbo.RelationshipCertificates", "ApproveById", "dbo.Users");
            DropIndex("dbo.RelationshipCertificates", new[] { "ApproveById" });
            DropIndex("dbo.RelationshipCertificates", new[] { "IssueById" });
            AlterColumn("dbo.RelationshipCertificates", "IssueById", c => c.Long(nullable: false));
            AlterColumn("dbo.RelationshipCertificates", "IssueDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RelationshipCertificates", "Reason", c => c.String(maxLength: 250));
            AlterColumn("dbo.RelationshipCertificates", "Address", c => c.String(maxLength: 250));
            AlterColumn("dbo.RelationshipCertificates", "Gender", c => c.String(maxLength: 100));
            DropColumn("dbo.RelationshipCertificates", "ApproveById");
            CreateIndex("dbo.RelationshipCertificates", "IssueById");
            AddForeignKey("dbo.RelationshipCertificates", "IssueById", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
