namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agenda", "Hora", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agenda", "Hora");
        }
    }
}
