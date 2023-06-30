using CFTracker.Models;
using CFTrackerServices.Models;

namespace CFTracker.Mappers
{
    public static class LungFunctionMapper
    {
        public static LungFunctionViewModel ToViewModel(this LungFunction lungFunctionDB, LungFunctionViewModel lungFunctionView)
        {
            lungFunctionView.Id = lungFunctionDB.Id;
            lungFunctionView.Date = lungFunctionDB.Date;
            lungFunctionView.Fev = lungFunctionDB.Fev;
            lungFunctionView.Fvc1 = lungFunctionDB.Fvc1;
            lungFunctionView.TestingMachine = lungFunctionDB.TestingMachine;

            return lungFunctionView;
        }

        public static LungFunction ToDBModel(this LungFunctionViewModel lungFunctionView, LungFunction lungFunctionDB)
        {
            lungFunctionDB.Id = lungFunctionView.Id;
            lungFunctionDB.Date = lungFunctionView.Date;
            lungFunctionDB.Fev = lungFunctionView.Fev;
            lungFunctionDB.Fvc1 = lungFunctionView.Fvc1;
            lungFunctionDB.TestingMachine = lungFunctionView.TestingMachine;

            return lungFunctionDB;
        }
    }
}
