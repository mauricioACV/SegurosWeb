namespace Seguros.Web.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregaRelacionRequerimientoAClietne3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Requerimiento", new[] { "cliente_Id_cliente" });
            DropIndex("dbo.Requerimiento", new[] { "estado_Id" });
            CreateIndex("dbo.Requerimiento", "Cliente_Id_cliente");
            CreateIndex("dbo.Requerimiento", "Estado_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Requerimiento", new[] { "Estado_Id" });
            DropIndex("dbo.Requerimiento", new[] { "Cliente_Id_cliente" });
            CreateIndex("dbo.Requerimiento", "estado_Id");
            CreateIndex("dbo.Requerimiento", "cliente_Id_cliente");
        }
    }
}
