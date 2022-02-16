using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using LivingLab.Core.Interfaces.Services;
using LivingLab.Core.Models;
using LivingLab.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers
{
    public class ManualLogExampleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEnergyUsageLogCsvParser _csvParser;

        public ManualLogExampleController(IMapper mapper, IEnergyUsageLogCsvParser csvParser)
        {
            _mapper = mapper;
            _csvParser = csvParser;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            var logs = _csvParser.Parse(file).ToList();
            var logItemsViewModel = _mapper.Map<List<EnergyUsageCsvModel>, List<LogItemViewModel>>(logs);
            return View(nameof(Index), logItemsViewModel);
        }

        [HttpPost]
        public IActionResult Save()
        {
            // TODO: save to database
            return View(nameof(Index));
        }
    }
}
