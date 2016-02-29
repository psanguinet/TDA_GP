namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserRoles", newName: "RoleUsers");
            DropPrimaryKey("dbo.RoleUsers");
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Cedula = c.String(nullable: false),
                        Foto = c.Binary(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        ValorConsulta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EsDirector = c.Boolean(nullable: false),
                        SueldoMinimo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Activo = c.Boolean(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        Agenda_AgendaID = c.Int(),
                        Usuario_UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.DoctorID)
                .ForeignKey("dbo.Agenda", t => t.Agenda_AgendaID)
                .ForeignKey("dbo.Users", t => t.Usuario_UserId)
                .Index(t => t.Agenda_AgendaID)
                .Index(t => t.Usuario_UserId);
            
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        AgendaID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        Paciente_PacienteID = c.Int(),
                    })
                .PrimaryKey(t => t.AgendaID)
                .ForeignKey("dbo.Pacientes", t => t.Paciente_PacienteID)
                .Index(t => t.Paciente_PacienteID);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        PacienteID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Cedula = c.String(nullable: false),
                        Foto = c.Binary(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Altura = c.Int(nullable: false),
                        GrupoSanguineo = c.String(),
                        Peso = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        HistoriaMedica_HistoriaMedicaID = c.Int(),
                        Usuario_UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.PacienteID)
                .ForeignKey("dbo.HistoriaMedicas", t => t.HistoriaMedica_HistoriaMedicaID)
                .ForeignKey("dbo.Users", t => t.Usuario_UserId)
                .Index(t => t.HistoriaMedica_HistoriaMedicaID)
                .Index(t => t.Usuario_UserId);
            
            CreateTable(
                "dbo.HistoriaMedicas",
                c => new
                    {
                        HistoriaMedicaID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.HistoriaMedicaID);
            
            CreateTable(
                "dbo.AnalisisClinicoes",
                c => new
                    {
                        AnalisisClinicoID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Detalle = c.String(),
                        Doctor_DoctorID = c.Int(),
                        Paciente_PacienteID = c.Int(),
                        HistoriaMedica_HistoriaMedicaID = c.Int(),
                    })
                .PrimaryKey(t => t.AnalisisClinicoID)
                .ForeignKey("dbo.Doctors", t => t.Doctor_DoctorID)
                .ForeignKey("dbo.Pacientes", t => t.Paciente_PacienteID)
                .ForeignKey("dbo.HistoriaMedicas", t => t.HistoriaMedica_HistoriaMedicaID)
                .Index(t => t.Doctor_DoctorID)
                .Index(t => t.Paciente_PacienteID)
                .Index(t => t.HistoriaMedica_HistoriaMedicaID);
            
            CreateTable(
                "dbo.ResultadoAnalisis",
                c => new
                    {
                        ResultadoAnalisisID = c.Int(nullable: false, identity: true),
                        Nobmre = c.String(nullable: false),
                        Resultado = c.String(nullable: false),
                        AnalisisClinico_AnalisisClinicoID = c.Int(),
                    })
                .PrimaryKey(t => t.ResultadoAnalisisID)
                .ForeignKey("dbo.AnalisisClinicoes", t => t.AnalisisClinico_AnalisisClinicoID)
                .Index(t => t.AnalisisClinico_AnalisisClinicoID);
            
            CreateTable(
                "dbo.InformesDeConsultas",
                c => new
                    {
                        InformesDeConsultaID = c.Int(nullable: false, identity: true),
                        Motivo = c.String(nullable: false),
                        Detalle = c.String(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Doctor_DoctorID = c.Int(),
                        Paciente_PacienteID = c.Int(),
                        HistoriaMedica_HistoriaMedicaID = c.Int(),
                    })
                .PrimaryKey(t => t.InformesDeConsultaID)
                .ForeignKey("dbo.Doctors", t => t.Doctor_DoctorID)
                .ForeignKey("dbo.Pacientes", t => t.Paciente_PacienteID)
                .ForeignKey("dbo.HistoriaMedicas", t => t.HistoriaMedica_HistoriaMedicaID)
                .Index(t => t.Doctor_DoctorID)
                .Index(t => t.Paciente_PacienteID)
                .Index(t => t.HistoriaMedica_HistoriaMedicaID);
            
            AddPrimaryKey("dbo.RoleUsers", new[] { "Role_RoleId", "User_UserId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "Usuario_UserId", "dbo.Users");
            DropForeignKey("dbo.Doctors", "Agenda_AgendaID", "dbo.Agenda");
            DropForeignKey("dbo.Agenda", "Paciente_PacienteID", "dbo.Pacientes");
            DropForeignKey("dbo.Pacientes", "Usuario_UserId", "dbo.Users");
            DropForeignKey("dbo.Pacientes", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas");
            DropForeignKey("dbo.InformesDeConsultas", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas");
            DropForeignKey("dbo.InformesDeConsultas", "Paciente_PacienteID", "dbo.Pacientes");
            DropForeignKey("dbo.InformesDeConsultas", "Doctor_DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.AnalisisClinicoes", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas");
            DropForeignKey("dbo.AnalisisClinicoes", "Paciente_PacienteID", "dbo.Pacientes");
            DropForeignKey("dbo.ResultadoAnalisis", "AnalisisClinico_AnalisisClinicoID", "dbo.AnalisisClinicoes");
            DropForeignKey("dbo.AnalisisClinicoes", "Doctor_DoctorID", "dbo.Doctors");
            DropIndex("dbo.InformesDeConsultas", new[] { "HistoriaMedica_HistoriaMedicaID" });
            DropIndex("dbo.InformesDeConsultas", new[] { "Paciente_PacienteID" });
            DropIndex("dbo.InformesDeConsultas", new[] { "Doctor_DoctorID" });
            DropIndex("dbo.ResultadoAnalisis", new[] { "AnalisisClinico_AnalisisClinicoID" });
            DropIndex("dbo.AnalisisClinicoes", new[] { "HistoriaMedica_HistoriaMedicaID" });
            DropIndex("dbo.AnalisisClinicoes", new[] { "Paciente_PacienteID" });
            DropIndex("dbo.AnalisisClinicoes", new[] { "Doctor_DoctorID" });
            DropIndex("dbo.Pacientes", new[] { "Usuario_UserId" });
            DropIndex("dbo.Pacientes", new[] { "HistoriaMedica_HistoriaMedicaID" });
            DropIndex("dbo.Agenda", new[] { "Paciente_PacienteID" });
            DropIndex("dbo.Doctors", new[] { "Usuario_UserId" });
            DropIndex("dbo.Doctors", new[] { "Agenda_AgendaID" });
            DropPrimaryKey("dbo.RoleUsers");
            DropTable("dbo.InformesDeConsultas");
            DropTable("dbo.ResultadoAnalisis");
            DropTable("dbo.AnalisisClinicoes");
            DropTable("dbo.HistoriaMedicas");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Agenda");
            DropTable("dbo.Doctors");
            AddPrimaryKey("dbo.RoleUsers", new[] { "User_UserId", "Role_RoleId" });
            RenameTable(name: "dbo.RoleUsers", newName: "UserRoles");
        }
    }
}
