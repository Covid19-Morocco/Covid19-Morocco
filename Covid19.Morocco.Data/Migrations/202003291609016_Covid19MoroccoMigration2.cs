namespace Covid19.Morocco.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Covid19MoroccoMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "Name", c => c.String());
            AddColumn("dbo.Regions", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Regions", "Name");
            DropColumn("dbo.Cities", "Name");
        }
    }
}
