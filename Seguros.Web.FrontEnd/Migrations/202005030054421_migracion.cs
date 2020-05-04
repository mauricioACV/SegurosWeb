namespace Seguros.Web.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleado", "Rol_Id", c => c.Int());
            CreateIndex("dbo.Empleado", "Rol_Id");
            AddForeignKey("dbo.Empleado", "Rol_Id", "dbo.Rol", "Id");
            DropColumn("dbo.Empleado", "Rol");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empleado", "Rol", c => c.Int(nullable: false));
            DropForeignKey("dbo.Empleado", "Rol_Id", "dbo.Rol");
            DropIndex("dbo.Empleado", new[] { "Rol_Id" });
            DropColumn("dbo.Empleado", "Rol_Id");
        }
    }
}
