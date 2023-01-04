using FluentAssertions;
using NetworkSpeedAPI.Models;
using NetworkSpeedAPI.Services;

namespace NetworkSpeedAPI.Tests
{
    public class NetworkSpeedControllerTest
    {
        private readonly INetworkSpeedService _service;

        private readonly List<Point> points = new()
        {
            new Point (0,0),
            new Point (3, 4),
            new Point (150,99)
        };

        private readonly double distance = 100;
        private readonly double reach = 20;

        public NetworkSpeedControllerTest()
        {
            _service = new NetworkSpeedService();
        }

        /// <summary>
        ///  Test GetDistanceBetween() method get distance in numeric between 2 points [x,y]
        /// </summary>
        [Fact]
        public void ShouldReturnDistance()
        {
            var result = _service.GetDistanceBetween(points[0], points[1]);

            result.Should().Be(5);
        }

        /// <summary>
        ///  Test GetBestNetworkStation() method when predefined network station is in reach
        /// </summary>
        [Fact]
        public void ShouldReturnNetworkStationAvailable()
        {
            var result = _service.GetBestNetworkStation(points[1]);

            result.Speed.Should().BeGreaterThan(0);
        }

        /// <summary>
        ///  Test GetBestNetworkStation() method when no predefined network station is in reach
        /// </summary>
        [Fact]
        public void ShouldReturnNetworkStationNotAvailable()
        {
            var result = _service.GetBestNetworkStation(points[2]);

            result.Speed.Should().Be(0);
        }

        /// <summary>
        /// Test GetSpeed() method when device is not in reach of station (distance > reach)
        /// </summary>
        [Fact]
        public void ShouldReturnNetworkStationSpeedNotInReach()
        {
            var result = _service.GetSpeed(distance, reach);

            result.Should().Be(0);
        }

        /// <summary>
        /// Test GetSpeed() method when device is in reach of station (distance < reach)
        /// </summary>
        [Fact]
        public void ShouldReturnNetworkStationSpeedInReach()
        {
            var result = _service.GetSpeed(distance - 90, reach);

            result.Should().BeGreaterThan(0);
        }
   }
}