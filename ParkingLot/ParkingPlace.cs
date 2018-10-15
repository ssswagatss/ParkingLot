using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingPlace
    {
        private static int NUMBER_OF_SMALL_SLOTS = 2;
        private static int NUMBER_OF_COMPACT_SLOTS = 2;
        private static int NUMBER_OF_LARGE_SLOTS = 2;
        public Dictionary<string, Slot> occupiedSlots;
        private List<Slot> smallSlots;
        private List<Slot> compactSlots;
        private List<Slot> largeSlots;

        public ParkingPlace()
        {
            smallSlots = new List<Slot>(NUMBER_OF_SMALL_SLOTS);
            compactSlots = new List<Slot>(NUMBER_OF_COMPACT_SLOTS);
            largeSlots = new List<Slot>(NUMBER_OF_LARGE_SLOTS);
            CreateSlots();
            occupiedSlots = new Dictionary<string, Slot>();
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

        public Tuple<string, long> Park(Vehicle vehicle)
        {
            Slot slot;
            Tuple<string, long> vehicleAndSlot = null;

            if (vehicle.GetType() == typeof(MotorCycle))
            {
                if ((slot = GetFirstEmptySlot(smallSlots)) != null)
                {
                    vehicleAndSlot = parkHelper(slot, vehicle,smallSlots);
                }
                else if ((slot = GetFirstEmptySlot(compactSlots)) != null)
                {
                    vehicleAndSlot = parkHelper(slot, vehicle, compactSlots);
                }
                else if ((slot = GetFirstEmptySlot(largeSlots)) != null)
                {
                    vehicleAndSlot = parkHelper(slot, vehicle, largeSlots);
                }
            }
            else if (vehicle.GetType() == typeof(Car))
            {
                if ((slot = GetFirstEmptySlot(compactSlots)) != null)
                {
                    vehicleAndSlot = parkHelper(slot, vehicle, compactSlots);
                }
                else if ((slot = GetFirstEmptySlot(largeSlots)) != null)
                {
                    vehicleAndSlot = parkHelper(slot, vehicle, largeSlots);
                }
            }
            else
            {
                if ((slot = GetFirstEmptySlot(largeSlots)) != null)
                {
                    vehicleAndSlot = parkHelper(slot, vehicle, largeSlots);
                }
            }
            return vehicleAndSlot;
        }

        public void UnPark(string vehicleNumber)
        {
            occupiedSlots.First(x => x.Key == vehicleNumber).Value.UnPark();
            occupiedSlots.Remove(vehicleNumber);
        }

        private Slot GetFirstEmptySlot(List<Slot> slots)
        {
            Slot emptySlot = null;

            for (int i = 0; i < slots.Count; i++)
            {
                Slot slot = slots[i];

                if (!slot.IsOccupied())
                {
                    //slots[i].Park();
                    return slot;
                }
            }

            return emptySlot;
        }


        private Tuple<string, long> parkHelper(Slot slot, Vehicle vehicle, List<Slot> slots)
        {
            if (!occupiedSlots.Any(x => x.Key.ToLower() == vehicle.VehicleNumber.ToLower()))
            {
                int index = slots.IndexOf(slots.Where(x => x.GetSlotNumber() == slot.GetSlotNumber()).First());
                slots[index].Park();

               // slot.Park();

                occupiedSlots.Add(vehicle.VehicleNumber, slot);
                return new Tuple<string, long>(vehicle.VehicleNumber, slot.GetSlotNumber());
            }
            else
            {
                Console.WriteLine("Already parked");
                return new Tuple<string, long>("", 0);
            }

        }
    }
}
