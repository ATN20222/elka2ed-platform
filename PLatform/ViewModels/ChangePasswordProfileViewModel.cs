using PLatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLatform.ViewModels
{
    public class ChangePasswordProfileViewModel
    {
        public ChangePasswordViewModel changePasswordViewModel { get; set; }

        public ApplicationUser applicationUser  { get; set; }
    }
}