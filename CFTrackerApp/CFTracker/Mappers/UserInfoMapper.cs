using CFTracker.Models;
using CFTrackerServices.Models;

namespace CFTracker.Mappers
{
    public static class UserInfoMapper
    {
        public static UserInfoViewModel ToViewModel(this UserInfo userDBInfo, UserInfoViewModel userView)
        {
            userView.PatientId = userDBInfo.PatientId;
            userView.FirstName = userDBInfo.FirstName;
            userView.LastName = userDBInfo.LastName;
            userView.DateOfBirth = userDBInfo.DateOfBirth;
            userView.PhoneNumber = userDBInfo.PhoneNumber;
            userView.EmailAddress = userDBInfo.EmailAddress;

            return userView;
        }

        public static UserInfo ToDBModel(this UserInfoViewModel userInput, UserInfo userDBInfo)
        {
            userDBInfo.PatientId = userInput.PatientId;
            userDBInfo.FirstName = userInput.FirstName;
            userDBInfo.LastName = userInput.LastName;
            userDBInfo.DateOfBirth = userInput.DateOfBirth;
            userDBInfo.PhoneNumber = userInput.PhoneNumber;
            userDBInfo.EmailAddress = userInput.EmailAddress;

            return userDBInfo;
        }
    }
}
