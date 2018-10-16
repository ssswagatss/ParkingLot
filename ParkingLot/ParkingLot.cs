using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
