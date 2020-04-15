using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuroraProject.Core.Models;


namespace AuroraProject.Core.ViewModels
{
    public class UserDetailsViewModel
    {
        public string UserFullName { get; set; }
        public UserDetailsViewModel()
        {

        }
        public UserDetailsViewModel(string userFullName)
        {
            UserFullName = userFullName;
        }
    }
}