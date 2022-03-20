using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;
using LivingLab.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivingLab.UnitTests;

public class EnergyUsageRepoTest
{
    private readonly DbContextOptions<ApplicationDbContext> _contextOptions;
    private Lab testLab;
    private Device testDevice;
    #region Constructor
    public EnergyUsageRepoTest()
    {
        _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("EnergyUsageRepoTest")
            .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        using var context = new ApplicationDbContext(_contextOptions);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var deviceTask = context.Devices.FirstOrDefaultAsync();
        var labTask = context.Labs.FirstOrDefaultAsync();

        // Insert test log entry
        Task.WhenAll(deviceTask, labTask)
            .ContinueWith(_ => {
                testDevice = deviceTask.Result;
                testLab = labTask.Result;
            })
            .ContinueWith(_ => context.AddAsync(
                new EnergyUsageLog {
                    EnergyUsage = 25,
                    LoggedDate = DateTime.Now,
                    Device = testDevice,
                    Lab = testLab
                }
            ))
            .ContinueWith(_ => context.SaveChangesAsync())
            .Wait();
        

        // var getDeviceTask = context.Devices.ToListAsync();
        // getDeviceTask.Wait();
        // var deviceList = getDeviceTask.Result;

        // Console.WriteLine("Found " + deviceList.Count + " Devices");
        // foreach (var device in deviceList)
        // {
        //     Console.WriteLine("Fetched Device: " + device.DeviceSerialNumber);
        // }
    }
    #endregion

    [Fact]
    public async Task TestGetAllIncludesDevices()
    {
        using var context = CreateContext();
        var repo = new EnergyUsageRepository(context);

        var logs = await repo.GetAllAsync();
        if(logs.Count > 0) {
            Assert.NotNull(logs[0].Device);
        }
    }

    [Fact]
    public async Task TestGetByDeviceIdIncludesDevices()
    {
        using var context = CreateContext();
        var repo = new EnergyUsageRepository(context);

        var logs = await repo.GetUsageByDeviceId(testDevice.Id);
        if(logs.Count > 0) {
            Assert.NotNull(logs[0].Device);
        }
    }

    [Fact]
    public async Task TestGetByDeviceTypeIncludesDevices()
    {
        using var context = CreateContext();
        var repo = new EnergyUsageRepository(context);

        var logs = await repo.GetUsageByDeviceType(testDevice.Type);
        if(logs.Count > 0) {
            Assert.NotNull(logs[0].Device);
        }
    }

    [Fact]
    public async Task TestGetByLabIdIncludesLabs()
    {
        using var context = CreateContext();
        var repo = new EnergyUsageRepository(context);

        var logs = await repo.GetUsageByLabId(testLab.LabId);
        if(logs.Count > 0) {
            Assert.NotNull(logs[0].Lab);
        }
    }

    ApplicationDbContext CreateContext() => new ApplicationDbContext(_contextOptions);
}
