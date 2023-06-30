using CFTracker.Models;
using CFTrackerServices.Models;

namespace CFTracker.Mappers
{
    public static class BodyMassIndexMapper
    {
        public static BodyMassIndexViewModel ToViewModel(this BodyMassIndex bodyMassIndexDB, BodyMassIndexViewModel bodyMassIndexView)
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

        public static BodyMassIndex ToDBModel(this BodyMassIndexViewModel bodyMassIndexView, BodyMassIndex bodyMassIndexDB)
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
