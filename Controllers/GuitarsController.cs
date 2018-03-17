using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using guitarServer.Classes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters.Json;
using guitarServer.Services;

namespace guitarServer.Controllers
{
    [Route("api/[controller]")]

    public class GuitarsController : Controller
    {
        
        private readonly IApplicationConfiguration _appSettings;

        public GuitarsController(IApplicationConfiguration appSettings)
        {   
            _appSettings = appSettings;
        }

        [HttpGet("{searchParams}")]
        public async Task<IActionResult> GetAsync(string searchParams)
        {
            
        string searchString = _appSettings.EbayKey;
        Console.WriteLine(_appSettings);
        Console.WriteLine(_appSettings.EbayKey);

        searchString += searchParams;            
        string results = await GetEbay.GetGuitarsAsync(searchString);
        Console.WriteLine(results);
        return Ok (results);
        }

        [HttpGet("{urlFirstHalf}/{urlSecondHalf}")]
        public async Task<IActionResult> GetResultsAsync(string urlFirstHalf, string urlSecondHalf)
        {

            string searchUrl = urlFirstHalf + _appSettings.EbayKey + urlSecondHalf;
            string results = await GetEbay.GetGuitarsAsync(searchUrl);
            Console.WriteLine(results);
            return Ok (results);
        }

   
    }
}