using FundingPilotSystem.Services.RegistrationService;
using FundingPilotSystem.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundingPilotSystem.Services.MasterDataProviderService;
using FundingPilotSystem.Utilities;
using AutoMapper;
using UserRegistrationStatus = FundingPilotSystem.Common.SolutionEnums.UserRegistrationStatus;
using ModelMessage = FundingPilotSystem.Common.ModelMessage;
using MessageType = FundingPilotSystem.Common.MessageType;
using FundingPilotSystem.Common;
using FundingPilotSystem.Controllers;

namespace FundingPilotSystem.Areas.Registration.Controllers
{
    public class RegistrationController : BaseController
    {
        private IRegistrationServices _registrationProcessService;
        private IMasterDataProviderService _masterProviderService;

        public RegistrationController()
        {
            this._masterProviderService = ServiceReferences.GetMasterProviderServiceClient();
            this._registrationProcessService = ServiceReferences.GetRegistrationProcessClient();
        }
        public RegistrationController(IMasterDataProviderService masterProviderService,
                                                IRegistrationServices registrationProviderService)
        {
            this._masterProviderService = masterProviderService;
            this._registrationProcessService = registrationProviderService;
        }
        //
        // GET: /RegistrationProcess/Registration/
        [HttpGet]
        public ActionResult Register()
        {
            var userRegistration = new FundingPilotSystem.VM.UserRegistrationRequestsViewModel();
            userRegistration = BindModel(userRegistration);
            return View(userRegistration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(FundingPilotSystem.VM.UserRegistrationRequestsViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.ModelMessage = PerformValidations(model);

                if (model.ModelMessage.Count > 0)
                {
                    model = BindModel(model);
                    return View(model);
                }
                model.RegistrationDate = DateTime.Now;
                model.RegistrationIP = Request.ServerVariables["REMOTE_ADDR"];
                model.UserStatus = (int)UserRegistrationStatus.InProgress;
                model.UserEmail = Cryptography.Encrypt(model.UserEmailAddress);
                model.LoginPassword = Cryptography.Encrypt(model.Password);

                ////TODO:Check Problem
                //Mapper.CreateMap<FundingPilotSystem.VM.UserRegistrationRequestsViewModel, FundingPilotSystem.Services.RegistrationService.UserRegistrationRequestsViewModel>();
                //var userRegistrationRequestServiceModel = new FundingPilotSystem.Services.RegistrationService.UserRegistrationRequestsViewModel();
                //Mapper.Map(model, userRegistrationRequestServiceModel);
                //int result = _registrationProcessService.SaveUserRegistrationRequest(userRegistrationRequestServiceModel);
                int result = 0;
                if(result > 0)
                {
                    model.ModelMessage.Add(new Common.ModelMessage { Type =MessageType.Success, Message = CustomLocalizationUtility.GetKeyValue("RegistrationProcess", "MessageRegistrationDone") });
                    model.Id = result;
                    //TODO : Add the mail request in the process table to send the mail of the registration request

                }

            }
            model = BindModel(model);
            return View(model);
        }

        private List<Common.ModelMessage> PerformValidations(VM.UserRegistrationRequestsViewModel model)
        {
            if (String.IsNullOrEmpty(model.UserEmailAddress))
            {
                model.ModelMessage.Add(new ModelMessage { Type = MessageType.Error, Message = CustomLocalizationUtility.GetKeyValue("RegistrationProcess", "ValidationEmailisRequired") });
            }
            if (String.IsNullOrEmpty(model.Password))
            {
                model.ModelMessage.Add(new ModelMessage { Type = MessageType.Error, Message = CustomLocalizationUtility.GetKeyValue("RegistrationProcess", "ValidationPasswordIsRequired") });
            }
            if (model.CountryOfRegistration == 0 || model.CountryOfRegistration == -1)
            {
                model.ModelMessage.Add(new ModelMessage { Type =MessageType.Error, Message = CustomLocalizationUtility.GetKeyValue("RegistrationProcess", "ValidateCountryOfResidence") });
            }
            if (_registrationProcessService.isDuplicateUserEmailAddress(Cryptography.Encrypt(model.UserEmailAddress)))
            {
                model.ModelMessage.Add(new ModelMessage { Type =MessageType.Error, Message = CustomLocalizationUtility.GetKeyValue("RegistrationProcess", "ValidationEmailAddressRequestedForRegistration") });
            }
            return model.ModelMessage;
        }
        /// <summary>
        /// bind the controller model
        /// </summary>
        /// <param name="userRegistration"></param>
        /// <returns></returns>
        private VM.UserRegistrationRequestsViewModel BindModel(VM.UserRegistrationRequestsViewModel userRegistration)
        {
            userRegistration.CountriesOfOperation = CommonUtility.GetCountriesOfOperation(_masterProviderService);
            userRegistration.AlertModel = new AlertModel
            {
                WindowTitle = CustomLocalizationUtility.GetKeyValue("RegistrationProcess", "TitleEmailConfirmation"),
                WindowBody = CustomLocalizationUtility.GetKeyValue("RegistrationProcess", "MessageEmailConfirmation"),
                OkButtonText = CustomLocalizationUtility.GetKeyValue("RegistrationProcess", "ConfirmButtonTextEmailConfirmation"),
                CloseButtonText = CustomLocalizationUtility.GetKeyValue("RegistrationProcess", "CloseButtonTextEmailConfirmation"),

            };
            return userRegistration;

        }
    }
}
