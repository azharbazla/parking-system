namespace parking_system
{
    public class ParkingLot
    {
        public int SlotNumber { get; }
        public Vehicle ParkedVehicle { get; set; }
    
        public ParkingLot(int slotNumber)
        {
            SlotNumber = slotNumber;
            ParkedVehicle = null;
        }

        public bool IsAvailable()
        {
            return ParkedVehicle == null;
        }
    
        public void Park(Vehicle vehicle)
        {
            ParkedVehicle = vehicle;
        }

        public void Leave()
        {
            ParkedVehicle = null;
        }
    }
}