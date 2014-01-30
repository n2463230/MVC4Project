using AutoMapper;
using FundingPilotSystem.BLL.FPUserProfile.Registration;
using FundingPilotSystem.Domain.SolutionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FundingPilotSystem.VM.FPUserProfile;
using FundingPilotSystem.BO.FPUserProfile.Registration;
namespace FundingPilotSystem.Services.FPUserProfile
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Registration" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Registration.svc or Registration.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RegistrationService : IRegistrationServices
    {
        private RegistrationBusinessLogic _registrationBusinessLogic;
        private FPApplication FPApplication { get; set; }

        public void SetFPApplication(Domain.SolutionDto.FPApplication fpApplication)
        {
            this.FPApplication = fpApplication;
            this._registrationBusinessLogic = new RegistrationBusinessLogic();
        }
        /// <summary>
        /// Method to save user registraton
        /// </summary>
        /// <param name="userRegistrationRequest"></param>
        /// <returns></returns>
        public int SaveUserRegistrationRequest(UserRegistrationRequestsViewModel userRegistrationRequest)
        {
            Mapper.CreateMap<UserRegistrationRequestsViewModel, UserRegistrationRequestBusinessObject>();
            var userRegistrationRequestBusinessObject = new UserRegistrationRequestBusinessObject();
            Mapper.Map(userRegistrationRequest,  userRegistrationRequestBusinessObject);
            return _registrationBusinessLogic.SaveUserRegistrationRequest(userRegistrationRequestBusinessObject);
        }
    }
}
