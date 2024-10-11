using System;

namespace parking_system
{
    public class Vehicle
    {
        public string RegistrationNumber { get; }
        public string Colour { get; }
        public string Type { get; }
        public DateTime CheckInTime { get; set; }

        public Vehicle(string registrationNumber, string colour, string type)
        {
            RegistrationNumber = registrationNumber;
            Colour = colour;
            Type = type;
            CheckInTime = DateTime.Now;
        }
    }
}