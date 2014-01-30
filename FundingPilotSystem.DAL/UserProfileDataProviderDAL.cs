using FundingPilotSystem.Domain.FPUserProfile;
using FundingPilotSystem.UnifiedDataStore.DataProviders;


namespace FundingPilotSystem.DAL
{
    public class UserProfileDataProviderDAL
    {
        public int Save_Registered_User_Request(tblUserRegistrationRequestDto userRegistrationRequestDto)
        {
            int result = 0;
            RegistrationProvider objUserProfileDataProvider = new RegistrationProvider();
            result = objUserProfileDataProvider.Save_Registered_User_Request(userRegistrationRequestDto);
            return result;
        }
        public int Save_Registered_User(tblRegisteredUserDto registeredUserDto)
        {
            int result = 0;
            RegistrationProvider objUserProfileDataProvider = new RegistrationProvider();
            result = objUserProfileDataProvider.Save_Registered_User(registeredUserDto);
            return result;
        }
    }
}
