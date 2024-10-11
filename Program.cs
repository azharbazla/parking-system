using System;

namespace parking_system
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("      Selamat Datang di Sistem Parkir      ");
            Console.WriteLine("===========================================");
            Console.WriteLine("\nby  : Azhar Bazla");
            Console.WriteLine("Doc : github.com/azharbazla/parking-system/README.md\n\n");
            
            ParkingSystem parkingSystem = null;

            while (true)
            {
                var input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Invalid input, please try again.");
                    continue;
                }

                var commands = input.Split(' ');

                switch (commands[0])
                {
                    case ">":
                        break;
                    
                    case "create_parking_lot":
                        parkingSystem = new ParkingSystem(int.Parse(commands[1]));
                        break;

                    case "park":
                        if (parkingSystem != null)
                            parkingSystem.Park(commands[1], commands[2], commands[3]);
                        break;

                    case "leave":
                        if (parkingSystem != null)
                            parkingSystem.Leave(int.Parse(commands[1]));
                        break;

                    case "status":
                        if (parkingSystem != null)
                            parkingSystem.Status();
                        break;

                    case "report_available_slots":
                        if (parkingSystem != null)
                            parkingSystem.ReportAvailableSlots();
                        break;

                    case "report_filled_slots":
                        if (parkingSystem != null)
                            parkingSystem.ReportFilledSlots();
                        break;
                    
                    case "type_of_vehicles":
                        if (parkingSystem != null)
                            parkingSystem.TypeOfVehicles(commands[1]);
                        break;

                    case "registration_numbers_for_vehicles_with_odd_plate":
                        if (parkingSystem != null)
                            parkingSystem.VehiclesWithOddRegistration();
                        break;

                    case "registration_numbers_for_vehicles_with_even_plate":
                        if (parkingSystem != null)
                            parkingSystem.VehiclesWithEvenRegistration();
                        break;

                    case "registration_numbers_for_vehicles_with_colour":
                        if (parkingSystem != null)
                            parkingSystem.VehiclesByColour(commands[1]);
                        break;

                    case "slot_numbers_for_vehicles_with_colour":
                        if (parkingSystem != null)
                            parkingSystem.SlotsByColour(commands[1]);
                        break;

                    case "slot_number_for_registration_number":
                        if (parkingSystem != null)
                            parkingSystem.SlotByRegistration(commands[1]);
                        break;
                    
                    case "exit":
                        return;

                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }
    }
}