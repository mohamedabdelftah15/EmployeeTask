namespace Employee.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        Gender = c.String(),
                        Birthdate = c.DateTime(),
                        CountryId = c.Int(),
                        CityId = c.Int(),
                    })
                .PrimaryKey(t => t.EId)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Employee", "CityId", "dbo.City");
            DropForeignKey("dbo.City", "CountryId", "dbo.Country");
            DropIndex("dbo.Employee", new[] { "CityId" });
            DropIndex("dbo.Employee", new[] { "CountryId" });
            DropIndex("dbo.City", new[] { "CountryId" });
            DropTable("dbo.Employee");
            DropTable("dbo.Country");
            DropTable("dbo.City");
        }
    }
}
