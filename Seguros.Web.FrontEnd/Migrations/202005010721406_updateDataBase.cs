namespace Seguros.Web.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDataBase : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cliente", new[] { "region_Id" });
            CreateIndex("dbo.Cliente", "Region_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cliente", new[] { "Region_Id" });
            CreateIndex("dbo.Cliente", "region_Id");
        }
    }
}
