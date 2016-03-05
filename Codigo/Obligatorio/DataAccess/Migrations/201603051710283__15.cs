namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agenda", "Doctor_DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Agenda", "Paciente_PacienteID", "dbo.Pacientes");
            DropIndex("dbo.Agenda", new[] { "Doctor_DoctorID" });
            DropIndex("dbo.Agenda", new[] { "Paciente_PacienteID" });
            AlterColumn("dbo.Agenda", "Doctor_DoctorID", c => c.Int(nullable: false));
            AlterColumn("dbo.Agenda", "Paciente_PacienteID", c => c.Int(nullable: false));
            CreateIndex("dbo.Agenda", "Doctor_DoctorID");
            CreateIndex("dbo.Agenda", "Paciente_PacienteID");
            AddForeignKey("dbo.Agenda", "Doctor_DoctorID", "dbo.Doctors", "DoctorID", cascadeDelete: true);
            AddForeignKey("dbo.Agenda", "Paciente_PacienteID", "dbo.Pacientes", "PacienteID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agenda", "Paciente_PacienteID", "dbo.Pacientes");
            DropForeignKey("dbo.Agenda", "Doctor_DoctorID", "dbo.Doctors");
            DropIndex("dbo.Agenda", new[] { "Paciente_PacienteID" });
            DropIndex("dbo.Agenda", new[] { "Doctor_DoctorID" });
            AlterColumn("dbo.Agenda", "Paciente_PacienteID", c => c.Int());
            AlterColumn("dbo.Agenda", "Doctor_DoctorID", c => c.Int());
            CreateIndex("dbo.Agenda", "Paciente_PacienteID");
            CreateIndex("dbo.Agenda", "Doctor_DoctorID");
            AddForeignKey("dbo.Agenda", "Paciente_PacienteID", "dbo.Pacientes", "PacienteID");
            AddForeignKey("dbo.Agenda", "Doctor_DoctorID", "dbo.Doctors", "DoctorID");
        }
    }
}
