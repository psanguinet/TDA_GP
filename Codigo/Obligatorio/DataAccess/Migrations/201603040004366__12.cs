namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "Agenda_AgendaID", "dbo.Agenda");
            DropIndex("dbo.Doctors", new[] { "Agenda_AgendaID" });
            AddColumn("dbo.Agenda", "Doctor_DoctorID", c => c.Int());
            CreateIndex("dbo.Agenda", "Doctor_DoctorID");
            AddForeignKey("dbo.Agenda", "Doctor_DoctorID", "dbo.Doctors", "DoctorID");
            DropColumn("dbo.Doctors", "Agenda_AgendaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Agenda_AgendaID", c => c.Int());
            DropForeignKey("dbo.Agenda", "Doctor_DoctorID", "dbo.Doctors");
            DropIndex("dbo.Agenda", new[] { "Doctor_DoctorID" });
            DropColumn("dbo.Agenda", "Doctor_DoctorID");
            CreateIndex("dbo.Doctors", "Agenda_AgendaID");
            AddForeignKey("dbo.Doctors", "Agenda_AgendaID", "dbo.Agenda", "AgendaID");
        }
    }
}
