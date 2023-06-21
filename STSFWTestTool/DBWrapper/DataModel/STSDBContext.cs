using CommonLib;
using DBWrapper.Migrations;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace DBWrapper.DataModel
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class STSDBContext : DbContext
    {
        // Your context has been configured to use a 'STSDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DBWrapper.DataModel.BelkinDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'STSDBContext' 
        // connection string in the application configuration file.
        public STSDBContext()
            : base("name=Technoplumsts")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<STSDBContext, Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        //public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<DoctorCardDB> Doctors { get; set; }

        public virtual DbSet<PatientDB> Patients { get; set; }

        public virtual DbSet<PatientVisitDB> Visits { get; set; }

    }

    /*public class MyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }*/
}
