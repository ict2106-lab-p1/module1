using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LivingLab.Core.Interfaces.Services;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers
{
    public class ManualLogExampleController : Controller
    {
        private readonly IEnergyUsageLogCsvParser _csvParser;

        public ManualLogExampleController(IEnergyUsageLogCsvParser csvParser)
        {
            _csvParser = csvParser;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            var result = _csvParser.Parse(file).ToList();
            return View(nameof(Index), result);
        }

        [HttpPost]
        public IActionResult Save()
        {
            // TODO: save to database
            return View(nameof(Index));
        }
    }
}
