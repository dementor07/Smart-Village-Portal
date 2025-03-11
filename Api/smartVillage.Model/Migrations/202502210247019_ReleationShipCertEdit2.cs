namespace smartVillage.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReleationShipCertEdit2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FamilyMembershipCertificates", "IssueDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FamilyMembershipCertificates", "IssueDate", c => c.DateTime(nullable: false));
        }
    }
}
