namespace Weather_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WeatherDataDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeatherDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Time = c.DateTime(nullable: false),
                        Temperature = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WeatherDatas");
        }
    }
}
