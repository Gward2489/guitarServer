using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace guitarServer.Services
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        /*
            Note that each property here needs to exactly match the 
            name of each property in my appsettings.json config object
        */
        public string EbayKey { get; set;}
    }
}