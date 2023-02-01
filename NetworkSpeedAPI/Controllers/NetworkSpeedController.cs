using Microsoft.AspNetCore.Mvc;
using NetworkSpeedAPI.Services;
using NetworkSpeedAPI.Models;

namespace NetworkSpeedAPI.Controllers
{
    [ApiController]
    [Route("/")]

    public class NetworkSpeedController : ControllerBase
    {
        private readonly INetworkSpeedService _service;
        private readonly ILogger<NetworkSpeedController> _logger;

        public NetworkSpeedController (INetworkSpeedService networkSpeedService, ILogger<NetworkSpeedController> logger)
        {
            _service = networkSpeedService;
            _logger = logger;
        }

        /// <summary>
        /// Print out the most suitable network station and the network speed from devices [x,y]
        /// </summary>
        [Route("GetNetworkSpeed")]
        [HttpGet]
        public NetworkStations GetNetworkSpeed()
        {
            // Points to test
            List<Point> devicePoints = new()
            {
                new Point (0, 0),
                new Point (100,100),
                new Point (15, 10),
                new Point (18, 18),
                new Point (13, 13),
                new Point (25, 99)
            };

            var stations = new NetworkStations();

            foreach (Point device in devicePoints)
            {
                var station = _service.GetBestNetworkStation(device);

                stations.Result.Add(
                    station.Speed != 0 
                    ? "Best network station for point " + device.x + "," + device.y + " is "
                    + station.Point.x + "," + station.Point.y + " with speed " + station.Speed.ToString("n2")
                    : "No link station within reach for point " + device.x + "," + device.y
                    );
            }
            return stations;
        }
    }
}