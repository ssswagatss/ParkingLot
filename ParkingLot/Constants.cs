using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Constants
    {
        public static int[] allFloors = CreateList(10);
        public static int[] allSpots = CreateList(50);

        private static int[] CreateList(int range)
        {
            int[] array = new int[range];
            for(int i=0; i<range; i++)
            {
                array[i] = i;
            }
            return array;
        }

        public static int[] AllFloors { get; set; } = allFloors;
    }
}
