using System;
using System.Collections.Generic;
using System.Net;

namespace MsiPoc.DpsApi
{
    public class Device
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Redirection Redirection { get; set; }
    }

    public class Redirection
    {
        public HttpStatusCode Code { get; set; }
        public Uri Endpoint { get; set; }
    }

    public class Environment
    {
        public string Name { get; set; }
        public Uri Uri { get; set; }
    }

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

        public static List<Environment> Environments = new List<Environment>
        {
            new Environment
            {
                Name = "DEV",
                Uri = new Uri("https://api-dev.dps.com")
            },
            new Environment
            {
                Name = "QA",
                Uri = new Uri("https://api-qa.dps.com")
            },
            new Environment
            {
                Name = "PREPROD",
                Uri = new Uri("https://api-preprod.dps.com")
            },
            new Environment
            {
                Name = "PROD",
                Uri = new Uri("https://api.dps.com")
            }
        };
    }
}