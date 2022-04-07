using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;

using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.UIServices.EnergyUsage;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.EnergyUsage;

/// <remarks>
/// Author: Team P1-2
/// </remarks>
[Authorize(Roles = "Labtech")]
public class EnergyUsageComparisonController : Controller
{
    private readonly ILogger<EnergyUsageComparisonController> _logger;
    private readonly IEnergyUsageComparisonUIService _comparisonService;

    public EnergyUsageComparisonController(ILogger<EnergyUsageComparisonController> logger,
        IEnergyUsageComparisonUIService comparisonService)
    {
        _logger = logger;
        _comparisonService = comparisonService;
    }

    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    ///     Retrieve lab energy usage according to the labName, start and end date
    /// </summary>
    /// <param>list of lab names</param>
    /// <param>start date</param>
    /// <param>end date</param>
    /// <returns>list of Dictionary Object</returns>
    [HttpPost]
    public List<Dictionary<string, object>> GetLabEnergyUsageDetailTable(string listOfLabName, string start, string end)
    {
        var startDate = Regex.Replace(start, @"[^^a-zA-Z0-9 -]+", String.Empty);
        var endDate = Regex.Replace(end, @"[^^a-zA-Z0-9 -]+", String.Empty);

        var sDate = Convert.ToDateTime(startDate);
        var eDate = Convert.ToDateTime(endDate);
        var compareFactorArray = listOfLabName.Split(",");

        var listNumber = new List<string>();

        var iData = new List<Dictionary<string, object>>();
        //Creating sample data  
        var dt = new DataTable();
        dt.Columns.Add("labLocation", Type.GetType("System.String"));
        dt.Columns.Add("energyUsage", Type.GetType("System.Double"));
        dt.Columns.Add("energyUsageCost", Type.GetType("System.Double"));
        dt.Columns.Add("energyIntensity", Type.GetType("System.Double"));

        var dr = dt.NewRow();

        for (var i = 0; i < compareFactorArray.Length; i++)
        {
            compareFactorArray[i] = Regex.Replace(compareFactorArray[i], @"[^^a-zA-Z0-9 -]+", String.Empty);
            var data = _comparisonService.GetEnergyUsageByLabNameTable(compareFactorArray[i], sDate, eDate);

            if (i == 0)
            {
                dr["labLocation"] = compareFactorArray[i];
                dr["energyUsage"] = data[0].TotalEnergyUsage;
                dr["energyUsageCost"] = data[0].EnergyUsageCost;
                dr["energyIntensity"] = data[0].EnergyUsageIntensity;
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr["labLocation"] = compareFactorArray[i];
                dr["energyUsage"] = data[0].TotalEnergyUsage;
                dr["energyUsageCost"] = data[0].EnergyUsageCost;
                dr["energyIntensity"] = data[0].EnergyUsageIntensity;
                dt.Rows.Add(dr);
            }
        }

        foreach (DataRow dr1 in dt.Rows)
        {
            var drow = new Dictionary<string, object>();
            for (var i = 0; i < dt.Columns.Count; i++)
            {
                drow.Add(dt.Columns[i].ColumnName, dr1[i]);
            }

            iData.Add(drow);
        }

        return iData;
    }

