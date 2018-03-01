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
using guitarServer.Interfaces;

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
            
        string results = await GetEbay.GetGuitarsAsync(searchString);
        Console.WriteLine(results);
        return Ok (results);
        }


        
    }
}