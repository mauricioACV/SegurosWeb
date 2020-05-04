namespace Seguros.Web.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ad : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cliente", "Rut_cliente", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cliente", "Rut_cliente", c => c.Int(nullable: false));
        }
    }
}
