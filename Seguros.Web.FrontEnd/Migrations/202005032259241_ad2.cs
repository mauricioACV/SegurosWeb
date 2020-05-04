namespace Seguros.Web.FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ad2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cliente", "Operacion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cliente", "Operacion", c => c.String());
        }
    }
}
