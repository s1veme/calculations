﻿namespace GeoApp.Domain
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}