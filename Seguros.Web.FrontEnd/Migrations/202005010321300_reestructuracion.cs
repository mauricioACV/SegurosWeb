namespace Seguros.Web.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reestructuracion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Region", "ciudad_Id", "dbo.Ciudad");
            DropIndex("dbo.Region", new[] { "ciudad_Id" });
            AddColumn("dbo.Ciudad", "region_Id", c => c.Int());
            AddColumn("dbo.Comuna", "ciudad_Id", c => c.Int());
            AddColumn("dbo.Observacion_req", "requerimiento_Id", c => c.Int());
            AddColumn("dbo.Requerimiento", "cliente_Id_cliente", c => c.Int());
            AddColumn("dbo.Requerimiento", "estado_Id", c => c.Int());
            CreateIndex("dbo.Ciudad", "region_Id");
            CreateIndex("dbo.Comuna", "ciudad_Id");
            CreateIndex("dbo.Observacion_req", "requerimiento_Id");
            CreateIndex("dbo.Requerimiento", "cliente_Id_cliente");
            CreateIndex("dbo.Requerimiento", "estado_Id");
            AddForeignKey("dbo.Comuna", "ciudad_Id", "dbo.Ciudad", "Id");
            AddForeignKey("dbo.Ciudad", "region_Id", "dbo.Region", "Id");
            AddForeignKey("dbo.Requerimiento", "cliente_Id_cliente", "dbo.Cliente", "Id_cliente");
            AddForeignKey("dbo.Requerimiento", "estado_Id", "dbo.Estado", "Id");
            AddForeignKey("dbo.Observacion_req", "requerimiento_Id", "dbo.Requerimiento", "Id");
            DropColumn("dbo.Ciudad", "Id_region");
            DropColumn("dbo.Comuna", "Id_ciudad");
            DropColumn("dbo.Region", "ciudad_Id");
            DropColumn("dbo.Requerimiento", "Id_estado");
            DropColumn("dbo.Requerimiento", "Id_cliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requerimiento", "Id_cliente", c => c.Int(nullable: false));
            AddColumn("dbo.Requerimiento", "Id_estado", c => c.Int(nullable: false));
            AddColumn("dbo.Region", "ciudad_Id", c => c.Int());
            AddColumn("dbo.Comuna", "Id_ciudad", c => c.Int(nullable: false));
            AddColumn("dbo.Ciudad", "Id_region", c => c.Int(nullable: false));
            DropForeignKey("dbo.Observacion_req", "requerimiento_Id", "dbo.Requerimiento");
            DropForeignKey("dbo.Requerimiento", "estado_Id", "dbo.Estado");
            DropForeignKey("dbo.Requerimiento", "cliente_Id_cliente", "dbo.Cliente");
            DropForeignKey("dbo.Ciudad", "region_Id", "dbo.Region");
            DropForeignKey("dbo.Comuna", "ciudad_Id", "dbo.Ciudad");
            DropIndex("dbo.Requerimiento", new[] { "estado_Id" });
            DropIndex("dbo.Requerimiento", new[] { "cliente_Id_cliente" });
            DropIndex("dbo.Observacion_req", new[] { "requerimiento_Id" });
            DropIndex("dbo.Comuna", new[] { "ciudad_Id" });
            DropIndex("dbo.Ciudad", new[] { "region_Id" });
            DropColumn("dbo.Requerimiento", "estado_Id");
            DropColumn("dbo.Requerimiento", "cliente_Id_cliente");
            DropColumn("dbo.Observacion_req", "requerimiento_Id");
            DropColumn("dbo.Comuna", "ciudad_Id");
            DropColumn("dbo.Ciudad", "region_Id");
            CreateIndex("dbo.Region", "ciudad_Id");
            AddForeignKey("dbo.Region", "ciudad_Id", "dbo.Ciudad", "Id");
        }
    }
}