    /// <summary>
    ///     Retrieve lab energy usage according to the labName, start and end date
    /// </summary>
    /// <param>list of lab names</param>
    /// <param>start date</param>
    /// <param>end date</param>
    /// <returns>list of Object in JSON format</returns>
    [HttpPost]
    public JsonResult GetLabEnergyUsageDetailGraph(string listOfLabName, string start, string end)
    {
        var startDate = Regex.Replace(start, @"[^^a-zA-Z0-9 -]+", String.Empty);
        var endDate = Regex.Replace(end, @"[^^a-zA-Z0-9 -]+", String.Empty);

        var sDate = Convert.ToDateTime(startDate);
        var eDate = Convert.ToDateTime(endDate);

        var compareType = "Lab";
        var compareFactorArray = listOfLabName.Split(",");

        var iData = new List<object>();
        var dt = new DataTable();
        dt.Columns.Add(compareType, Type.GetType("System.String"));
        dt.Columns.Add("Energy Usage", Type.GetType("System.Double"));
        dt.Columns.Add("Energy Intensity", Type.GetType("System.Double"));
        dt.Columns.Add("Benchmark", Type.GetType("System.Int32")); //for energy usage

        var dr = dt.NewRow();

        for (var i = 0; i < compareFactorArray.Length; i++)
        {
            compareFactorArray[i] = Regex.Replace(compareFactorArray[i], @"[^^a-zA-Z0-9 -]+", String.Empty);
        }

        var benchmark = _comparisonService.GetEnergyUsageByLabNameBenchmark(compareFactorArray, sDate, eDate);

        for (var i = 0; i < compareFactorArray.Length; i++)
        {
            var data = _comparisonService.GetEnergyUsageByLabNameGraph(compareFactorArray[i], sDate, eDate);


            if (i == 0)
            {
                dr[compareType] = compareFactorArray[i];
                dr["Energy Usage"] = data[0].TotalEnergyUsage;
                dr["Energy Intensity"] = data[0].EnergyUsageIntensity;
                dr["Benchmark"] = benchmark;
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[compareType] = compareFactorArray[i];
                dr["Energy Usage"] = data[0].TotalEnergyUsage;
                dr["Energy Intensity"] = data[0].EnergyUsageIntensity;
                dr["Benchmark"] = benchmark;
                dt.Rows.Add(dr);
            }
        }

        foreach (DataColumn dc in dt.Columns)
        {
            var x = new List<object>();
            x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
            iData.Add(x);
        }

        return Json(iData);
    }

    // <summary>
    /// Retrieve device energy usage according to the deviceType, start and end date
    /// </summary>
    /// <param>list of devices type</param>
    /// <param>start date</param>
    /// <param>end date</param>
    /// <returns>list of Dictionary Object</returns>
    [HttpPost]
    public List<Dictionary<string, object>> GetDeviceEnergy(string listOfDeviceType, string start, string end)
    {
        var startDate = Regex.Replace(start, @"[^^a-zA-Z0-9 -]+", String.Empty);
        var endDate = Regex.Replace(end, @"[^^a-zA-Z0-9 -]+", String.Empty);

        var sDate = Convert.ToDateTime(startDate);
        var eDate = Convert.ToDateTime(endDate);
        var compareFactorArray = listOfDeviceType.Split(",");

        var listNumber = new List<string>();

        var iData = new List<Dictionary<string, object>>();
        //Creating sample data  
        var dt = new DataTable();
        dt.Columns.Add("deviceType", Type.GetType("System.String"));
        dt.Columns.Add("energyUsage", Type.GetType("System.Double"));
        dt.Columns.Add("energyUsageCost", Type.GetType("System.Double"));

        var dr = dt.NewRow();

        for (var i = 0; i < compareFactorArray.Length; i++)
        {
            compareFactorArray[i] = Regex.Replace(compareFactorArray[i], @"[^^a-zA-Z0-9 -]+", String.Empty);

            var data = _comparisonService.GetEnergyUsageByDeviceType(compareFactorArray[i], sDate, eDate);

            if (i == 0)
            {
                dr["deviceType"] = compareFactorArray[i];
                dr["energyUsage"] = data[0].TotalEnergyUsage;
                dr["energyUsageCost"] = data[0].EnergyUsageCost;
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr["deviceType"] = compareFactorArray[i];
                dr["energyUsage"] = data[0].TotalEnergyUsage;
                dr["energyUsageCost"] = data[0].EnergyUsageCost;
                dt.Rows.Add(dr);
            }
        }

        foreach (DataRow dr1 in dt.Rows)
        {
            var drow = new Dictionary<string, object>();
            for (var i = 0; i < dt.Columns.Count; i++)
            {
                drow.Add(dt.Columns[i].ColumnName, dr1[i]);
            }

            iData.Add(drow);
        }


        return iData;
    }

    /// <summary>
    ///     Retrieve list of lab name or device types based on the compare type
    /// </summary>
    /// <param>type</param>
    /// <returns>array list</returns>
    [HttpGet]
    public string[] GetLabLocationOrDeviceType(string type)
    {
        if (type == "DeviceType")
        {
            var device = _comparisonService.GetAllDeviceType();
            var array = device.ToArray();
            return array;
        }
        else
        {
            var location = _comparisonService.GetAllLabLocation();
            var array = location.ToArray();
            return array;
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
