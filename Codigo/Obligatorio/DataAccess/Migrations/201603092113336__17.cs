namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnalisisClinicoes", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas");
            DropForeignKey("dbo.InformesDeConsultas", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas");
            DropForeignKey("dbo.Pacientes", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas");
            DropIndex("dbo.AnalisisClinicoes", new[] { "HistoriaMedica_HistoriaMedicaID" });
            DropIndex("dbo.InformesDeConsultas", new[] { "HistoriaMedica_HistoriaMedicaID" });
            DropIndex("dbo.Pacientes", new[] { "HistoriaMedica_HistoriaMedicaID" });
            DropColumn("dbo.Pacientes", "HistoriaMedica_HistoriaMedicaID");
            DropColumn("dbo.AnalisisClinicoes", "HistoriaMedica_HistoriaMedicaID");
            DropColumn("dbo.InformesDeConsultas", "HistoriaMedica_HistoriaMedicaID");
            DropTable("dbo.HistoriaMedicas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HistoriaMedicas",
                c => new
                    {
                        HistoriaMedicaID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.HistoriaMedicaID);
            
            AddColumn("dbo.InformesDeConsultas", "HistoriaMedica_HistoriaMedicaID", c => c.Int());
            AddColumn("dbo.AnalisisClinicoes", "HistoriaMedica_HistoriaMedicaID", c => c.Int());
            AddColumn("dbo.Pacientes", "HistoriaMedica_HistoriaMedicaID", c => c.Int());
            CreateIndex("dbo.Pacientes", "HistoriaMedica_HistoriaMedicaID");
            CreateIndex("dbo.InformesDeConsultas", "HistoriaMedica_HistoriaMedicaID");
            CreateIndex("dbo.AnalisisClinicoes", "HistoriaMedica_HistoriaMedicaID");
            AddForeignKey("dbo.Pacientes", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas", "HistoriaMedicaID");
            AddForeignKey("dbo.InformesDeConsultas", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas", "HistoriaMedicaID");
            AddForeignKey("dbo.AnalisisClinicoes", "HistoriaMedica_HistoriaMedicaID", "dbo.HistoriaMedicas", "HistoriaMedicaID");
        }
    }
}
