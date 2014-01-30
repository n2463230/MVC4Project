using FundingPilotSystem.Domain.FPUserProfile;
using FundingPilotSystem.UnifiedDataStore.DataProviders;


namespace FundingPilotSystem.DAL.FPUserProfile.Registration
{
    public class RegistrationProviderDAL
    {
        public int SaveUserRegistrationRequest(tblUserRegistrationRequestDto userRegistrationRequestDto)
        {
            int result = 0;
            RegistrationProvider objUserProfileDataProvider = new RegistrationProvider();
            result = objUserProfileDataProvider.SaveUserRegistrationRequest(userRegistrationRequestDto);
            return result;
        }
        public int SaveRegisteredUser(tblRegisteredUserDto registeredUserDto)
        {
            int result = 0;
            RegistrationProvider objUserProfileDataProvider = new RegistrationProvider();
            result = objUserProfileDataProvider.SaveRegisteredUser(registeredUserDto);
            return result;
        }

        public bool isDuplicateUserEmailAddress(byte[] emailAddress)
        {
            RegistrationProvider objUserProfileDataProvider = new RegistrationProvider();
            return objUserProfileDataProvider.isDuplicateUserEmailAddress(emailAddress);
        }
    }
}
