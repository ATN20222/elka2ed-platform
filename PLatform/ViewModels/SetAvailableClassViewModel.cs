using PLatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLatform.ViewModels
{
    public class SetAvailableClassViewModel
    {
        public int ClassId { get; set; }    

        public bool IsAvailable { get; set; }
    }
}