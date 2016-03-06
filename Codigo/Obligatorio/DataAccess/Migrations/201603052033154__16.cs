namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Agenda", name: "Doctor_DoctorID", newName: "DoctorID");
            RenameColumn(table: "dbo.Agenda", name: "Paciente_PacienteID", newName: "PacienteID");
            RenameIndex(table: "dbo.Agenda", name: "IX_Paciente_PacienteID", newName: "IX_PacienteID");
            RenameIndex(table: "dbo.Agenda", name: "IX_Doctor_DoctorID", newName: "IX_DoctorID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Agenda", name: "IX_DoctorID", newName: "IX_Doctor_DoctorID");
            RenameIndex(table: "dbo.Agenda", name: "IX_PacienteID", newName: "IX_Paciente_PacienteID");
            RenameColumn(table: "dbo.Agenda", name: "PacienteID", newName: "Paciente_PacienteID");
            RenameColumn(table: "dbo.Agenda", name: "DoctorID", newName: "Doctor_DoctorID");
        }
    }
}
