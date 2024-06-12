namespace GeoApp.Domain
{
    public class AreaLine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TopLeftLatitude { get; set; }
        public double TopLeftLongitude { get; set; }
        public double TopRightLatitude { get; set; }
        public double TopRightLongitude { get; set; }
        public double BottomLeftLatitude { get; set; }
        public double BottomLeftLongitude { get; set; }
        public double BottomRightLatitude { get; set; }
        public double BottomRightLongitude { get; set; }
    }
}
