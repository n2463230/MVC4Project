using AutoMapper;
using FundingPilotSystem.Domain;
using FundingPilotSystem.UnifiedDataStore.ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundingPilotSystem.Common;

namespace FundingPilotSystem.UnifiedDataStore
{

    /// <summary>
    /// This class performs registration process related operations for funding pilot system
    /// </summary>
    public class RegistrationProvider
    {
        /// <summary>
        /// Saves registration request
        /// </summary>
        /// <param name="userRegistrationRequestDto"></param>
        /// <returns></returns>
        public int SaveUserRegistrationRequest(tblUserRegistrationRequestDto userRegistrationRequestDto)
        {
            Mapper.CreateMap<tblUserRegistrationRequestDto, tblUserRegistrationRequest>();
            int result = 0;
            try
            {
                using (var userRegistrationRequestContext = new FPUserProfileEntities())
                {
                    var userRegistrationRequest = new tblUserRegistrationRequest();
                    Mapper.Map(userRegistrationRequestDto, userRegistrationRequest);
                    userRegistrationRequestContext.tblUserRegistrationRequests.Add(userRegistrationRequest);
                    result = userRegistrationRequestContext.SaveChanges();
                }
            }
            catch
            {
                return -1;
            }
            return result;
        }

        /// <summary>
        /// Saves registered users (records moves to this table after email varification process completed successfully)
        /// </summary>
        /// <param name="registeredUserDto"></param>
        /// <returns></returns>
        public int SaveRegisteredUser(tblRegisteredUserDto registeredUserDto)
        {
            Mapper.CreateMap<tblRegisteredUserDto, tblRegisteredUser>();
            int result = 0;
            try
            {
                using (var registeredUserContext = new FPUserProfileEntities())
                {
                    var rigisteredUser = new tblRegisteredUser();
                    Mapper.Map(registeredUserDto, rigisteredUser);
                    registeredUserContext.tblRegisteredUsers.Add(rigisteredUser);
                    result = registeredUserContext.SaveChanges();
                }
            }
            catch
            {
                return -1;
            }
            return result;
        }

        /// <summary>
        /// Checks for duplicate email address (User id)
        /// </summary>
        /// <param name="userEmailAddress"></param>
        /// <returns></returns>
        public bool isDuplicateUserEmailAddress(byte[] userEmailAddress)
        {            
            using (var dbContext = new FPUserProfileEntities())
            {
                IEnumerable<tblUserRegistrationRequest> list = dbContext.tblUserRegistrationRequests.Where(p => p.Id > 0);
                foreach (var item in list)
                {
                    if (Cryptography.Decrypt(item.UserEmail) == Cryptography.Decrypt(userEmailAddress))
                    {                        
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
