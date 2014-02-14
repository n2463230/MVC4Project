using AutoMapper;
using FundingPilotSystem.BO;
using FundingPilotSystem.Domain;
using FundingPilotSystem.UnifiedDataStore;
using System.Collections.Generic;


namespace FundingPilotSystem.DAL
{

    /// <summary>
    /// This class provides user credential related functionalities
    /// </summary>
    public class UserCredentialProviderDAL
    {

        /// <summary>
        /// Saves login credentials
        /// </summary>
        /// <param name="userLoginCredentialBO"></param>
        /// <returns></returns>
        public int SaveUserLoginCredentials(UserLoginCredentialBO userLoginCredentialBO)
        {
            tblUserLoginCredentialsDto userLoginCredentialsDto = new tblUserLoginCredentialsDto();
            Mapper.CreateMap<UserLoginCredentialBO, tblUserLoginCredentialsDto>();
            Mapper.Map(userLoginCredentialBO, userLoginCredentialsDto);

            UserCredentialProvider objUserLoginCredentialsDataProvider = new UserCredentialProvider();
            return objUserLoginCredentialsDataProvider.SaveUserLoginCredentials(userLoginCredentialsDto);
        }

        /// <summary>
        /// Saves login security questions
        /// </summary>
        /// <param name="userLoginQuetionBO"></param>
        /// <returns></returns>
        public int SaveUserLoginQuestions(List<UserLoginQuetionBO> userLoginQuetionBO)
        {
            List<tblUserLoginQuestionsDto> userLoginQuestionsDto = new List<tblUserLoginQuestionsDto>();
            Mapper.CreateMap<UserLoginQuetionBO, tblUserLoginQuestionsDto>();
            Mapper.Map(userLoginQuetionBO, userLoginQuestionsDto);

            UserCredentialProvider objUserLoginCredentialsDataProvider = new UserCredentialProvider();
            return objUserLoginCredentialsDataProvider.SaveUserLoginQuestions(userLoginQuestionsDto);
        }
    }
}
