namespace parking_system
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingSystem
    {
        private readonly List<ParkingLot> _parkingLots;
        private readonly int _parkingRatePerHour = 10000;

        public ParkingSystem(int totalSlots)
        {
            _parkingLots = new List<ParkingLot>();
            for (int i = 1; i <= totalSlots; i++)
            {
                _parkingLots.Add(new ParkingLot(i));
            }

            Console.WriteLine($"Created a parking lot with {totalSlots} slots");
        }

        public void Park(string registrationNumber, string colour, string type)
        {
            var availableLot = _parkingLots.FirstOrDefault(lot => lot.IsAvailable());

            if (availableLot != null)
            {
                var vehicle = new Vehicle(registrationNumber, colour, type);
                availableLot.Park(vehicle);
                Console.WriteLine($"Allocated slot number: {availableLot.SlotNumber}");
            }
            else
            {
                Console.WriteLine("Sorry, parking lot is full");
            }
        }

        public void Leave(int slotNumber)
        {
            var lot = _parkingLots.FirstOrDefault(l => l.SlotNumber == slotNumber);
            if (lot != null && !lot.IsAvailable())
            {
                DateTime checkOutTime = DateTime.Now;
                TimeSpan duration = checkOutTime - lot.ParkedVehicle.CheckInTime;

                int totalHours = (int)duration.TotalHours;
                if (totalHours < 1)
                    totalHours = 1;
                int totalCost = totalHours * _parkingRatePerHour;

                Console.WriteLine($"Slot number {slotNumber} is free. Parking cost: {totalCost} IDR");
                lot.Leave();
            }
            else
            {
                Console.WriteLine($"Slot number {slotNumber} is already free");
            }
        }

        public void Status()
        {
            Console.WriteLine("Slot\tNo.\t\tType\t\tRegistration No\tColour");
            foreach (var lot in _parkingLots)
            {
                if (!lot.IsAvailable())
                {
                    var vehicle = lot.ParkedVehicle;
                    Console.WriteLine(
                        $"{lot.SlotNumber}\t{vehicle.RegistrationNumber}\t\t{vehicle.Type}\t\t{vehicle.RegistrationNumber}\t{vehicle.Colour}");
                }
            }
        }

        public void ReportAvailableSlots()
        {
            var availableSlots = _parkingLots.Count(lot => lot.IsAvailable());
            Console.WriteLine($"Available slots: {availableSlots}");
        }

        public void ReportFilledSlots()
        {
            var filledSlots = _parkingLots.Count(lot => !lot.IsAvailable());
            Console.WriteLine($"Filled slots: {filledSlots}");
        }

        public void TypeOfVehicles(string vehicleType)
        {
            var count = _parkingLots
                .Count(lot =>
                    !lot.IsAvailable() &&
                    lot.ParkedVehicle.Type.Equals(vehicleType, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine(count);
        }

        public void VehiclesWithOddRegistration()
        {
            var oddVehicles = _parkingLots
                .Where(lot => !lot.IsAvailable() && IsOddPlate(lot.ParkedVehicle.RegistrationNumber))
                .Select(lot => lot.ParkedVehicle.RegistrationNumber);

            Console.WriteLine(string.Join(", ", oddVehicles));
        }

        public void VehiclesWithEvenRegistration()
        {
            var evenVehicles = _parkingLots
                .Where(lot => !lot.IsAvailable() && !IsOddPlate(lot.ParkedVehicle.RegistrationNumber))
                .Select(lot => lot.ParkedVehicle.RegistrationNumber);

            Console.WriteLine(string.Join(", ", evenVehicles));
        }

        public void VehiclesByColour(string colour)
        {
            var vehicles = _parkingLots
                .Where(lot =>
                    !lot.IsAvailable() && lot.ParkedVehicle.Colour.Equals(colour, StringComparison.OrdinalIgnoreCase))
                .Select(lot => lot.ParkedVehicle.RegistrationNumber);

            Console.WriteLine(string.Join(", ", vehicles));
        }

        public void SlotsByColour(string colour)
        {
            var slots = _parkingLots
                .Where(lot =>
                    !lot.IsAvailable() && lot.ParkedVehicle.Colour.Equals(colour, StringComparison.OrdinalIgnoreCase))
                .Select(lot => lot.SlotNumber);

            Console.WriteLine(string.Join(", ", slots));
        }

        public void SlotByRegistration(string registrationNumber)
        {
            var lot = _parkingLots.FirstOrDefault(l =>
                !l.IsAvailable() &&
                l.ParkedVehicle.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));

            if (lot != null)
            {
                Console.WriteLine(lot.SlotNumber);
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }

        private bool IsOddPlate(string registrationNumber)
        {
            var lastDigit = registrationNumber.LastOrDefault(c => char.IsDigit(c));
            return lastDigit % 2 != 0;
        }
    }
}