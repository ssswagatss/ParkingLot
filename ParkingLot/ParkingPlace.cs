using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingPlace
    {
        private static int NUMBER_OF_SMALL_SLOTS = 10;
        private static int NUMBER_OF_COMPACT_SLOTS = 10;
        private static int NUMBER_OF_LARGE_SLOTS = 10;
        public Dictionary<long, Slot> occupiedSlots;
        private List<Slot> smallSlots;
        private List<Slot> compactSlots;
        private List<Slot> largeSlots;

        public ParkingPlace()
        {
            smallSlots = new List<Slot>(NUMBER_OF_SMALL_SLOTS);
            compactSlots = new List<Slot>(NUMBER_OF_COMPACT_SLOTS);
            largeSlots = new List<Slot>(NUMBER_OF_LARGE_SLOTS);
            CreateSlots();
            occupiedSlots = new Dictionary<long, Slot>();
        }

        private void CreateSlots()
        {

            for (int i = 1; i <= NUMBER_OF_SMALL_SLOTS; i++)
            {
                smallSlots.Add(new SmallSlot(i));
            }
            for (int i = 1; i <= NUMBER_OF_COMPACT_SLOTS; i++)
            {
                compactSlots.Add(new CompactSlot(i));
            }
            for (int i = 1; i <= NUMBER_OF_LARGE_SLOTS; i++)
            {
                largeSlots.Add(new LargeSlot(i));
            }

        }

        public long Park(Vehicle vehicle)
        {

            Slot slot;
            long uniqueToken = -1;

            if (vehicle.GetType() == typeof(MotorCycle)) {
                if ((slot = GetFirstEmptySlot(smallSlots)) != null)
                {
                    uniqueToken = parkHelper(slot, vehicle);
                }
                else if ((slot = GetFirstEmptySlot(compactSlots)) != null)
                {
                    uniqueToken = parkHelper(slot, vehicle);
                }
                else if ((slot = GetFirstEmptySlot(largeSlots)) != null)
                {
                    uniqueToken = parkHelper(slot, vehicle);
                }
            } else if (vehicle.GetType() == typeof(Car)) {
                if ((slot = GetFirstEmptySlot(compactSlots)) != null)
                {
                    uniqueToken = parkHelper(slot, vehicle);
                }
                else if ((slot = GetFirstEmptySlot(largeSlots)) != null)
                {
                    uniqueToken = parkHelper(slot, vehicle);
                }
            } else {
                if ((slot = GetFirstEmptySlot(largeSlots)) != null)
                {
                    uniqueToken = parkHelper(slot, vehicle);
                }
            }
            return uniqueToken;
        }

        public void UnPark(long uniqueToken)
        {
            occupiedSlots.First(x=>x.Key == uniqueToken).Value.UnPark();
            occupiedSlots.Remove(uniqueToken);
        }

        private Slot GetFirstEmptySlot(List<Slot> slots)
        {
            bool isSlotFound = false;
            Slot emptySlot = null;

            for (int i = 0; i < slots.Count -1 ; i++)
            {
                if (!isSlotFound)
                {
                    emptySlot = slots.ElementAt(i+1);
                    if (!emptySlot.IsOccupied())
                    {
                        isSlotFound = true;
                        break;
                    }
                }
            }
            return emptySlot;
        }

        private long parkHelper(Slot slot, Vehicle vehicle)
        {
            slot.Park();
            long uniqueToken = vehicle.GetHashCode() * 43;
            occupiedSlots.Add(uniqueToken, slot);
            return uniqueToken;
        }
    }
}
