using FundingPilotSystem.Domain.FPUserCredential;
using FundingPilotSystem.UnifiedDataStore.DataProviders;
using System.Collections.Generic;


namespace FundingPilotSystem.DAL
{
    public class UserCredentialProviderDAL
    {
        public int SaveUserLoginCredentials(tblUserLoginCredentialsDto userLoginCredentialsDto)
        {
            int result = 0;
            UserCredentialProvider objUserLoginCredentialsDataProvider = new UserCredentialProvider();
            result = objUserLoginCredentialsDataProvider.SaveUserLoginCredentials(userLoginCredentialsDto);
            return result;
        }

        public int SaveUserLoginQuestions(IEnumerable<tblUserLoginQuestionsDto> userLoginQuestionsDto)
        {
            int result = 0;
            UserCredentialProvider objUserLoginCredentialsDataProvider = new UserCredentialProvider();
            result = objUserLoginCredentialsDataProvider.SaveUserLoginQuestions(userLoginQuestionsDto);
            return result;
        }
    }
}
