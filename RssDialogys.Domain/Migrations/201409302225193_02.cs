namespace RssDialogys.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Href", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Href");
        }
    }
}
