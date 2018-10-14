using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Car : Vehicle
    {
        public Car(string vnum):base(vnum)
        {
            //SpotsNeeded = 3;
            //Size = VehicleSize.Size.Compact;
        }
    }
}
