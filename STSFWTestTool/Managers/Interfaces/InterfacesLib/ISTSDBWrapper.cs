
using CommonLib;
using System;
using System.Collections.Generic;

namespace InterfacesLib
{
    public interface ISTSDBWrapper
    {
        bool IsLoaded
        {
            get;
        }

        List<DoctorCard> AllDoctorCard
        {
            get;
        }

        List<Patient> AllPatients
        {
            get;
        }

        List<PatientVisit> AllVisits
        {
            get;
        }

        event Action<bool> DatabaseLoadDone;

        bool Load();

        //DoctorLevel IsPremiumClassDoctor(DoctorCard doctor);

        void SetStringPathHelp(string help);
        bool UpdateDoctorCard(DoctorCard doctor, string oldUserName);

        bool AddDoctorCard(DoctorCard doctor);

        bool DeleteDoctor(DoctorCard doctor);

        DoctorCard GetDoctor(string name, string password);

        bool UpdatePatient(Patient patient, string oldPatientName);

        string AddPatient(Patient patient);

        bool DeletePatient(Patient patient);

        Patient GetPatient(string patientId);

        bool UpdateVisit(PatientVisit visit);

        bool AddVisit(PatientVisit visit);

        bool DeleteVisit(PatientVisit visit);

        PatientVisit FindPatientVisit(string saveFilePath);

        bool DeleteVisit(string saveFilePath);
    }
}
