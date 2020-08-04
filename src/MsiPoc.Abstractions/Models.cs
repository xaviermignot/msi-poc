using System;
using System.Net;

namespace MsiPoc.Abstractions
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
}