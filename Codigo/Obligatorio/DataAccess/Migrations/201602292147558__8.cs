namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Especialidads", "Doctor_DoctorID", c => c.Int());
            CreateIndex("dbo.Especialidads", "Doctor_DoctorID");
            AddForeignKey("dbo.Especialidads", "Doctor_DoctorID", "dbo.Doctors", "DoctorID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Especialidads", "Doctor_DoctorID", "dbo.Doctors");
            DropIndex("dbo.Especialidads", new[] { "Doctor_DoctorID" });
            DropColumn("dbo.Especialidads", "Doctor_DoctorID");
        }
    }
}
