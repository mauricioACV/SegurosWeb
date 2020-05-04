namespace Seguros.Web.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creaRelacionEmpleadoRequerimiento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requerimiento", "Empleado_Id_empleado", c => c.Int());
            CreateIndex("dbo.Requerimiento", "Empleado_Id_empleado");
            AddForeignKey("dbo.Requerimiento", "Empleado_Id_empleado", "dbo.Empleado", "Id_empleado");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requerimiento", "Empleado_Id_empleado", "dbo.Empleado");
            DropIndex("dbo.Requerimiento", new[] { "Empleado_Id_empleado" });
            DropColumn("dbo.Requerimiento", "Empleado_Id_empleado");
        }
    }
}
