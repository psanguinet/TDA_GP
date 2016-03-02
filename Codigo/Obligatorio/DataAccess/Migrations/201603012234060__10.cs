namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pacientes", "Cedula", c => c.String(nullable: false, maxLength: 9));
            AlterColumn("dbo.Pacientes", "Telefono", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pacientes", "Telefono", c => c.String());
            AlterColumn("dbo.Pacientes", "Cedula", c => c.String(nullable: false));
        }
    }
}
