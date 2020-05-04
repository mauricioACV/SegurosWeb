namespace Seguros.Web.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregaRelacionRequerimientoAClietne1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Requerimiento", new[] { "cliente_Id_cliente" });
            CreateIndex("dbo.Requerimiento", "Cliente_Id_cliente");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Requerimiento", new[] { "Cliente_Id_cliente" });
            CreateIndex("dbo.Requerimiento", "cliente_Id_cliente");
        }
    }
}
