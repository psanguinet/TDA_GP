using Modelo.Models;
using System.Data.Entity;



namespace DataAccess.Model
{
    public class Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<WebApp.DataAccess.Model.Context>());

        public Context() : base("name=Context")
        {
        //    Database.SetInitializer<Context>(new DBInitializer());
            //Configuration.AutoDetectChangesEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
<<<<<<< HEAD
            //Configuration.ValidateOnSaveEnabled = true;+
=======
            //Configuration.ValidateOnSaveEnabled = true;
            //Configuration.ProxyCreationEnabled = false;
>>>>>>> 4a4911bbd63e7ed1f28d8a48f45b5a23778b3136
        }

     
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<AnalisisClinico> AnalisisClinicos { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<HistoriaMedica> HistoriasMedicas { get; set; }
        public DbSet<InformesDeConsulta> InformesDeConsultas { get; set; }
        public DbSet<LiquidacionDeSueldo> LiquidacionesDeSueldos { get; set; }
        public DbSet<ResultadoAnalisis> ResultadosAnalisis { get; set; }
    }
}
