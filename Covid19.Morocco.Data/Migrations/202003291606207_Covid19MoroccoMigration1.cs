namespace Covid19.Morocco.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Covid19MoroccoMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "Label", c => c.String());
            AddColumn("dbo.Regions", "Label", c => c.String());
            DropColumn("dbo.Cities", "Name");
            DropColumn("dbo.Regions", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Regions", "Name", c => c.String());
            AddColumn("dbo.Cities", "Name", c => c.String());
            DropColumn("dbo.Regions", "Label");
            DropColumn("dbo.Cities", "Label");
        }
    }
}
