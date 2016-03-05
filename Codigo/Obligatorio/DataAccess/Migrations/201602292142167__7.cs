namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Especialidads",
                c => new
                    {
                        EspecilidadID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EspecilidadID);
            
            CreateTable(
                "dbo.LiquidacionDeSueldoes",
                c => new
                    {
                        LiquidacionID = c.Int(nullable: false, identity: true),
                        FechaRealizacion = c.DateTime(nullable: false),
                        Mes = c.Int(nullable: false),
                        Anio = c.Int(nullable: false),
                        Importe = c.Int(nullable: false),
                        Doctor_DoctorID = c.Int(),
                    })
                .PrimaryKey(t => t.LiquidacionID)
                .ForeignKey("dbo.Doctors", t => t.Doctor_DoctorID)
                .Index(t => t.Doctor_DoctorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LiquidacionDeSueldoes", "Doctor_DoctorID", "dbo.Doctors");
            DropIndex("dbo.LiquidacionDeSueldoes", new[] { "Doctor_DoctorID" });
            DropTable("dbo.LiquidacionDeSueldoes");
            DropTable("dbo.Especialidads");
        }
    }
}
