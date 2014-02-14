using AutoMapper;
using FundingPilotSystem.BLL;
using FundingPilotSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FundingPilotSystem.VM;
using FundingPilotSystem.BO;

namespace FundingPilotSystem.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Registration" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Registration.svc or Registration.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RegistrationService : IRegistrationServices
    {
        private RegistrationBLL _registrationBusinessLogic;
        private FPApplication FPApplication { get; set; }

        public void SetFPApplication(Common.FPApplication fpApplication)
        {
            this.FPApplication = fpApplication;
            this._registrationBusinessLogic = new RegistrationBLL();
        }
        /// <summary>
        /// Method to save user registraton
        /// </summary>
        /// <param name="userRegistrationRequest"></param>
        /// <returns></returns>
        public int SaveUserRegistrationRequest(UserRegistrationRequestsViewModel userRegistrationRequest)
        {
            Mapper.CreateMap<UserRegistrationRequestsViewModel, UserRegistrationRequestBO>();
            var userRegistrationRequestBusinessObject = new UserRegistrationRequestBO();
            Mapper.Map(userRegistrationRequest,  userRegistrationRequestBusinessObject);
            return _registrationBusinessLogic.SaveUserRegistrationRequest(userRegistrationRequestBusinessObject);
        }

        /// <summary>
        /// Method checking whether the emailaddress entered during registration request is not duplicate
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public bool isDuplicateUserEmailAddress(byte[] emailAddress)
        {
            return _registrationBusinessLogic.isDuplicateUserEmailAddress(emailAddress);
        }
    }
}
