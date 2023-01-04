namespace NetworkSpeedAPI.Models
{
    public class NetworkStation
    {
        public Point Point { get; set; }
        public int Reach { get; set; }
        public double Speed { get; set; }
    }

    public class NetworkStations
    {
        public IList<string> Result { get; set; } = new List<string>();
    }
}