namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Especialidads", "Doctor_DoctorID", "dbo.Doctors");
            DropIndex("dbo.Especialidads", new[] { "Doctor_DoctorID" });
            CreateTable(
                "dbo.EspecialidadDoctors",
                c => new
                    {
                        Especialidad_EspecilidadID = c.Int(nullable: false),
                        Doctor_DoctorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Especialidad_EspecilidadID, t.Doctor_DoctorID })
                .ForeignKey("dbo.Especialidads", t => t.Especialidad_EspecilidadID, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.Doctor_DoctorID, cascadeDelete: true)
                .Index(t => t.Especialidad_EspecilidadID)
                .Index(t => t.Doctor_DoctorID);
            
            DropColumn("dbo.Especialidads", "Doctor_DoctorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Especialidads", "Doctor_DoctorID", c => c.Int());
            DropForeignKey("dbo.EspecialidadDoctors", "Doctor_DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.EspecialidadDoctors", "Especialidad_EspecilidadID", "dbo.Especialidads");
            DropIndex("dbo.EspecialidadDoctors", new[] { "Doctor_DoctorID" });
            DropIndex("dbo.EspecialidadDoctors", new[] { "Especialidad_EspecilidadID" });
            DropTable("dbo.EspecialidadDoctors");
            CreateIndex("dbo.Especialidads", "Doctor_DoctorID");
            AddForeignKey("dbo.Especialidads", "Doctor_DoctorID", "dbo.Doctors", "DoctorID");
        }
    }
}
