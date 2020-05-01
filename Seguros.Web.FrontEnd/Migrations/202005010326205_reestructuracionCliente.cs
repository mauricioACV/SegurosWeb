namespace Seguros.Web.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reestructuracionCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "ciudad_Id", c => c.Int());
            AddColumn("dbo.Cliente", "comuna_Id", c => c.Int());
            AddColumn("dbo.Cliente", "region_Id", c => c.Int());
            CreateIndex("dbo.Cliente", "ciudad_Id");
            CreateIndex("dbo.Cliente", "comuna_Id");
            CreateIndex("dbo.Cliente", "region_Id");
            AddForeignKey("dbo.Cliente", "ciudad_Id", "dbo.Ciudad", "Id");
            AddForeignKey("dbo.Cliente", "comuna_Id", "dbo.Comuna", "Id");
            AddForeignKey("dbo.Cliente", "region_Id", "dbo.Region", "Id");
            DropColumn("dbo.Cliente", "Comuna");
            DropColumn("dbo.Cliente", "Ciudad");
            DropColumn("dbo.Cliente", "Region");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cliente", "Region", c => c.String());
            AddColumn("dbo.Cliente", "Ciudad", c => c.String());
            AddColumn("dbo.Cliente", "Comuna", c => c.String());
            DropForeignKey("dbo.Cliente", "region_Id", "dbo.Region");
            DropForeignKey("dbo.Cliente", "comuna_Id", "dbo.Comuna");
            DropForeignKey("dbo.Cliente", "ciudad_Id", "dbo.Ciudad");
            DropIndex("dbo.Cliente", new[] { "region_Id" });
            DropIndex("dbo.Cliente", new[] { "comuna_Id" });
            DropIndex("dbo.Cliente", new[] { "ciudad_Id" });
            DropColumn("dbo.Cliente", "region_Id");
            DropColumn("dbo.Cliente", "comuna_Id");
            DropColumn("dbo.Cliente", "ciudad_Id");
        }
    }
}
