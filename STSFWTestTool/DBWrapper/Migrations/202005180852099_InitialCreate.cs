namespace DBWrapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorCardDBs",
                c => new
                {
                    UserName = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    FullName = c.String(unicode: false),
                    CreationDate = c.DateTime(nullable: false, precision: 0),
                    Password = c.String(unicode: false),
                    SettingsPassword = c.String(unicode: false),
                    MoreDetails = c.String(unicode: false),
                    PhotoFile = c.String(unicode: false),
                    SignatureFile = c.String(unicode: false),
                    Level = c.Int(nullable: false),
                    Site = c.String(unicode: false),
                })
                .PrimaryKey(t => t.UserName);

            CreateTable(
                "dbo.PatientDBs",
                c => new
                {
                    PatientId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    FirstName = c.String(unicode: false),
                    LastName = c.String(unicode: false),
                    MoreDetails = c.String(unicode: false),
                })
                .PrimaryKey(t => t.PatientId);

            CreateTable(
                "dbo.PatientVisitDBs",
                c => new
                {
                    VisitDateTime = c.DateTime(nullable: false, precision: 0),
                    UserName = c.String(maxLength: 128, storeType: "nvarchar"),
                    PatientId = c.String(maxLength: 128, storeType: "nvarchar"),
                    NumberOfPoints = c.Int(nullable: false),
                    RealNumberOfPoints = c.Int(nullable: false),
                    PulseEnergy = c.Single(nullable: false),
                    RealPulseEnergy = c.Single(nullable: false),
                    TotalPulseEnergy = c.Single(nullable: false),
                    PulseEnergyUnits = c.String(unicode: false),
                    TreatmentSummary = c.String(unicode: false),
                    Eye = c.Int(nullable: false),
                    CurrentTreatmentMode = c.Int(nullable: false),
                    CurrentReportType = c.Int(nullable: false),
                    CurrentApplicationProcessMode = c.Int(nullable: false),
                })

                .PrimaryKey(t => t.VisitDateTime);
                /*.ForeignKey("dbo.DoctorCardDBs", t => t.UserName)
                .ForeignKey("dbo.PatientDBs", t => t.PatientId)
                .Index(t => t.UserName)
                .Index(t => t.PatientId);*/

        }

        public override void Down()
        {
            DropForeignKey("dbo.PatientVisitDBs", "PatientId", "dbo.PatientDBs");
            DropForeignKey("dbo.PatientVisitDBs", "UserName", "dbo.DoctorCardDBs");
            DropIndex("dbo.PatientVisitDBs", new[] { "PatientId" });
            DropIndex("dbo.PatientVisitDBs", new[] { "UserName" });
            DropTable("dbo.PatientVisitDBs");
            DropTable("dbo.PatientDBs");
            DropTable("dbo.DoctorCardDBs");
        }
    }
}
