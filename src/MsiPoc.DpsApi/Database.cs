using System;
using System.Collections.Generic;
using System.Net;
using MsiPoc.Abstractions;

namespace MsiPoc.DpsApi
{
    public static class Database
    {
        public static List<Device> Devices = new List<Device>
        {
            new Device
            {
                Id = "DeviceA",
                Name = "The device A"
            },
            new Device
            {
                Id = "DeviceB",
                Name = "The device B"
            },
            new Device
            {
                Id = "DeviceC",
                Name = "The device C"
            },
            new Device
            {
                Id = "DeviceD",
                Name = "The device D"
            }
        };

        public static List<Abstractions.Environment> Environments = new List<Abstractions.Environment>
        {
            new Abstractions.Environment
            {
                Name = "DEV",
                Uri = new Uri("https://api-dev.dps.com")
            },
            new Abstractions.Environment
            {
                Name = "QA",
                Uri = new Uri("https://api-qa.dps.com")
            },
            new Abstractions.Environment
            {
                Name = "PREPROD",
                Uri = new Uri("https://api-preprod.dps.com")
            },
            new Abstractions.Environment
            {
                Name = "PROD",
                Uri = new Uri("https://api.dps.com")
            }
        };
    }
}