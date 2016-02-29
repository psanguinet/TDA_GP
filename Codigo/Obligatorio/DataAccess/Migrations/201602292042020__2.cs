namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        AgendaID = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        Paciente_PersonaID = c.Int(),
                    })
                .PrimaryKey(t => t.AgendaID)
                .ForeignKey("dbo.Personas", t => t.Paciente_PersonaID)
                .Index(t => t.Paciente_PersonaID);
            
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
                        Doctor_PersonaID = c.Int(),
                        Paciente_PersonaID = c.Int(),
                        HistoriaMedica_HistoriaMedicaID = c.Int(),
                    })
                .PrimaryKey(t => t.AnalisisClinicoID)
                .ForeignKey("dbo.Personas", t => t.Doctor_PersonaID)
                .ForeignKey("dbo.Personas", t => t.Paciente_PersonaID)
                .ForeignKey("dbo.HistoriaMedicas", t => t.HistoriaMedica_HistoriaMedicaID)
                .Index(t => t.Doctor_PersonaID)
                .Index(t => t.Paciente_PersonaID)
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
                        Doctor_PersonaID = c.Int(),
                        Paciente_PersonaID = c.Int(),
                        HistoriaMedica_HistoriaMedicaID = c.Int(),
                    })
                .PrimaryKey(t => t.InformesDeConsultaID)
                .ForeignKey("dbo.Personas", t => t.Doctor_PersonaID)
                .ForeignKey("dbo.Personas", t => t.Paciente_PersonaID)
                .ForeignKey("dbo.HistoriaMedicas", t => t.HistoriaMedica_HistoriaMedicaID)
                .Index(t => t.Doctor_PersonaID)
                .Index(t => t.Paciente_PersonaID)
                .Index(t => t.HistoriaMedica_HistoriaMedicaID);
            
            AddColumn("dbo.Personas", "ValorConsulta", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Personas", "EsDirector", c => c.Boolean());
            AddColumn("dbo.Personas", "SueldoMinimo", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Personas", "Activo", c => c.Boolean());
            AddColumn("dbo.Personas", "FechaNacimiento", c => c.DateTime());
            AddColumn("dbo.Personas", "Altura", c => c.Int());
            AddColumn("dbo.Personas", "GrupoSanguineo", c => c.String());
            AddColumn("dbo.Personas", "Peso", c => c.Int());
            AddColumn("dbo.Personas", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Personas", "HistoriaMedica_HistoriaMedicaID", c => c.Int());
            AddColumn("dbo.Personas", "Agenda_AgendaID", c => c.Int());
            AlterColumn("dbo.Personas", "Apellido", c => c.String(nullable: false));
            AlterColumn("dbo.Personas", "Cedula", c => c.String(nullable: false));
            CreateIndex("dbo.Personas", "HistoriaMedica_HistoriaMedicaID");
            CreateIndex("dbo.Personas", "Agenda_AgendaID");
            AddForeignKey("dbo.Personas", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas", "HistoriaMedicaID");
            AddForeignKey("dbo.Personas", "Agenda_AgendaID", "dbo.Agenda", "AgendaID");
            DropColumn("dbo.Personas", "Correo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personas", "Correo", c => c.String());
            DropForeignKey("dbo.Personas", "Agenda_AgendaID", "dbo.Agenda");
            DropForeignKey("dbo.Agenda", "Paciente_PersonaID", "dbo.Personas");
            DropForeignKey("dbo.Personas", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas");
            DropForeignKey("dbo.InformesDeConsultas", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas");
            DropForeignKey("dbo.InformesDeConsultas", "Paciente_PersonaID", "dbo.Personas");
            DropForeignKey("dbo.InformesDeConsultas", "Doctor_PersonaID", "dbo.Personas");
            DropForeignKey("dbo.AnalisisClinicoes", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas");
            DropForeignKey("dbo.AnalisisClinicoes", "Paciente_PersonaID", "dbo.Personas");
            DropForeignKey("dbo.ResultadoAnalisis", "AnalisisClinico_AnalisisClinicoID", "dbo.AnalisisClinicoes");
            DropForeignKey("dbo.AnalisisClinicoes", "Doctor_PersonaID", "dbo.Personas");
            DropIndex("dbo.InformesDeConsultas", new[] { "HistoriaMedica_HistoriaMedicaID" });
            DropIndex("dbo.InformesDeConsultas", new[] { "Paciente_PersonaID" });
            DropIndex("dbo.InformesDeConsultas", new[] { "Doctor_PersonaID" });
            DropIndex("dbo.ResultadoAnalisis", new[] { "AnalisisClinico_AnalisisClinicoID" });
            DropIndex("dbo.AnalisisClinicoes", new[] { "HistoriaMedica_HistoriaMedicaID" });
            DropIndex("dbo.AnalisisClinicoes", new[] { "Paciente_PersonaID" });
            DropIndex("dbo.AnalisisClinicoes", new[] { "Doctor_PersonaID" });
            DropIndex("dbo.Agenda", new[] { "Paciente_PersonaID" });
            DropIndex("dbo.Personas", new[] { "Agenda_AgendaID" });
            DropIndex("dbo.Personas", new[] { "HistoriaMedica_HistoriaMedicaID" });
            AlterColumn("dbo.Personas", "Cedula", c => c.String());
            AlterColumn("dbo.Personas", "Apellido", c => c.String());
            DropColumn("dbo.Personas", "Agenda_AgendaID");
            DropColumn("dbo.Personas", "HistoriaMedica_HistoriaMedicaID");
            DropColumn("dbo.Personas", "Discriminator");
            DropColumn("dbo.Personas", "Peso");
            DropColumn("dbo.Personas", "GrupoSanguineo");
            DropColumn("dbo.Personas", "Altura");
            DropColumn("dbo.Personas", "FechaNacimiento");
            DropColumn("dbo.Personas", "Activo");
            DropColumn("dbo.Personas", "SueldoMinimo");
            DropColumn("dbo.Personas", "EsDirector");
            DropColumn("dbo.Personas", "ValorConsulta");
            DropTable("dbo.InformesDeConsultas");
            DropTable("dbo.ResultadoAnalisis");
            DropTable("dbo.AnalisisClinicoes");
            DropTable("dbo.HistoriaMedicas");
            DropTable("dbo.Agenda");
        }
    }
}
