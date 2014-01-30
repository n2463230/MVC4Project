using AutoMapper;
using FundingPilotSystem.Domain.FPUserProfile;
using FundingPilotSystem.Domain.SolutionDto;
using FundingPilotSystem.Domain.SolutionUtilities;
using FundingPilotSystem.UnifiedDataStore.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FundingPilotSystem.UnifiedDataStore.DataProviders
{
    public class RegistrationProvider
    {
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
