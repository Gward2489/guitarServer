using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using guitarServer.Classes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters.Json;


namespace guitarServer.Controllers
{
    [Route("api/[controller]")]

    public class GuitarsController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            
        string results = await GetEbay.GetGuitarsAsync("http://svcs.ebay.com/services/search/FindingService/v1?OPERATION-NAME=findCompletedItems&SERVICE-VERSION=1.7.0&SECURITY-APPNAME=GarrettW-KellyBlu-PRD-e132041a0-8df2cdd9&RESPONSE-DATA-FORMAT=XML&categoryId(0)=33034&categoryId(1)=33021&categoryId(2)=4713&itemFilter(0).name=SoldItemsOnly&itemFilter(0).value(0)=true&itemFilter(1).name=Condition&itemFilter(1).value(0)=Used&itemFilter(1).value(1)=2500&itemFilter(1).value(2)=3000&itemFilter(1).value(3)=4000&itemFilter(1).value(4)=5000&itemFilter(1).value(5)=6000&itemFilter(2).name=ExcludeCategory&itemFilter(2).value(0)=181223&itemFilter(2).value(1)=47067&REST-PAYLOAD&keywords=gibson+les+paul");
        Console.WriteLine(results);
        return Ok (results);
        }


        
    }
}