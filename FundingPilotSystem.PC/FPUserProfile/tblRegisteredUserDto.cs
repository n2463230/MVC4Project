﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundingPilotSystem.Domain
{

    /// <summary>
    /// This class provides Dto for registered users
    /// </summary>
   public class tblRegisteredUserDto
    {
        public int Id { get; set; }
        public byte[] UserEmail { get; set; }
        public int CountryOfRegistration { get; set; }
        public bool NewsLetter { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public string RegistrationIP { get; set; }
        public System.DateTime ConfirmationDate { get; set; }
        //public byte[] ConfirmationIP { get; set; }
        public string ConfirmationIP { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string IPAddressOfLastAction { get; set; }
    }
}
