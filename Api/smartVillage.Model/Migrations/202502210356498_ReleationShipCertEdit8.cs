namespace smartVillage.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReleationShipCertEdit8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NonCreamyLayerCertificates", "IssueById", "dbo.Users");
            DropIndex("dbo.NonCreamyLayerCertificates", new[] { "IssueById" });
            AddColumn("dbo.NonCreamyLayerCertificates", "ApproveById", c => c.Long());
            AlterColumn("dbo.NonCreamyLayerCertificates", "IssueDate", c => c.DateTime());
            AlterColumn("dbo.NonCreamyLayerCertificates", "IssueById", c => c.Long());
            CreateIndex("dbo.NonCreamyLayerCertificates", "IssueById");
            CreateIndex("dbo.NonCreamyLayerCertificates", "ApproveById");
            AddForeignKey("dbo.NonCreamyLayerCertificates", "ApproveById", "dbo.Users", "Id");
            AddForeignKey("dbo.NonCreamyLayerCertificates", "IssueById", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NonCreamyLayerCertificates", "IssueById", "dbo.Users");
            DropForeignKey("dbo.NonCreamyLayerCertificates", "ApproveById", "dbo.Users");
            DropIndex("dbo.NonCreamyLayerCertificates", new[] { "ApproveById" });
            DropIndex("dbo.NonCreamyLayerCertificates", new[] { "IssueById" });
            AlterColumn("dbo.NonCreamyLayerCertificates", "IssueById", c => c.Long(nullable: false));
            AlterColumn("dbo.NonCreamyLayerCertificates", "IssueDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.NonCreamyLayerCertificates", "ApproveById");
            CreateIndex("dbo.NonCreamyLayerCertificates", "IssueById");
            AddForeignKey("dbo.NonCreamyLayerCertificates", "IssueById", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
