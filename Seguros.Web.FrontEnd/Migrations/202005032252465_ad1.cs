namespace Seguros.Web.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ad1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cliente", "ciudad_Id", "dbo.Ciudad");
            DropForeignKey("dbo.Cliente", "comuna_Id", "dbo.Comuna");
            DropForeignKey("dbo.Cliente", "Region_Id", "dbo.Region");
            DropIndex("dbo.Cliente", new[] { "ciudad_Id" });
            DropIndex("dbo.Cliente", new[] { "comuna_Id" });
            DropIndex("dbo.Cliente", new[] { "Region_Id" });
            AlterColumn("dbo.Cliente", "Rut_cliente", c => c.String(nullable: false));
            AlterColumn("dbo.Cliente", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Cliente", "ApellidoPat", c => c.String(nullable: false));
            AlterColumn("dbo.Cliente", "ApellidoMat", c => c.String(nullable: false));
            AlterColumn("dbo.Cliente", "Calle", c => c.String(nullable: false));
            AlterColumn("dbo.Cliente", "ciudad_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Cliente", "comuna_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Cliente", "Region_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Cliente", "ciudad_Id");
            CreateIndex("dbo.Cliente", "comuna_Id");
            CreateIndex("dbo.Cliente", "Region_Id");
            AddForeignKey("dbo.Cliente", "ciudad_Id", "dbo.Ciudad", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cliente", "comuna_Id", "dbo.Comuna", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cliente", "Region_Id", "dbo.Region", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cliente", "Region_Id", "dbo.Region");
            DropForeignKey("dbo.Cliente", "comuna_Id", "dbo.Comuna");
            DropForeignKey("dbo.Cliente", "ciudad_Id", "dbo.Ciudad");
            DropIndex("dbo.Cliente", new[] { "Region_Id" });
            DropIndex("dbo.Cliente", new[] { "comuna_Id" });
            DropIndex("dbo.Cliente", new[] { "ciudad_Id" });
            AlterColumn("dbo.Cliente", "Region_Id", c => c.Int());
            AlterColumn("dbo.Cliente", "comuna_Id", c => c.Int());
            AlterColumn("dbo.Cliente", "ciudad_Id", c => c.Int());
            AlterColumn("dbo.Cliente", "Calle", c => c.String());
            AlterColumn("dbo.Cliente", "ApellidoMat", c => c.String());
            AlterColumn("dbo.Cliente", "ApellidoPat", c => c.String());
            AlterColumn("dbo.Cliente", "Nombre", c => c.String());
            AlterColumn("dbo.Cliente", "Rut_cliente", c => c.String());
            CreateIndex("dbo.Cliente", "Region_Id");
            CreateIndex("dbo.Cliente", "comuna_Id");
            CreateIndex("dbo.Cliente", "ciudad_Id");
            AddForeignKey("dbo.Cliente", "Region_Id", "dbo.Region", "Id");
            AddForeignKey("dbo.Cliente", "comuna_Id", "dbo.Comuna", "Id");
            AddForeignKey("dbo.Cliente", "ciudad_Id", "dbo.Ciudad", "Id");
        }
    }
}
