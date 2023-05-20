using CFTracker.Models;
using CFTrackerServices.Models;

namespace CFTracker.Services
{
    public static class ModelsMapper
    {
        public static UserInfoViewModel UserInfoDBModelToViewModel(UserInfo userDBInfo, UserInfoViewModel userView)
        {
            userView.PatientId = userDBInfo.PatientId;
            userView.FirstName = userDBInfo.FirstName;
            userView.LastName = userDBInfo.LastName;
            userView.DateOfBirth = userDBInfo.DateOfBirth;
            userView.PhoneNumber= userDBInfo.PhoneNumber;
            userView.EmailAddress = userDBInfo.EmailAddress;

            return userView;            
        }

        public static UserInfo UserInfoViewModelToDBModel(UserInfoViewModel userInput, UserInfo userDBInfo)
        {
            userDBInfo.PatientId = userInput.PatientId;
            userDBInfo.FirstName = userInput.FirstName;
            userDBInfo.LastName = userInput.LastName;
            userDBInfo.DateOfBirth= userInput.DateOfBirth;
            userDBInfo.PhoneNumber= userInput.PhoneNumber;
            userDBInfo.EmailAddress= userInput.EmailAddress;

            return userDBInfo;
        }

        public static LungFunctionViewModel LungFunctionDBModelToViewModel(LungFunction lungFunctionDB, LungFunctionViewModel lungFunctionView)
        {
            lungFunctionView.Id = lungFunctionDB.Id;
            lungFunctionView.Date = lungFunctionDB.Date;
            lungFunctionView.Fev = lungFunctionDB.Fev;
            lungFunctionView.Fvc1 = lungFunctionDB.Fvc1;
            lungFunctionView.TestingMachine= lungFunctionDB.TestingMachine;

            return lungFunctionView;
        }

        public static LungFunction LungFunctionViewModelToDBModel(LungFunctionViewModel lungFunctionView, LungFunction lungFunctionDB)
        {
            lungFunctionDB.Id = lungFunctionView.Id;
            lungFunctionDB.Date = lungFunctionView.Date;
            lungFunctionDB.Fev = lungFunctionView.Fev;
            lungFunctionDB.Fvc1 = lungFunctionView.Fvc1;
            lungFunctionDB.TestingMachine= lungFunctionView.TestingMachine;

            return lungFunctionDB;
        }

        public static BodyMassIndexViewModel BodyMassIndexDBModelToViewModel(BodyMassIndex bodyMassIndexDB, BodyMassIndexViewModel bodyMassIndexView)
        {
            bodyMassIndexView.Id = bodyMassIndexDB.Id;
            bodyMassIndexView.Date = bodyMassIndexDB.Date;
            bodyMassIndexView.WeightKg = bodyMassIndexDB.WeightKg;
            bodyMassIndexView.WeightTestingMachine = bodyMassIndexDB.WeightTestingMachine;
            bodyMassIndexView.HeightCm = bodyMassIndexDB.HeightCm;
            bodyMassIndexView.HeightTestingMachine = bodyMassIndexDB.HeightTestingMachine;            
            bodyMassIndexView.Bmi = bodyMassIndexDB.Bmi;

            return bodyMassIndexView;
        }

        public static BodyMassIndex BodyMassIndexViewModelToDBModel(BodyMassIndexViewModel bodyMassIndexView, BodyMassIndex bodyMassIndexDB)
        {
            bodyMassIndexDB.Id = bodyMassIndexView.Id;
            bodyMassIndexDB.Date = bodyMassIndexView.Date;
            bodyMassIndexDB.WeightKg = bodyMassIndexView.WeightKg;
            bodyMassIndexDB.WeightTestingMachine = bodyMassIndexView.WeightTestingMachine;
            bodyMassIndexDB.HeightCm = bodyMassIndexView.HeightCm;
            bodyMassIndexDB.HeightTestingMachine = bodyMassIndexView.HeightTestingMachine;
            bodyMassIndexDB.Bmi = bodyMassIndexView.Bmi;

            return bodyMassIndexDB;
        }

    }
}
