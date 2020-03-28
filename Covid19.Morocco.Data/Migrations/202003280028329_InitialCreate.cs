namespace Covid19.Morocco.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CaseDate = c.DateTime(nullable: false),
                        CaseType = c.Int(nullable: false),
                        CasesCount = c.Int(nullable: false),
                        City_Id = c.Guid(),
                        Region_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Regions", t => t.Region_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Region_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Region_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.Region_Id)
                .Index(t => t.Region_Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "Region_Id", "dbo.Regions");
            DropForeignKey("dbo.Cases", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Region_Id", "dbo.Regions");
            DropIndex("dbo.Cities", new[] { "Region_Id" });
            DropIndex("dbo.Cases", new[] { "Region_Id" });
            DropIndex("dbo.Cases", new[] { "City_Id" });
            DropTable("dbo.Regions");
            DropTable("dbo.Cities");
            DropTable("dbo.Cases");
        }
    }
}
