namespace Covid19.Morocco.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Covid19MoroccoMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "Code", c => c.String());
            AddColumn("dbo.Regions", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Regions", "Code");
            DropColumn("dbo.Cities", "Code");
        }
    }
}
