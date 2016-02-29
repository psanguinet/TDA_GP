namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RoleUsers", newName: "UserRoles");
            DropForeignKey("dbo.Personas", "Usuario_UserId", "dbo.Users");
            DropForeignKey("dbo.AnalisisClinicoes", "Doctor_PersonaID", "dbo.Personas");
            DropForeignKey("dbo.ResultadoAnalisis", "AnalisisClinico_AnalisisClinicoID", "dbo.AnalisisClinicoes");
            DropForeignKey("dbo.AnalisisClinicoes", "Paciente_PersonaID", "dbo.Personas");
            DropForeignKey("dbo.AnalisisClinicoes", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas");
            DropForeignKey("dbo.InformesDeConsultas", "Doctor_PersonaID", "dbo.Personas");
            DropForeignKey("dbo.InformesDeConsultas", "Paciente_PersonaID", "dbo.Personas");
            DropForeignKey("dbo.InformesDeConsultas", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas");
            DropForeignKey("dbo.Personas", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas");
            DropForeignKey("dbo.Agenda", "Paciente_PersonaID", "dbo.Personas");
            DropForeignKey("dbo.Personas", "Agenda_AgendaID", "dbo.Agenda");
            DropIndex("dbo.Personas", new[] { "Usuario_UserId" });
            DropIndex("dbo.Personas", new[] { "HistoriaMedica_HistoriaMedicaID" });
            DropIndex("dbo.Personas", new[] { "Agenda_AgendaID" });
            DropIndex("dbo.Agenda", new[] { "Paciente_PersonaID" });
            DropIndex("dbo.AnalisisClinicoes", new[] { "Doctor_PersonaID" });
            DropIndex("dbo.AnalisisClinicoes", new[] { "Paciente_PersonaID" });
            DropIndex("dbo.AnalisisClinicoes", new[] { "HistoriaMedica_HistoriaMedicaID" });
            DropIndex("dbo.ResultadoAnalisis", new[] { "AnalisisClinico_AnalisisClinicoID" });
            DropIndex("dbo.InformesDeConsultas", new[] { "Doctor_PersonaID" });
            DropIndex("dbo.InformesDeConsultas", new[] { "Paciente_PersonaID" });
            DropIndex("dbo.InformesDeConsultas", new[] { "HistoriaMedica_HistoriaMedicaID" });
            DropPrimaryKey("dbo.UserRoles");
            AddPrimaryKey("dbo.UserRoles", new[] { "User_UserId", "Role_RoleId" });
            DropTable("dbo.Personas");
            DropTable("dbo.Agenda");
            DropTable("dbo.HistoriaMedicas");
            DropTable("dbo.AnalisisClinicoes");
            DropTable("dbo.ResultadoAnalisis");
            DropTable("dbo.InformesDeConsultas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InformesDeConsultas",
                c => new
                    {
                        InformesDeConsultaID = c.Int(nullable: false, identity: true),
                        Motivo = c.String(nullable: false),
                        Detalle = c.String(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Doctor_PersonaID = c.Int(),
                        Paciente_PersonaID = c.Int(),
                        HistoriaMedica_HistoriaMedicaID = c.Int(),
                    })
                .PrimaryKey(t => t.InformesDeConsultaID);
            
            CreateTable(
                "dbo.ResultadoAnalisis",
                c => new
                    {
                        ResultadoAnalisisID = c.Int(nullable: false, identity: true),
                        Nobmre = c.String(nullable: false),
                        Resultado = c.String(nullable: false),
                        AnalisisClinico_AnalisisClinicoID = c.Int(),
                    })
                .PrimaryKey(t => t.ResultadoAnalisisID);
            
            CreateTable(
                "dbo.AnalisisClinicoes",
                c => new
                    {
                        AnalisisClinicoID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Detalle = c.String(),
                        Doctor_PersonaID = c.Int(),
                        Paciente_PersonaID = c.Int(),
                        HistoriaMedica_HistoriaMedicaID = c.Int(),
                    })
                .PrimaryKey(t => t.AnalisisClinicoID);
            
            CreateTable(
                "dbo.HistoriaMedicas",
                c => new
                    {
                        HistoriaMedicaID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.HistoriaMedicaID);
            
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        AgendaID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        Paciente_PersonaID = c.Int(),
                    })
                .PrimaryKey(t => t.AgendaID);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        PersonaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Cedula = c.String(nullable: false),
                        Foto = c.Binary(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        UsuarioID = c.Int(nullable: false),
                        ValorConsulta = c.Decimal(precision: 18, scale: 2),
                        EsDirector = c.Boolean(),
                        SueldoMinimo = c.Decimal(precision: 18, scale: 2),
                        Activo = c.Boolean(),
                        FechaNacimiento = c.DateTime(),
                        Altura = c.Int(),
                        GrupoSanguineo = c.String(),
                        Peso = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Usuario_UserId = c.Guid(),
                        HistoriaMedica_HistoriaMedicaID = c.Int(),
                        Agenda_AgendaID = c.Int(),
                    })
                .PrimaryKey(t => t.PersonaID);
            
            DropPrimaryKey("dbo.UserRoles");
            AddPrimaryKey("dbo.UserRoles", new[] { "Role_RoleId", "User_UserId" });
            CreateIndex("dbo.InformesDeConsultas", "HistoriaMedica_HistoriaMedicaID");
            CreateIndex("dbo.InformesDeConsultas", "Paciente_PersonaID");
            CreateIndex("dbo.InformesDeConsultas", "Doctor_PersonaID");
            CreateIndex("dbo.ResultadoAnalisis", "AnalisisClinico_AnalisisClinicoID");
            CreateIndex("dbo.AnalisisClinicoes", "HistoriaMedica_HistoriaMedicaID");
            CreateIndex("dbo.AnalisisClinicoes", "Paciente_PersonaID");
            CreateIndex("dbo.AnalisisClinicoes", "Doctor_PersonaID");
            CreateIndex("dbo.Agenda", "Paciente_PersonaID");
            CreateIndex("dbo.Personas", "Agenda_AgendaID");
            CreateIndex("dbo.Personas", "HistoriaMedica_HistoriaMedicaID");
            CreateIndex("dbo.Personas", "Usuario_UserId");
            AddForeignKey("dbo.Personas", "Agenda_AgendaID", "dbo.Agenda", "AgendaID");
            AddForeignKey("dbo.Agenda", "Paciente_PersonaID", "dbo.Personas", "PersonaID");
            AddForeignKey("dbo.Personas", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas", "HistoriaMedicaID");
            AddForeignKey("dbo.InformesDeConsultas", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas", "HistoriaMedicaID");
            AddForeignKey("dbo.InformesDeConsultas", "Paciente_PersonaID", "dbo.Personas", "PersonaID");
            AddForeignKey("dbo.InformesDeConsultas", "Doctor_PersonaID", "dbo.Personas", "PersonaID");
            AddForeignKey("dbo.AnalisisClinicoes", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas", "HistoriaMedicaID");
            AddForeignKey("dbo.AnalisisClinicoes", "Paciente_PersonaID", "dbo.Personas", "PersonaID");
            AddForeignKey("dbo.ResultadoAnalisis", "AnalisisClinico_AnalisisClinicoID", "dbo.AnalisisClinicoes", "AnalisisClinicoID");
            AddForeignKey("dbo.AnalisisClinicoes", "Doctor_PersonaID", "dbo.Personas", "PersonaID");
            AddForeignKey("dbo.Personas", "Usuario_UserId", "dbo.Users", "UserId");
            RenameTable(name: "dbo.UserRoles", newName: "RoleUsers");
        }
    }
}
