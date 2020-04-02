using AuroraProject.Controllers;
using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace AuroraProject.ViewModels
{
    public class WalletViewModel
    {
        public float Value { get; private set; }
        public string UserFullName { get; set; }
        public string PageName { get; set; }

        public WalletViewModel()
        {

        }

        public WalletViewModel(float value, string userFullName, string pageName)
        {
            Value = value;
            UserFullName = userFullName;
            PageName = pageName;
        }


    }
}