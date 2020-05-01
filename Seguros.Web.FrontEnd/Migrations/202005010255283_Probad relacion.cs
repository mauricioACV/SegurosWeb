namespace Seguros.Web.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Probadrelacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Region", "ciudad_Id", c => c.Int());
            CreateIndex("dbo.Region", "ciudad_Id");
            AddForeignKey("dbo.Region", "ciudad_Id", "dbo.Ciudad", "Id");
            DropColumn("dbo.Region", "Nombre_capital");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Region", "Nombre_capital", c => c.String());
            DropForeignKey("dbo.Region", "ciudad_Id", "dbo.Ciudad");
            DropIndex("dbo.Region", new[] { "ciudad_Id" });
            DropColumn("dbo.Region", "ciudad_Id");
        }
    }
}
