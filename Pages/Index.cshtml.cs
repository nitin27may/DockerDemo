using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DockerDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IOptions<EnvironmentConfig> Configuration;
        public string ContainerId { get; set; }
        public string IpAddress { get; set; }
        public string ApplicationName { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IOptions<EnvironmentConfig> configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public void OnGet()
        {
            var appName = Configuration.Value.AppName;
            // ApplicationName = Environment.GetEnvironmentVariable("AppName");
            ApplicationName = appName;
            var name = Dns.GetHostName(); // get container id
            ContainerId = name;
            var ip = Dns.GetHostEntry(name).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
            IpAddress = Convert.ToString(ip);
        }
    }
}
