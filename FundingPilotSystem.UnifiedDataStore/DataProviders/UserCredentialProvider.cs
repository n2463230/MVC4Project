using AutoMapper;
using FundingPilotSystem.Domain.FPUserCredential;
using FundingPilotSystem.Domain.SolutionDto;
using FundingPilotSystem.UnifiedDataStore.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.UnifiedDataStore.DataProviders
{
    public class UserCredentialProvider
    {
        public int SaveUserLoginCredentials(tblUserLoginCredentialsDto userLoginCredential)
        {
            Mapper.CreateMap<tblUserLoginCredentialsDto, tblUserLoginCredential>();
            int result = 0;
            try
            {
                using (var userLoginCredentialContext = new FPUserCredentialEntities())
                {
                    var userLoginCredentials = new tblUserLoginCredential();
                    Mapper.Map(userLoginCredential, userLoginCredentials);
                    userLoginCredentialContext.tblUserLoginCredentials.Add(userLoginCredentials);
                    result = userLoginCredentialContext.SaveChanges();
                }
            }
            catch
            {
                return -1;
            }
            return result;
        }
        public int SaveUserLoginQuestions(IEnumerable<tblUserLoginQuestionsDto> userLoginQuestionsDto)
        {
            Mapper.CreateMap<tblUserLoginQuestionsDto, tblUserLoginQuestion>();
            int result = 0;
            try
            {
                using (var userLoginCredentialContext = new FPUserCredentialEntities())
                {
                    var userLoginQuestion = new List<tblUserLoginQuestion>();
                    Mapper.Map(userLoginQuestionsDto, userLoginQuestion);
                    userLoginCredentialContext.tblUserLoginQuestions.AddRange(userLoginQuestion);
                    result = userLoginCredentialContext.SaveChanges();
                }
            }
            catch
            {
                return -1;
            }
            return result;
        }
    }
}
