using AutoMapper;
using FundingPilotSystem.BO;
using FundingPilotSystem.Domain;
using FundingPilotSystem.UnifiedDataStore;


namespace FundingPilotSystem.DAL
{
 
    /// <summary>
    /// This class provides user registration related functionalities
    /// </summary>
    public class RegistrationProviderDAL
    {

        /// <summary>
        /// Saves user registration request
        /// </summary>
        /// <param name="userRegistrationRequestBO"></param>
        /// <returns></returns>
        public int SaveUserRegistrationRequest(UserRegistrationRequestBO userRegistrationRequestBO)
        {
            tblUserRegistrationRequestDto tblUserRegRequestDto = new tblUserRegistrationRequestDto();
            Mapper.CreateMap<UserRegistrationRequestBO, tblUserRegistrationRequestDto>();
            Mapper.Map(userRegistrationRequestBO, tblUserRegRequestDto);

            RegistrationProvider objUserProfileDataProvider = new RegistrationProvider();
            return objUserProfileDataProvider.SaveUserRegistrationRequest(tblUserRegRequestDto);
            
        }

        /// <summary>
        /// Saves registered users (records moves to this table after email varification process completed successfully)
        /// </summary>
        /// <param name="registeredUserBO"></param>
        /// <returns></returns>
        public int SaveRegisteredUser(RegisteredUserBO registeredUserBO)
        {
            tblRegisteredUserDto tblRegUserDto = new tblRegisteredUserDto();
            Mapper.CreateMap<RegisteredUserBO, tblRegisteredUserDto>();
            Mapper.Map(registeredUserBO, tblRegUserDto);

            RegistrationProvider objUserProfileDataProvider = new RegistrationProvider();
            return objUserProfileDataProvider.SaveRegisteredUser(tblRegUserDto);
        }

        /// <summary>
        /// Checks for duplicate email address (User id)
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public bool isDuplicateUserEmailAddress(byte[] emailAddress)
        {
            RegistrationProvider objUserProfileDataProvider = new RegistrationProvider();
            return objUserProfileDataProvider.isDuplicateUserEmailAddress(emailAddress);
        }
    }
}
