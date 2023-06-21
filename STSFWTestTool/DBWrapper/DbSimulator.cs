using CommonLib;
using InterfacesLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Globals;

namespace DBWrapper
{
    public class DbSimulator : ISTSDBWrapper
    {
        static Config config = ConfigurationFileManager<Config>.Instance.GetData;

        private string userAdminName = "UserAdmin";
        private string userAdminPassword = "Admin1234";

        private string userDemoName = "Demo";
        private string userDemoPassword = "Demo1234";

        private string userTestName = "Test";
        private string userTestPassword = "Test1234";

        private string notAvailableName = "NA";
        private string notAvailablePassword = "NA1234";

        private static ISTSDBWrapper SimnulatDBWrapper = null;

        public event Action<bool> DatabaseLoadDone;
        public bool IsLoaded
        {
            private set
            {
                if (value != isLoaded)
                {
                    isLoaded = value;
                    DatabaseLoadDone?.Invoke(true);
                }
            }
            get
            {
                return isLoaded;
            }
        }
        private bool isLoaded = false;

        public static ISTSDBWrapper GetSimulatedDataBase
        {
            get
            {
                if (SimnulatDBWrapper == null)
                {
                    SimnulatDBWrapper = new DbSimulator();
                }

                return SimnulatDBWrapper;
            }
        }

        public List<DoctorCard> AllDoctorCard
        {
            get
            {
                try
                {
                    if (allDoctorCard == null)
                        InitAllDoctorCard();

                    return allDoctorCard;
                }
                catch (Exception ee)
                {
                    return null;
                }
            }
        }
        public List<DoctorCard> allDoctorCard = null;

        public List<Patient> AllPatients
        {
            get
            {
                try
                {
                    if (allPatients == null)
                        InitAllPatients();

                    return allPatients;
                }
                catch (Exception ee)
                {
                    return null;
                }
            }
        }
        public List<Patient> allPatients = null;

        public List<PatientVisit> AllVisits
        {
            get
            {
                try
                {
                    if (allVisits == null)
                        InitAllVisits();

                    return allVisits;
                }
                catch (Exception ee)
                {
                    return null;
                }
            }
        }
        private List<PatientVisit> allVisits = null;
        private string DoctorsDbFile = @"C:\STS\SimulatedDataBase/DoctorFile.xml";
        private string VisitsDbFile = @"C:\STS\SimulatedDataBase/VisitFile.xml";
        private string PatientsDbFile = @"C:\STS\SimulatedDataBase/PatientFile.xml";

        private string _startPath = "../../../../";
        public void SetStringPathHelp(string help)
        {
            _startPath = help;
        }

        public bool Load()
        {
            if (!config.IsLoadingDBFile)
            {
                InitAllDoctorCard();

                InitAllPatients();

                InitAllVisits();
            }

            if (allPatients == null)
                allPatients = new List<Patient>();
            if (allDoctorCard == null)
                allDoctorCard = new List<DoctorCard>();
            if (allVisits == null)
                allVisits = new List<PatientVisit>();

            //LoggerWrapper.Log(LogLevel.Info, "Load", LogFile.DB_Wrraper);
            LoggerWrapper.Log("Load");

            if (!Directory.Exists(@"C:\STS\SimulatedDataBase"))
                Directory.CreateDirectory(@"C:\STS\SimulatedDataBase");

            if (allVisits.Count == 0)
            {
                try
                {
                    var card = allDoctorCard.Find(x => x.UserName == userAdminName);
                    if (card == null)
                        allDoctorCard.Add(new DoctorCard() { UserName = userAdminName, Password = userAdminPassword, SettingsPassword = "517", FullName = "Admin", Site = "Tel Aviv" });
                    else
                        card.Password = userAdminPassword;

                    card = allDoctorCard.Find(x => x.UserName == userDemoName);
                    if (card == null)
                        allDoctorCard.Add(new DoctorCard() { UserName = userDemoName, Password = userDemoPassword, SettingsPassword = "517", FullName = "Demo", Site = "Demo land" });
                    else
                        card.Password = userDemoPassword;

                    card = allDoctorCard.Find(x => x.UserName == userTestName);
                    if (card == null)
                        allDoctorCard.Add(new DoctorCard() { UserName = userTestName, Password = userTestPassword, SettingsPassword = "517", FullName = "Test", Site = "Testy land" });
                    else
                        card.Password = userTestPassword;

                    card = allDoctorCard.Find(x => x.UserName == notAvailableName);
                    if (card == null)
                        allDoctorCard.Add(new DoctorCard() { UserName = notAvailableName, Password = notAvailablePassword, SettingsPassword = "517", FullName = "N/A", Site = "N/A" });
                    else
                        card.Password = notAvailablePassword;

                    card = allDoctorCard.Find(x => x.UserName == "a");
                    if (card == null)
                        allDoctorCard.Add(new DoctorCard() { UserName = "a", Password = "a", SettingsPassword = "517", FullName = "a", Site = "a" , DoctorLevel = Enum_Doctor_Level.Techniction});
                    else
                        card.Password = "a";

                    SaveDoctorsToFile();
                }
                catch (Exception ee)
                {
                    LoggerWrapper.LogException(ee);

                    return false;
                }
            }

            if (config.IsLoadingDBFile)
                LoadFromFile(config.DBFilePath);
            else if (allPatients == null || allPatients.Count == 0)
                SimulateDataBase();

            InitLastDoctor();

            IsLoaded = true;
            return true;
        }

