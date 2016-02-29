namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Doctors", "UsuarioID");
            DropColumn("dbo.Pacientes", "UsuarioID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pacientes", "UsuarioID", c => c.Int(nullable: false));
            AddColumn("dbo.Doctors", "UsuarioID", c => c.Int(nullable: false));
        }
    }
}
