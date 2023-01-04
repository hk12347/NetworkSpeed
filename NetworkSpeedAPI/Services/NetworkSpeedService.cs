using NetworkSpeedAPI.Models;

namespace NetworkSpeedAPI.Services
{
    #region "Interface"
    public interface INetworkSpeedService
    {
        /// <summary>
        /// Get the best network station for given coordinate point [x,y] from predefined stations
        /// </summary>
        NetworkStation GetBestNetworkStation(Point point);

        /// <summary>
        ///  Get the distance between 2 points [x,y]
        /// </summary>
        Double GetDistanceBetween(Point from, Point to);

        /// <summary>
        ///  Get the speed of the network station to given distance
        /// </summary>
        Double GetSpeed(double distance, double reach);
    }
    #endregion

    public class NetworkSpeedService : INetworkSpeedService
    {
        public  NetworkStation GetBestNetworkStation(Point point)
        {
            // Predefined stations
            List<NetworkStation> stations = new()
            {
                new NetworkStation {Point = new Point(0, 0),   Reach = 9},
                new NetworkStation {Point = new Point(20, 20), Reach = 6},
                new NetworkStation {Point = new Point(10, 0),  Reach = 12},
                new NetworkStation {Point = new Point(5, 5),   Reach = 13},
                new NetworkStation {Point = new Point(99, 25), Reach = 2}
            };

            NetworkStation bestStation = new();

            foreach (NetworkStation station in stations)
            {
                var speed = GetSpeed(
                            GetDistanceBetween(station.Point, point),
                                               station.Reach);

                if (speed > bestStation.Speed)
                {
                    bestStation = station;
                    bestStation.Speed = speed;
                }
            }
            return bestStation;
        }

        public double GetDistanceBetween(Point from, Point to)
        {
            return Math.Sqrt(Math.Pow(from.x - to.x, 2) +
                             Math.Pow(from.y - to.y, 2));
        }

        public double GetSpeed(double distance, double reach)
        {
            return (distance > reach)
                ? 0
                : Math.Pow(reach - distance, 2);
        }
    }
}
