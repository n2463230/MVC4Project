using FundingPilotSystem.Services.FPUserProfile.RegistrationService;
using FundingPilotSystem.VM.FPUserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundingPilotSystem.Services.FPMasterValues.MasterDataProviderService;
using FundingPilotSystem.Utilities;
using AutoMapper;
using UserRegistrationStatus = FundingPilotSystem.Domain.SolutionEnums.SolutionEnums.UserRegistrationStatus;
using FundingPilotSystem.Domain.SolutionUtilities;
namespace FundingPilotSystem.Areas.Registration.Controllers
{
    public class RegistrationController : Controller
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
            var userRegistration = new FundingPilotSystem.VM.FPUserProfile.UserRegistrationRequestsViewModel();
            userRegistration = BindModel(userRegistration);
            return View(userRegistration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(FundingPilotSystem.VM.FPUserProfile.UserRegistrationRequestsViewModel model)
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

                Mapper.CreateMap<FundingPilotSystem.VM.FPUserProfile.UserRegistrationRequestsViewModel, FundingPilotSystem.Services.FPUserProfile.RegistrationService.UserRegistrationRequestsViewModel>();
                var userRegistrationRequestServiceModel = new FundingPilotSystem.Services.FPUserProfile.RegistrationService.UserRegistrationRequestsViewModel();
                Mapper.Map(model, userRegistrationRequestServiceModel);
                int result = _registrationProcessService.SaveUserRegistrationRequest(userRegistrationRequestServiceModel);

            }
            model = BindModel(model);
            return View(model);
        }

        private List<Domain.SolutionDto.ModelMessage> PerformValidations(VM.FPUserProfile.UserRegistrationRequestsViewModel model)
        {
            if (String.IsNullOrEmpty(model.UserEmailAddress))
            {
                model.ModelMessage.Add(new Domain.SolutionDto.ModelMessage { Type = Domain.SolutionDto.MessageType.Error, Message = CustomLocalizationUtility.GetKeyValue("RegistrationProcess", "ValidationEmailisRequired") });
            }
            if (String.IsNullOrEmpty(model.Password))
            {
                model.ModelMessage.Add(new Domain.SolutionDto.ModelMessage { Type = Domain.SolutionDto.MessageType.Error, Message = CustomLocalizationUtility.GetKeyValue("RegistrationProcess", "ValidationPasswordIsRequired") });
            }
            if (model.CountryOfRegistration == 0 || model.CountryOfRegistration == -1)
            {
                model.ModelMessage.Add(new Domain.SolutionDto.ModelMessage { Type = Domain.SolutionDto.MessageType.Error, Message = CustomLocalizationUtility.GetKeyValue("RegistrationProcess", "ValidateCountryOfResidence") });
            }
            return model.ModelMessage;
        }
        private VM.FPUserProfile.UserRegistrationRequestsViewModel BindModel(VM.FPUserProfile.UserRegistrationRequestsViewModel userRegistration)
        {
            userRegistration.CountriesOfOperation = CommonUtility.GetCountriesOfOperation(_masterProviderService);
            return userRegistration;

        }
    }
}
