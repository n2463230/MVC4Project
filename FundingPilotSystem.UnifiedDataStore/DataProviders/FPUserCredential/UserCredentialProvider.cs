using AutoMapper;
using FundingPilotSystem.Domain;
using FundingPilotSystem.UnifiedDataStore.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.UnifiedDataStore
{

    /// <summary>
    /// This class peforms user credential related functionalities for funding pilot system
    /// </summary>
    public class UserCredentialProvider
    {

        /// <summary>
        /// Saves login credentials
        /// </summary>
        /// <param name="userLoginCredential"></param>
        /// <returns></returns>
        public int SaveUserLoginCredentials(tblUserLoginCredentialsDto userLoginCredential)
        {
            Mapper.CreateMap<tblUserLoginCredentialsDto, tblUserLoginCredential>();
            int result = 0;
            try
            {
                using (var userLoginCredentialContext = new FPUserCredentialEntities())
                {
                    tblUserLoginCredential userLoginCredentials = new tblUserLoginCredential();
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

        /// <summary>
        /// Saves login security questions
        /// </summary>
        /// <param name="userLoginQuestionsDto"></param>
        /// <returns></returns>
        public int SaveUserLoginQuestions(List<tblUserLoginQuestionsDto> userLoginQuestionsDto)
        {
            Mapper.CreateMap<tblUserLoginQuestionsDto, tblUserLoginQuestion>();
            int result = 0;
            try
            {
                using (var userLoginCredentialContext = new FPUserCredentialEntities())
                {
                    List<tblUserLoginQuestion> userLoginQuestion = new List<tblUserLoginQuestion>();
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
