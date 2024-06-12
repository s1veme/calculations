namespace GeoApp.Infrastructure.Repositories.User
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public Domain.User ToDomain()
        {
            return new Domain.User
            {
                ID = this.ID,
                Email = this.Email,
                Password = this.Password,
                PhoneNumber = this.PhoneNumber,
                Role = this.Role
            };
        }
    }
}
