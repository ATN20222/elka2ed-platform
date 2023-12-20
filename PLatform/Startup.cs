using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using PLatform.Models;
using System.Net;
using System;

[assembly: OwinStartupAttribute(typeof(PLatform.Startup))]
namespace PLatform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            
            ConfigureAuth(app);
        }



    }
}
