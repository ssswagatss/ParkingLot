using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public abstract class Vehicle
    {
        public string VehicleNumber { get; set; }

        public Vehicle( string vnuum)
        {
            this.VehicleNumber = vnuum;
        }
    }
}