        public void SimulateDataBase()
        {
            return; 

            Debug.WriteLine("Simulate Data Base: DbSimulator");

            Patient[] p = new Patient[10];
            for (int i = 0; i < p.Length; i++)
                p[i] = new Patient() { UnitSystem = Enum_Unit_System.Metric };

            p[0].FullName = "Brooklyn Smith"; p[0].PatientId = "1"; p[0].Height = 150; p[0].Weight = 54; p[0].Gender = Enum_Gender.Female; p[0].Ethnicity = ENUM_Ethnicity.Caucasian; p[0].PhoneNumber = "0565781359"; p[0].PatientAdress = "Herzl 43, Tel Aviv-Yafo"; p[0].BirthDate = DateTime.Parse("2000-02-15 09:39:32"); p[0].Medication = Enum_Medication.None; p[0].MedicationDescription = ""; p[0].Smoking = Enum_Smoking.Yes; p[0].SmokingDescription = "";
            p[1].FullName = "Kathryn Magenta"; p[1].PatientId = "12"; p[1].Height = 165; p[1].Weight = 61.4; p[1].Gender = Enum_Gender.Female; p[1].Ethnicity = ENUM_Ethnicity.Caucasian; p[1].PhoneNumber = "+972598631459"; p[1].PatientAdress = "Herzl 23, Rehovot"; p[1].BirthDate = DateTime.Parse("1948-05-02 09:39:32"); p[1].Medication = Enum_Medication.Yes; p[1].MedicationDescription = "Recontextualize"; p[1].Smoking = Enum_Smoking.Not; p[1].SmokingDescription = "";
            p[2].FullName = "Bessie Levi"; p[2].PatientId = "121"; p[2].Height = 153; p[2].Weight = 57.3; p[2].Gender = Enum_Gender.Female; p[2].Ethnicity = ENUM_Ethnicity.Caucasian; p[2].PhoneNumber = "048796219"; p[2].PatientAdress = "Herzl 99, Tel Aviv-Yafo"; p[2].BirthDate = DateTime.Parse("1976-12-29 09:39:32"); p[2].Medication = Enum_Medication.None; p[2].MedicationDescription = ""; p[2].Smoking = Enum_Smoking.Quit; p[2].SmokingDescription = "2 years ago";
            p[3].FullName = "Eleanor Peleg"; p[3].PatientId = "123"; p[3].Height = 170; p[3].Weight = 60.1; p[3].Gender = Enum_Gender.Female; p[3].Ethnicity = ENUM_Ethnicity.African_American; p[3].PhoneNumber = "0554231579"; p[3].PatientAdress = "Herzl 16, Hifa"; p[3].BirthDate = DateTime.Parse("1994-10-17 09:39:32"); p[3].Medication = Enum_Medication.Yes; p[3].MedicationDescription = "Recontextualize"; p[3].Smoking = Enum_Smoking.Quit; p[3].SmokingDescription = "1 year ago";
            p[4].FullName = "Darlene Schwartz"; p[4].PatientId = "1234"; p[4].Height = 173; p[4].Weight = 65.2; p[4].Gender = Enum_Gender.Female; p[4].Ethnicity = ENUM_Ethnicity.Asian; p[4].PhoneNumber = "086458739"; p[4].PatientAdress = "Herzl 26, Tel Aviv-Yafo"; p[4].BirthDate = DateTime.Parse("1458-09-01 09:39:32"); p[4].Medication = Enum_Medication.Yes; p[4].MedicationDescription = "Recontextualize"; p[4].Smoking = Enum_Smoking.Yes; p[4].SmokingDescription = "";
            p[5].FullName = "Jacob Jenny"; p[5].PatientId = "12345"; p[5].Height = 179; p[5].Weight = 66.7; p[5].Gender = Enum_Gender.Male; p[5].Ethnicity = ENUM_Ethnicity.African_American; p[5].PhoneNumber = "048796549"; p[5].PatientAdress = "Herzl 69, Rehovot"; p[5].BirthDate = DateTime.Parse("2017-01-30 09:39:32"); p[5].Medication = Enum_Medication.None; p[5].MedicationDescription = ""; p[5].Smoking = Enum_Smoking.Not; p[5].SmokingDescription = "";
            p[6].FullName = "Courtney Hou"; p[6].PatientId = "123456"; p[6].Height = 169; p[6].Weight = 64.5; p[6].Gender = Enum_Gender.Female; p[6].Ethnicity = ENUM_Ethnicity.Asian; p[6].PhoneNumber = "+972578965439"; p[6].PatientAdress = "Herzl 3, Hifa"; p[6].BirthDate = DateTime.Parse("2020-03-11 09:39:32"); p[6].Medication = Enum_Medication.Yes; p[6].MedicationDescription = "Recontextualize"; p[6].Smoking = Enum_Smoking.Quit; p[6].SmokingDescription = "3 monthes ago";
            p[7].FullName = "Jerome Baby"; p[7].PatientId = "1234567"; p[7].Height = 183; p[7].Weight = 83.7; p[7].Gender = Enum_Gender.Male; p[7].Ethnicity = ENUM_Ethnicity.Caucasian; p[7].PhoneNumber = "0577777779"; p[7].PatientAdress = "Herzl 32, Hifa"; p[7].BirthDate = DateTime.Parse("1990-06-24 09:39:32"); p[7].Medication = Enum_Medication.None; p[7].MedicationDescription = ""; p[7].Smoking = Enum_Smoking.Yes; p[7].SmokingDescription = "";
            p[8].FullName = "Ronald Choen"; p[8].PatientId = "12345678"; p[8].Height = 192; p[8].Weight = 89.2; p[8].Gender = Enum_Gender.Male; p[8].Ethnicity = ENUM_Ethnicity.African_American; p[8].PhoneNumber = "036666669"; p[8].PatientAdress = "Herzl 13, Tel Aviv-Yafo"; p[8].BirthDate = DateTime.Parse("2000-12-25 09:39:32"); p[8].Medication = Enum_Medication.None; p[8].MedicationDescription = ""; p[8].Smoking = Enum_Smoking.Not; p[8].SmokingDescription = "";
            p[9].FullName = "Esther Hekler"; p[9].PatientId = "123456789"; p[9].Height = 171; p[9].Weight = 93.6; p[9].Gender = Enum_Gender.Female; p[9].Ethnicity = ENUM_Ethnicity.Asian; p[9].PhoneNumber = "+972578787879"; p[9].PatientAdress = "Herzl 999, Rehovot"; p[9].BirthDate = DateTime.Parse("2008-10-08 09:39:32"); p[9].Medication = Enum_Medication.Yes; p[9].MedicationDescription = "Recontextualize"; p[9].Smoking = Enum_Smoking.Quit; p[9].SmokingDescription = "5 years ago";

            for (int i = 0; i < p.Length; i++)
            {
                if (p[i].Gender.Equals(Enum_Gender.Female))
                    p[i].PatientPicture = PictureHelper.getFemalePicture();
                else
                    p[i].PatientPicture = PictureHelper.GetDefaultPicture();
            }

            PatientVisit[] pv = new PatientVisit[50];
            for (int i = 0; i < pv.Length; i++)
                pv[i] = new PatientVisit() { UnitSystem = Enum_Unit_System.Metric };

            double[] pre = { 4.38, 3.6, 4.1, 6.0, 5.2, 5.6, 2.26, 8.4, 6.58, 9.2, 9.2, 1.9, 13.44, 5.6, 2.26, 8.4, 4.44, 2.22, 0.66, 0.77, 0.32, 1.07 };
            PUATestHelper prediction = new PUATestHelper(pre);

            double[] test = { 5.6, 3.6, 5.2, 5.1, 7.0, 1.3, 8.9, 6.3, 7.7, 9.8, 3.5, 3.5, 9.7, 1.3, 6.3, 8.9, 6.66, 5.55, 0.66, 0.77, 0.32, 1.07 };
            PUATestHelper p0 = new PUATestHelper(test);
            PUATestHelper p1 = new PUATestHelper(test);
            PUATestHelper p2 = new PUATestHelper(test);
            PUATestHelper p3 = new PUATestHelper(test);
            PUATestHelper p4 = new PUATestHelper(test);
            PUATestHelper p5 = new PUATestHelper(test);
            PUATestHelper p6 = new PUATestHelper(test);
            PUATestHelper p7 = new PUATestHelper(test);
            PUATestHelper p8 = new PUATestHelper(test);
            PUATestHelper p9 = new PUATestHelper(test);
            //double[] rawData = readFile(@"C:\EfCom\Technoplumsts\SVN\trunk\pySolution\rec.csv");
            p0.RawData = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            p1.RawData = new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            p2.RawData = new double[] { 0, -1, -2, -3, -4, -5, -6, -7, -8, -9, -8, -7, -6, -5, -4, -3, -2, -1 };
            p3.RawData = new double[] { 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            p4.RawData = new double[] { 2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2 };
            p5.RawData = new double[] { 3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3 };
            p6.RawData = new double[] { 4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4, -4 };
            p7.RawData = new double[] { 5, -5, -5, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
            p8.RawData = new double[] { 5, -5, -5, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
            p9.RawData = new double[] { 7, -7, -7, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };

            PUATestResult test0 = new PUATestResult();
            PUATestResult test1 = new PUATestResult();

            test0.AllTests.Add(p0);
            test0.AllTests.Add(p1);
            test0.AllTests.Add(p2);
            test0.AllTests.Add(p3);
            test0.AllTests.Add(p4);
            test0.AllTests.Add(p5);
            test0.AllTests.Add(p6);
            test0.AllTests.Add(p7);
            test0.AllTests.Add(p8);
            test0.AllTests.Add(p9);
            test0.Prediction = prediction;

            test1.AllTests.Add(p0);
            test1.Prediction = prediction;

            pv[0].Patient = p[0]; pv[0].Doctor = AllDoctorCard[1]; pv[0].VisitDateTime = DateTime.Parse("1995-12-07 17:41:11"); pv[0].Test = test0; pv[0].Pulse = 98; pv[0].Temperture = 36.5; pv[0].BloodPresure = "120/80"; pv[0].TestType = Enum_TestType.Spiro_TLC; pv[0].TestStatus = Enum_TestStatus.Proccesing;
            pv[1].Patient = p[0]; pv[1].Doctor = AllDoctorCard[1]; pv[1].VisitDateTime = DateTime.Parse("2020-02-07 17:40:53"); pv[1].Test = test0; pv[1].Pulse = 94; pv[1].Temperture = 35.6; pv[1].BloodPresure = "100/80"; pv[1].TestType = Enum_TestType.Spiro_TLC; pv[1].TestStatus = Enum_TestStatus.Finished;
            pv[2].Patient = p[1]; pv[2].Doctor = AllDoctorCard[0]; pv[2].VisitDateTime = DateTime.Parse("1963-12-25 17:43:48"); pv[2].Test = test1; pv[2].Pulse = 99; pv[2].Temperture = 36.7; pv[2].BloodPresure = "100/83"; pv[2].TestType = Enum_TestType.Spiro_TLC; pv[2].TestStatus = Enum_TestStatus.Proccesing;
            pv[3].Patient = p[1]; pv[3].Doctor = AllDoctorCard[0]; pv[3].VisitDateTime = DateTime.Parse("2003-09-24 17:45:10"); pv[3].Test = test1; pv[3].Pulse = 89; pv[3].Temperture = 38.4; pv[3].BloodPresure = "122/78"; pv[3].TestType = Enum_TestType.Spiro_TLC; pv[3].TestStatus = Enum_TestStatus.Proccesing;
            pv[4].Patient = p[1]; pv[4].Doctor = AllDoctorCard[2]; pv[4].VisitDateTime = DateTime.Parse("2005-03-25 17:43:40"); pv[4].Test = test1; pv[4].Pulse = 110; pv[4].Temperture = 39.5; pv[4].BloodPresure = "145/63"; pv[4].TestType = Enum_TestType.Spiro_TLC; pv[4].TestStatus = Enum_TestStatus.Finished;
            pv[5].Patient = p[1]; pv[5].Doctor = AllDoctorCard[2]; pv[5].VisitDateTime = DateTime.Parse("2008-07-20 17:42:13"); pv[5].Test = test1; pv[5].Pulse = 102; pv[5].Temperture = 36.4; pv[5].BloodPresure = "190/28"; pv[5].TestType = Enum_TestType.Spiro_TLC; pv[5].TestStatus = Enum_TestStatus.Finished;
            pv[6].Patient = p[1]; pv[6].Doctor = AllDoctorCard[2]; pv[6].VisitDateTime = DateTime.Parse("2015-03-11 17:44:38"); pv[6].Test = test1; pv[6].Pulse = 110; pv[6].Temperture = 37.0; pv[6].BloodPresure = "165/87"; pv[6].TestType = Enum_TestType.Spiro_TLC; pv[6].TestStatus = Enum_TestStatus.Proccesing;
            pv[7].Patient = p[1]; pv[7].Doctor = AllDoctorCard[2]; pv[7].VisitDateTime = DateTime.Parse("2020-04-01 17:44:04"); pv[7].Test = test1; pv[7].Pulse = 101; pv[7].Temperture = 37.6; pv[7].BloodPresure = "172/96"; pv[7].TestType = Enum_TestType.Spiro_TLC; pv[7].TestStatus = Enum_TestStatus.Proccesing;
            pv[8].Patient = p[2]; pv[8].Doctor = AllDoctorCard[1]; pv[8].VisitDateTime = DateTime.Parse("2001-05-07 17:43:56"); pv[8].Test = test1; pv[8].Pulse = 109; pv[8].Temperture = 35.9; pv[8].BloodPresure = "182/93"; pv[8].TestType = Enum_TestType.Spiro_TLC; pv[8].TestStatus = Enum_TestStatus.Finished;
            pv[9].Patient = p[2]; pv[9].Doctor = AllDoctorCard[0]; pv[9].VisitDateTime = DateTime.Parse("2004-10-30 17:42:29"); pv[9].Test = test1; pv[9].Pulse = 107; pv[9].Temperture = 36.3; pv[9].BloodPresure = "110/90"; pv[9].TestType = Enum_TestType.Spiro_TLC; pv[9].TestStatus = Enum_TestStatus.Proccesing;
            pv[10].Patient = p[2]; pv[10].Doctor = AllDoctorCard[0]; pv[10].VisitDateTime = DateTime.Parse("2012-10-08 17:44:59"); pv[10].Test = test1; pv[10].Pulse = 95; pv[10].Temperture = 36.5; pv[10].BloodPresure = "115/76"; pv[10].TestType = Enum_TestType.Spiro_TLC; pv[10].TestStatus = Enum_TestStatus.Proccesing;
            pv[11].Patient = p[3]; pv[11].Doctor = AllDoctorCard[2]; pv[11].VisitDateTime = DateTime.Parse("2007-08-16 17:42:37"); pv[11].Test = test1; pv[11].Pulse = 98; pv[11].Temperture = 36.9; pv[11].BloodPresure = "124/93"; pv[11].TestType = Enum_TestType.Spiro_TLC; pv[11].TestStatus = Enum_TestStatus.Finished;
            pv[12].Patient = p[4]; pv[12].Doctor = AllDoctorCard[2]; pv[12].VisitDateTime = DateTime.Parse("1999-01-01 17:44:20"); pv[12].Test = test1; pv[12].Pulse = 89; pv[12].Temperture = 34.6; pv[12].BloodPresure = "123/82"; pv[12].TestType = Enum_TestType.Spiro_TLC; pv[12].TestStatus = Enum_TestStatus.Proccesing;
            pv[13].Patient = p[4]; pv[13].Doctor = AllDoctorCard[2]; pv[13].VisitDateTime = DateTime.Parse("2000-12-25 17:45:20"); pv[13].Test = test1; pv[13].Pulse = 82; pv[13].Temperture = 33.7; pv[13].BloodPresure = "136/98"; pv[13].TestType = Enum_TestType.Spiro_TLC; pv[13].TestStatus = Enum_TestStatus.Finished;
            pv[14].Patient = p[4]; pv[14].Doctor = AllDoctorCard[2]; pv[14].VisitDateTime = DateTime.Parse("2007-09-30 17:44:12"); pv[14].Test = test1; pv[14].Pulse = 92; pv[14].Temperture = 39.5; pv[14].BloodPresure = "142/89"; pv[14].TestType = Enum_TestType.Spiro_TLC; pv[14].TestStatus = Enum_TestStatus.Finished;
            pv[15].Patient = p[4]; pv[15].Doctor = AllDoctorCard[2]; pv[15].VisitDateTime = DateTime.Parse("2019-11-30 17:42:46"); pv[15].Test = test1; pv[15].Pulse = 99; pv[15].Temperture = 38.9; pv[15].BloodPresure = "123/84"; pv[15].TestType = Enum_TestType.Spiro_TLC; pv[15].TestStatus = Enum_TestStatus.Finished;
            pv[16].Patient = p[5]; pv[16].Doctor = AllDoctorCard[1]; pv[16].VisitDateTime = DateTime.Parse("1998-04-17 17:42:55"); pv[16].Test = test1; pv[16].Pulse = 93; pv[16].Temperture = 37.6; pv[16].BloodPresure = "134/72"; pv[16].TestType = Enum_TestType.Spiro_TLC; pv[16].TestStatus = Enum_TestStatus.Proccesing;
            pv[17].Patient = p[6]; pv[17].Doctor = AllDoctorCard[0]; pv[17].VisitDateTime = DateTime.Parse("1958-01-11 17:43:03"); pv[17].Test = test1; pv[17].Pulse = 97; pv[17].Temperture = 36.5; pv[17].BloodPresure = "110/65"; pv[17].TestType = Enum_TestType.Spiro_TLC; pv[17].TestStatus = Enum_TestStatus.Proccesing;
            pv[18].Patient = p[7]; pv[18].Doctor = AllDoctorCard[0]; pv[18].VisitDateTime = DateTime.Parse("2021-02-07 17:43:13"); pv[18].Test = test1; pv[18].Pulse = 96; pv[18].Temperture = 36.1; pv[18].BloodPresure = "102/56"; pv[18].TestType = Enum_TestType.Spiro_TLC; pv[18].TestStatus = Enum_TestStatus.Proccesing;
            pv[19].Patient = p[8]; pv[19].Doctor = AllDoctorCard[1]; pv[19].VisitDateTime = DateTime.Parse("1976-03-14 17:44:29"); pv[19].Test = test1; pv[19].Pulse = 85; pv[19].Temperture = 34.9; pv[19].BloodPresure = "117/65"; pv[19].TestType = Enum_TestType.Spiro_TLC; pv[19].TestStatus = Enum_TestStatus.Proccesing;
            pv[20].Patient = p[8]; pv[20].Doctor = AllDoctorCard[1]; pv[20].VisitDateTime = DateTime.Parse("2004-06-01 17:43:22"); pv[20].Test = test1; pv[20].Pulse = 87; pv[20].Temperture = 32.8; pv[20].BloodPresure = "109/64"; pv[20].TestType = Enum_TestType.Spiro_TLC; pv[20].TestStatus = Enum_TestStatus.Finished;
            pv[21].Patient = p[9]; pv[21].Doctor = AllDoctorCard[0]; pv[21].VisitDateTime = DateTime.Parse("1992-07-05 17:43:31"); pv[21].Test = test1; pv[21].Pulse = 83; pv[21].Temperture = 36.0; pv[21].BloodPresure = "119/73"; pv[21].TestType = Enum_TestType.Spiro_TLC; pv[21].TestStatus = Enum_TestStatus.Proccesing;
            pv[22].Patient = p[9]; pv[22].Doctor = AllDoctorCard[0]; pv[22].VisitDateTime = DateTime.Parse("2013-01-25 17:45:29"); pv[22].Test = test1; pv[22].Pulse = 98; pv[22].Temperture = 38.1; pv[22].BloodPresure = "128/89"; pv[22].TestType = Enum_TestType.Spiro_TLC; pv[22].TestStatus = Enum_TestStatus.Finished;

            pv[23].Patient = p[6]; pv[23].Doctor = AllDoctorCard[0]; pv[23].VisitDateTime = DateTime.Parse("2012-10-07 17:44:59"); pv[23].Test = test1; pv[23].Pulse = 95; pv[23].Temperture = 36.5; pv[23].BloodPresure = "115/76"; pv[23].TestType = Enum_TestType.Spiro_TLC; pv[23].TestStatus = Enum_TestStatus.Proccesing;
            pv[24].Patient = p[6]; pv[24].Doctor = AllDoctorCard[2]; pv[24].VisitDateTime = DateTime.Parse("2007-08-17 17:42:37"); pv[24].Test = test1; pv[24].Pulse = 98; pv[24].Temperture = 36.9; pv[24].BloodPresure = "124/93"; pv[24].TestType = Enum_TestType.Spiro_TLC; pv[24].TestStatus = Enum_TestStatus.Finished;
            pv[25].Patient = p[6]; pv[25].Doctor = AllDoctorCard[2]; pv[25].VisitDateTime = DateTime.Parse("1999-01-02 17:44:20"); pv[25].Test = test1; pv[25].Pulse = 89; pv[25].Temperture = 34.6; pv[25].BloodPresure = "123/82"; pv[25].TestType = Enum_TestType.Spiro_TLC; pv[25].TestStatus = Enum_TestStatus.Proccesing;
            pv[26].Patient = p[6]; pv[26].Doctor = AllDoctorCard[2]; pv[26].VisitDateTime = DateTime.Parse("2000-12-26 17:45:20"); pv[26].Test = test1; pv[26].Pulse = 82; pv[26].Temperture = 33.7; pv[26].BloodPresure = "136/98"; pv[26].TestType = Enum_TestType.Spiro_TLC; pv[26].TestStatus = Enum_TestStatus.Finished;
            pv[27].Patient = p[6]; pv[27].Doctor = AllDoctorCard[2]; pv[27].VisitDateTime = DateTime.Parse("2007-10-01 17:44:12"); pv[27].Test = test1; pv[27].Pulse = 92; pv[27].Temperture = 39.5; pv[27].BloodPresure = "142/89"; pv[27].TestType = Enum_TestType.Spiro_TLC; pv[27].TestStatus = Enum_TestStatus.Finished;
            pv[28].Patient = p[6]; pv[28].Doctor = AllDoctorCard[2]; pv[28].VisitDateTime = DateTime.Parse("2019-12-01 12:42:46"); pv[28].Test = test1; pv[28].Pulse = 99; pv[28].Temperture = 38.9; pv[28].BloodPresure = "123/84"; pv[28].TestType = Enum_TestType.Spiro_TLC; pv[28].TestStatus = Enum_TestStatus.Finished;
            pv[29].Patient = p[6]; pv[29].Doctor = AllDoctorCard[1]; pv[29].VisitDateTime = DateTime.Parse("1998-04-18 12:42:55"); pv[29].Test = test1; pv[29].Pulse = 93; pv[29].Temperture = 37.6; pv[29].BloodPresure = "134/72"; pv[29].TestType = Enum_TestType.Spiro_TLC; pv[29].TestStatus = Enum_TestStatus.Proccesing;
            pv[30].Patient = p[6]; pv[30].Doctor = AllDoctorCard[0]; pv[30].VisitDateTime = DateTime.Parse("1958-01-12 12:43:03"); pv[30].Test = test1; pv[30].Pulse = 97; pv[30].Temperture = 36.5; pv[30].BloodPresure = "110/65"; pv[30].TestType = Enum_TestType.Spiro_TLC; pv[30].TestStatus = Enum_TestStatus.Proccesing;
            pv[31].Patient = p[6]; pv[31].Doctor = AllDoctorCard[0]; pv[31].VisitDateTime = DateTime.Parse("2021-02-08 12:43:13"); pv[31].Test = test1; pv[31].Pulse = 96; pv[31].Temperture = 36.1; pv[31].BloodPresure = "102/56"; pv[31].TestType = Enum_TestType.Spiro_TLC; pv[31].TestStatus = Enum_TestStatus.Proccesing;
            pv[32].Patient = p[6]; pv[32].Doctor = AllDoctorCard[1]; pv[32].VisitDateTime = DateTime.Parse("1976-03-15 12:44:29"); pv[32].Test = test1; pv[32].Pulse = 85; pv[32].Temperture = 34.9; pv[32].BloodPresure = "117/65"; pv[32].TestType = Enum_TestType.Spiro_TLC; pv[32].TestStatus = Enum_TestStatus.Proccesing;
            pv[33].Patient = p[6]; pv[33].Doctor = AllDoctorCard[1]; pv[33].VisitDateTime = DateTime.Parse("2004-06-02 12:43:22"); pv[33].Test = test1; pv[33].Pulse = 87; pv[33].Temperture = 32.8; pv[33].BloodPresure = "109/64"; pv[33].TestType = Enum_TestType.Spiro_TLC; pv[33].TestStatus = Enum_TestStatus.Finished;
            pv[34].Patient = p[6]; pv[34].Doctor = AllDoctorCard[0]; pv[34].VisitDateTime = DateTime.Parse("1992-07-06 12:43:31"); pv[34].Test = test1; pv[34].Pulse = 83; pv[34].Temperture = 36.0; pv[34].BloodPresure = "119/73"; pv[34].TestType = Enum_TestType.Spiro_TLC; pv[34].TestStatus = Enum_TestStatus.Proccesing;
            pv[35].Patient = p[6]; pv[35].Doctor = AllDoctorCard[0]; pv[35].VisitDateTime = DateTime.Parse("2013-01-26 12:45:29"); pv[35].Test = test1; pv[35].Pulse = 98; pv[35].Temperture = 38.1; pv[35].BloodPresure = "128/89"; pv[35].TestType = Enum_TestType.Spiro_TLC; pv[35].TestStatus = Enum_TestStatus.Finished;
            pv[36].Patient = p[6]; pv[36].Doctor = AllDoctorCard[2]; pv[36].VisitDateTime = DateTime.Parse("2000-12-27 12:45:20"); pv[36].Test = test1; pv[36].Pulse = 82; pv[36].Temperture = 33.7; pv[36].BloodPresure = "136/98"; pv[36].TestType = Enum_TestType.Spiro_TLC; pv[36].TestStatus = Enum_TestStatus.Finished;
            pv[37].Patient = p[6]; pv[37].Doctor = AllDoctorCard[2]; pv[37].VisitDateTime = DateTime.Parse("2007-10-02 12:44:12"); pv[37].Test = test1; pv[37].Pulse = 92; pv[37].Temperture = 39.5; pv[37].BloodPresure = "142/89"; pv[37].TestType = Enum_TestType.Spiro_TLC; pv[37].TestStatus = Enum_TestStatus.Finished;
            pv[38].Patient = p[6]; pv[38].Doctor = AllDoctorCard[2]; pv[38].VisitDateTime = DateTime.Parse("2019-12-02 12:42:46"); pv[38].Test = test1; pv[38].Pulse = 99; pv[38].Temperture = 38.9; pv[38].BloodPresure = "123/84"; pv[38].TestType = Enum_TestType.Spiro_TLC; pv[38].TestStatus = Enum_TestStatus.Finished;
            pv[39].Patient = p[6]; pv[39].Doctor = AllDoctorCard[1]; pv[39].VisitDateTime = DateTime.Parse("1998-04-19 12:42:55"); pv[39].Test = test1; pv[39].Pulse = 93; pv[39].Temperture = 37.6; pv[39].BloodPresure = "134/72"; pv[39].TestType = Enum_TestType.Spiro_TLC; pv[39].TestStatus = Enum_TestStatus.Proccesing;
            pv[40].Patient = p[6]; pv[40].Doctor = AllDoctorCard[0]; pv[40].VisitDateTime = DateTime.Parse("1958-01-13 12:43:03"); pv[40].Test = test1; pv[40].Pulse = 97; pv[40].Temperture = 36.5; pv[40].BloodPresure = "110/65"; pv[40].TestType = Enum_TestType.Spiro_TLC; pv[40].TestStatus = Enum_TestStatus.Proccesing;
            pv[41].Patient = p[6]; pv[41].Doctor = AllDoctorCard[0]; pv[41].VisitDateTime = DateTime.Parse("2021-02-09 12:43:13"); pv[41].Test = test1; pv[41].Pulse = 96; pv[41].Temperture = 36.1; pv[41].BloodPresure = "102/56"; pv[41].TestType = Enum_TestType.Spiro_TLC; pv[41].TestStatus = Enum_TestStatus.Proccesing;
            pv[42].Patient = p[6]; pv[42].Doctor = AllDoctorCard[1]; pv[42].VisitDateTime = DateTime.Parse("1976-03-16 12:44:29"); pv[42].Test = test1; pv[42].Pulse = 85; pv[42].Temperture = 34.9; pv[42].BloodPresure = "117/65"; pv[42].TestType = Enum_TestType.Spiro_TLC; pv[42].TestStatus = Enum_TestStatus.Proccesing;
            pv[43].Patient = p[6]; pv[43].Doctor = AllDoctorCard[1]; pv[43].VisitDateTime = DateTime.Parse("2004-06-04 12:41:22"); pv[43].Test = test1; pv[43].Pulse = 87; pv[43].Temperture = 32.8; pv[43].BloodPresure = "109/64"; pv[43].TestType = Enum_TestType.Spiro_TLC; pv[43].TestStatus = Enum_TestStatus.Finished;
            pv[44].Patient = p[6]; pv[44].Doctor = AllDoctorCard[0]; pv[44].VisitDateTime = DateTime.Parse("1992-07-08 12:41:31"); pv[44].Test = test1; pv[44].Pulse = 83; pv[44].Temperture = 36.0; pv[44].BloodPresure = "119/73"; pv[44].TestType = Enum_TestType.Spiro_TLC; pv[44].TestStatus = Enum_TestStatus.Proccesing;
            pv[45].Patient = p[6]; pv[45].Doctor = AllDoctorCard[0]; pv[45].VisitDateTime = DateTime.Parse("2013-01-28 12:41:29"); pv[45].Test = test1; pv[45].Pulse = 98; pv[45].Temperture = 38.1; pv[45].BloodPresure = "128/89"; pv[45].TestType = Enum_TestType.Spiro_TLC; pv[45].TestStatus = Enum_TestStatus.Finished;
            pv[46].Patient = p[6]; pv[46].Doctor = AllDoctorCard[0]; pv[46].VisitDateTime = DateTime.Parse("1992-07-08 12:41:31"); pv[46].Test = test1; pv[46].Pulse = 83; pv[46].Temperture = 36.0; pv[46].BloodPresure = "119/73"; pv[46].TestType = Enum_TestType.Spiro_TLC; pv[46].TestStatus = Enum_TestStatus.Proccesing;
            pv[47].Patient = p[6]; pv[47].Doctor = AllDoctorCard[0]; pv[47].VisitDateTime = DateTime.Parse("2013-01-28 12:41:29"); pv[47].Test = test1; pv[47].Pulse = 98; pv[47].Temperture = 38.1; pv[47].BloodPresure = "128/89"; pv[47].TestType = Enum_TestType.Spiro_TLC; pv[47].TestStatus = Enum_TestStatus.Finished;
            pv[48].Patient = p[6]; pv[48].Doctor = AllDoctorCard[2]; pv[48].VisitDateTime = DateTime.Parse("2000-12-28 12:41:20"); pv[48].Test = test1; pv[48].Pulse = 82; pv[48].Temperture = 33.7; pv[48].BloodPresure = "136/98"; pv[48].TestType = Enum_TestType.Spiro_TLC; pv[48].TestStatus = Enum_TestStatus.Finished;
            pv[49].Patient = p[6]; pv[49].Doctor = AllDoctorCard[2]; pv[49].VisitDateTime = DateTime.Parse("2007-10-03 12:41:12"); pv[49].Test = test1; pv[49].Pulse = 92; pv[49].Temperture = 39.5; pv[49].BloodPresure = "142/89"; pv[49].TestType = Enum_TestType.Spiro_TLC; pv[49].TestStatus = Enum_TestStatus.Finished;

            for (int i = 0; i < p.Length; i++)
                p[i].UnitSystem = config.UnitSystem;
            for (int i = 0; i < pv.Length; i++)
                pv[i].UnitSystem = config.UnitSystem;

            /*DateTime startTime = DateTime.Now, currentTime = DateTime.Now;
            for (int i = 0; i < p.Length; i++)
            {
                while (((TimeSpan)(currentTime - startTime)).TotalMilliseconds < 50) { currentTime = DateTime.Now; }
                startTime = currentTime;

                AddPatient(p[i]);
            }

            for (int i = 0; i < pv.Length; i++)
            {
                while (((TimeSpan)(currentTime - startTime)).TotalMilliseconds < 50) { currentTime = DateTime.Now; }
                startTime = currentTime;

                AddVisit(pv[i]);
            }*/

            allPatients = p.ToList();
            allVisits = pv.ToList();

            SavePatiensToFile();
            SaveVisitsToFile();

            Debug.WriteLine("Finish Simulating");
        }

        private void InitLastDoctor()
        {
            allVisits = allVisits.OrderBy(o => o.VisitDateTime).ToList();
            allVisits.Reverse();

            foreach (Patient p in allPatients)
            {
                p.LastDoctor = null;

                if (p.Visited == null)
                    p.Visited = new List<PatientVisit>();
                p.Visited.Clear();

                foreach (PatientVisit pv in allVisits)
                {
                    if (pv.Patient.PatientId.Equals(p.PatientId))
                    {
                        if (p.LastDoctor == null)
                            p.LastDoctor = pv.Doctor;

                        p.Visited.Add(pv);
                    }
                }
            }
        }

        public void InitAllDoctorCard()
        {
            LoggerWrapper.Log($"InitAllDoctorCard");

            if (allDoctorCard == null)
                allDoctorCard = new List<DoctorCard>();
            allDoctorCard.Clear();

            try 
            {
                allDoctorsDB.Clear();
                allDoctorsDB = Serializer.Load<List<DoctorCardDB>>(DoctorsDbFile);
            }
            catch(Exception ee)
            {
                allDoctorsDB = new List<DoctorCardDB>();
            }

            for(int i = 0; i < allDoctorsDB.Count; i++)
                allDoctorCard.Add(new DoctorCard(allDoctorsDB[i]));

            allDoctorsDB.Clear();
        }

        public void InitAllPatients()
        {
            LoggerWrapper.Log($"InitAllPatients");

            if (allPatients == null)
                allPatients = new List<Patient>();
            allPatients.Clear();

            try
            {
                allPatientsDB.Clear();
                allPatientsDB = Serializer.Load<List<PatientDB>>(PatientsDbFile);
            }
            catch(Exception ee)
            {
                allPatientsDB = new List<PatientDB>();
            }

            for (int i = 0; i < allPatientsDB.Count; i++)
                allPatients.Add(new Patient(allPatientsDB[i], config.UnitSystem));

            allPatientsDB.Clear();
        }

        public void InitAllVisits()
        {
            LoggerWrapper.Log($"InitAllVisits");

            if (allVisits == null)
                allVisits = new List<PatientVisit>();
            allVisits.Clear();

            try
            {
                allVisitsDB.Clear();
                allVisitsDB = Serializer.Load<List<PatientVisitDB>>(VisitsDbFile);
            }
            catch(Exception ee)
            {
                allVisitsDB = new List<PatientVisitDB>();
            }

            for (int i = 0; i < allVisitsDB.Count; i++)
            {
                // init doctor that is inside the visit
                for(int j = 0; j < allDoctorCard.Count; j++)
                    if (allVisitsDB[i].UserName.Equals(allDoctorCard[j].UserName))
                    {
                        allVisitsDB[i].DoctorCardDB = new DoctorCardDB(allDoctorCard[j]);
                        break;
                    }

                // init patinet that is inside the visit
                for (int j = 0; j < allPatients.Count; j++)
                    if (allVisitsDB[i].PatientId.Equals(allPatients[j].PatientId))
                    {
                        allVisitsDB[i].PatientDB = new PatientDB(allPatients[j]);
                        break;
                    }

                allVisits.Add(new PatientVisit(allVisitsDB[i], allVisitsDB[i].DoctorCardDB, allVisitsDB[i].PatientDB, config.UnitSystem));
            }

            allVisitsDB.Clear();
        }

        public bool UpdateDoctorCard(DoctorCard doctor, string oldUserName)
        {
            LoggerWrapper.Log("UpdateDoctorCard");

            try
            {
                bool changeUserName = false;
                DoctorCard card = allDoctorCard.Find(x => x.UserName == doctor.UserName);
                if (card == null)
                {
                    card = allDoctorCard.Find(x => x.UserName == oldUserName);
                    if (card == null)
                    {
                        return false;
                    }
                    changeUserName = true;
                }
                else if (card.UserName != oldUserName)
                    return false;
                if (changeUserName)
                {
                    AllDoctorCard.Add(new DoctorCard(doctor));
                    foreach (var item in AllVisits)
                    {
                        if (item.Doctor.UserName == oldUserName)
                            item.Doctor.UserName = doctor.UserName;
                    }
                    AllDoctorCard.Remove(card);


                    DoctorCard docFromList = AllDoctorCard.Find(doc => doc.UserName == oldUserName);
                    if (docFromList != null)
                        docFromList.CopyFromOther(doctor);

                }
                else
                {
                    card.CopyFromOther(doctor);
                    DoctorCard docFromList = AllDoctorCard.Find(doc => doc.UserName == doctor.UserName);
                    if (docFromList != null)
                        docFromList.CopyFromOther(doctor);
                }
                SaveDoctorsToFile();

            }
            catch (Exception ee)
            {
                return false;
            }
            return true;
        }

        public bool AddDoctorCard(DoctorCard doctor)
        {
            LoggerWrapper.Log("AddDoctorCard");
            try
            {
                DoctorCard temp = new DoctorCard();
                temp.CopyFromOther(doctor);
                allDoctorCard.Add(temp);
                SaveDoctorsToFile();
            }
            catch (Exception ee)
            {
                return false;
            }

            return true;
        }

        public bool DeleteDoctor(DoctorCard doctor)
        {
            LoggerWrapper.Log($"DeleteDoctor: {doctor.FullName}");

            try
            {

                DoctorCard card = AllDoctorCard.Find(doc => doc.UserName == doctor.UserName);
                if (card != null)
                {
                    foreach (var item in allVisits)
                    {
                        if (item.Doctor.UserName == doctor.UserName)
                            item.Doctor.UserName = notAvailableName;
                    }
                    AllDoctorCard.Remove(card);
                    SaveDoctorsToFile();
                    SaveVisitsToFile();
                    InitAllPatients();
                    InitAllVisits();
                }
            }
            catch (Exception ee)
            {
                return false;
            }

            return true;
        }
        public DoctorCard GetDoctor(string name, string password)
        {
            return AllDoctorCard.Find(item => item.UserName == name && item.Password == password);
        }

        public bool UpdatePatient(Patient patient, string oldPatientName)
        {
            LoggerWrapper.Log($"UpdatePatient");

            try
            {
                var patientDB = allPatients.Find(pat => pat.PatientId == oldPatientName);
                if (patientDB != null)
                {
                    patientDB.CopyFromOther(patient);


                    foreach (var item in allVisits)
                    {
                        if (item.Patient.PatientId == oldPatientName)
                            item.Patient.CopyFromOther(patient);
                    }
                }

                SavePatiensToFile();
                SaveVisitsToFile();
            }
            catch (Exception ee)
            {
                Debug.WriteLine("Exception: " + ee.Message);
                return false;
            }

            return true;
        }

        public string AddPatient(Patient patient)
        {
            LoggerWrapper.Log($"AddPatient");

            try
            {
                Patient patient1 = allPatients.Find(x => x.PatientId == patient.PatientId);
                if (patient1 != null)
                    return "ID number already in use";
                allPatients.Add(patient);
                SavePatiensToFile();
            }
            catch (Exception ee)
            {
                return $"Error: {ee.Message}";
            }

            return null;
        }

        public bool DeletePatient(Patient patient)
        {
            LoggerWrapper.Log($"DeletePatient");


            try
            {
                Patient patientDB = allPatients.First(x => x.PatientId == patient.PatientId);
                if (patientDB != null)
                {
                    List<PatientVisit> visitsToRemove = new List<PatientVisit>();
                    foreach (var item in allVisits)
                    {
                        if (item.Patient.PatientId.Equals(patient.PatientId))
                            visitsToRemove.Add(item);
                    }

                    for (int i = 0; i < visitsToRemove.Count; i++)
                    {
                        allVisits.Remove(visitsToRemove[i]);

                    }
                    allPatients.Remove(patientDB);


                    SaveVisitsToFile();
                    SavePatiensToFile();

                }
            }
            catch (Exception ee)
            {
                return false;
            }

            return true;
        }


        private List<DoctorCardDB> allDoctorsDB = new List<DoctorCardDB>();
        private List<PatientDB> allPatientsDB = new List<PatientDB>();
        private List<PatientVisitDB> allVisitsDB = new List<PatientVisitDB>();

        private void SaveDoctorsToFile()
        {
            allDoctorsDB.Clear();
            for (int i = 0; i < allDoctorCard.Count; i++)
                allDoctorsDB.Add(new DoctorCardDB(allDoctorCard[i]));

            Serializer.Save<List<DoctorCardDB>>(allDoctorsDB, DoctorsDbFile);
        }
        private void SaveVisitsToFile()
        {
            allVisitsDB.Clear();
            for (int i = 0; i < allVisits.Count; i++)
            {
                allVisitsDB.Add(new PatientVisitDB(allVisits[i]));
            }

            Serializer.Save<List<PatientVisitDB>>(allVisitsDB, VisitsDbFile);
        }
        private void SavePatiensToFile()
        {
            allPatientsDB.Clear();
            for (int i = 0; i < allPatients.Count; i++)
                allPatientsDB.Add(new PatientDB(allPatients[i]));

            Serializer.Save<List<PatientDB>>(allPatientsDB, PatientsDbFile);
        }

        public Patient GetPatient(string patientId)
        {
            return allPatients.Find(item => item.PatientId == patientId);
        }

        public bool UpdateVisit(PatientVisit visit)
        {
            LoggerWrapper.Log($"visit");

            try
            {
                var visitDB = allVisits.Find(x => x.VisitDateTime == visit.VisitDateTime);
                if (visitDB == null)
                    return false;
                visitDB.CopyFromOther(visit);
                SaveVisitsToFile();
            }
            catch (Exception ee)
            {
                return false;
            }

            return true;
        }

        public bool AddVisit(PatientVisit visit)
        {
            LoggerWrapper.Log($"AddVisit");

            if (visit == null)
                return false;

            AddPatient(visit.Patient);
            UpdatePatient(visit.Patient, "");

            try
            {
                PatientVisit visitDB = allVisits.Find(x => x.VisitDateTime == visit.VisitDateTime);
                if (visitDB != null)
                    return false;

                var visitTemp = new PatientVisit();
                visitTemp.CopyFromOther(visit);
                AllVisits.Add(visitTemp);
                SaveVisitsToFile();
            }
            catch (Exception ee)
            {
                return false;
            }
            return true;
        }

        public bool DeleteVisit(PatientVisit visit)
        {
            LoggerWrapper.Log($"visit");

            if (visit == null)
                return false;
            try
            {
                PatientVisit visitT = allVisits.Find(x => x.VisitDateTime == visit.VisitDateTime);
                if (visitT == null || (visit.VisitDateTime != visitT.VisitDateTime))
                {
                    //find by safeFolder

                    //visitT = allVisits.Find(x => x.SaveFilePath == visit.SaveFilePath);
                }
                if (visitT != null)
                {

                    AllVisits.Remove(visitT);
                    SaveVisitsToFile();
                }
            }
            catch (Exception ee)
            {
                return false;
            }

            return true;
        }

        public PatientVisit FindPatientVisit(string saveFilePath)
        {
            PatientVisit patientVisit = null;

            try
            {
                //patientVisit = AllVisits.Find(visit => visit.SaveFilePath == saveFilePath);

            }
            catch (Exception ee)
            {
                patientVisit = null;
            }

            return patientVisit;
        }

        public bool DeleteVisit(string saveFilePath)
        {
            PatientVisit findVisit = FindPatientVisit(saveFilePath);
            return DeleteVisit(findVisit);
        }

        private void LoadFromFile(string path)
        {
            try
            {
                string patientsData = File.ReadAllText($"{path}/PatientsData.csv");
                var sl = patientsData.Split(',');

                for (int i = 1; i < sl.Length / 19; i++)
                {
                    Patient p = new Patient();
                    p.PatientId = sl[(i * 19) + 0].Replace("\n", "").Replace("\r", ""); // id
                    p.FullName = sl[(i * 19) + 1]; // name
                    p.BirthDate = Convert.ToDateTime($"{DateTime.Now.Year - int.Parse(sl[(i * 19) + 2])}/{DateTime.Now.ToString("MM/dd")}"); // age
                    p.Gender = sl[(i * 19) + 3].Trim().Equals("male") ? Enum_Gender.Male : Enum_Gender.Female; // gender
                    p.Height = Double.Parse(sl[(i * 19) + 4]); // height
                    p.Weight = Double.Parse(sl[(i * 19) + 5]); // weight
                    //p.AdditionalInfo = sl[(i * 19) + 6]; // additional

                    p.PatientPicture = p.Gender == Enum_Gender.Male ? PictureHelper.GetDefaultPicture() : PictureHelper.getFemalePicture();

                    allPatients.Add(p);
                }
            }
            catch(Exception ee)
            {
                Debug.WriteLine($"Exception while loading db from file ({path}): {ee.Message}");
            }
        }
    }
}
