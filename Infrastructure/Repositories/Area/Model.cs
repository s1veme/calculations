namespace GeoApp.Infrastructure.Repositories.Area
{
    public class AreaModel
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

        public Domain.Area ToDomain()
        {
            return new Domain.Area
            {
                Id = this.Id,
                Name = this.Name,
                TopLeftLatitude = this.TopLeftLatitude,
                TopLeftLongitude = this.TopLeftLongitude,
                TopRightLatitude = this.TopRightLatitude,
                TopRightLongitude = this.TopRightLongitude,
                BottomLeftLatitude = this.BottomLeftLatitude,
                BottomLeftLongitude = this.BottomLeftLongitude,
                BottomRightLatitude = this.BottomRightLatitude,
                BottomRightLongitude = this.BottomRightLongitude
            };
        }
    }
}
