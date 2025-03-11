namespace smartVillage.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTablesPensions2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mediseps", "PostOffice", c => c.String(maxLength: 100));
            DropColumn("dbo.Mediseps", "Post");
            DropColumn("dbo.Mediseps", "Office");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mediseps", "Office", c => c.String(maxLength: 100));
            AddColumn("dbo.Mediseps", "Post", c => c.String(maxLength: 100));
            DropColumn("dbo.Mediseps", "PostOffice");
        }
    }
}
