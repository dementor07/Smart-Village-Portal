namespace smartVillage.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReleationShipCertEdit4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.IdentificationCertificates", name: "EmployeeId_Id", newName: "ApproveById");
            RenameIndex(table: "dbo.IdentificationCertificates", name: "IX_EmployeeId_Id", newName: "IX_ApproveById");
            AddColumn("dbo.IdentificationCertificates", "StateId", c => c.Long(nullable: false));
            AlterColumn("dbo.IdentificationCertificates", "IssueDate", c => c.DateTime());
            AlterColumn("dbo.IdentificationCertificates", "IssueById", c => c.Long());
            CreateIndex("dbo.IdentificationCertificates", "IssueById");
            CreateIndex("dbo.IdentificationCertificates", "StateId");
            AddForeignKey("dbo.IdentificationCertificates", "IssueById", "dbo.Users", "Id");
            AddForeignKey("dbo.IdentificationCertificates", "StateId", "dbo.States", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentificationCertificates", "StateId", "dbo.States");
            DropForeignKey("dbo.IdentificationCertificates", "IssueById", "dbo.Users");
            DropIndex("dbo.IdentificationCertificates", new[] { "StateId" });
            DropIndex("dbo.IdentificationCertificates", new[] { "IssueById" });
            AlterColumn("dbo.IdentificationCertificates", "IssueById", c => c.Long(nullable: false));
            AlterColumn("dbo.IdentificationCertificates", "IssueDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.IdentificationCertificates", "StateId");
            RenameIndex(table: "dbo.IdentificationCertificates", name: "IX_ApproveById", newName: "IX_EmployeeId_Id");
            RenameColumn(table: "dbo.IdentificationCertificates", name: "ApproveById", newName: "EmployeeId_Id");
        }
    }
}
