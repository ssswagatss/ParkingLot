using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingLot
    {
        private static int NUMBER_OF_Floors = 2;
        public List<ParkingFloor> ParkingFloors { get; set; }

        public ParkingLot()
        {
            CreateFloors();
        }

        private void CreateFloors()
        {
            ParkingFloors = new List<ParkingFloor>();
            for (int i = 1; i <= NUMBER_OF_Floors; i++)
            {
                ParkingFloors.Add(new ParkingFloor(i));
            }
        }

        public ParkingFloor GetEmptyFloor(VehicleType type)
        {
            return this.ParkingFloors.FirstOrDefault(x => x.GetAvailableSlot(type) != null);
        }
        public void UnPark(string vehicleNumber)
        {
            for (int i = 0; i < this.ParkingFloors.Count; i++)
            {
                if (this.ParkingFloors.ElementAt(i).occupiedSlots.Any(y => y.Key.ToUpper() == vehicleNumber.ToUpper()))
                {
                    var key = this.ParkingFloors.ElementAt(i).occupiedSlots.First(y => y.Key.ToUpper() == vehicleNumber.ToUpper()).Key;
                    this.ParkingFloors.ElementAt(i).occupiedSlots.Remove(key);
                }
            }
        }

    }
}
