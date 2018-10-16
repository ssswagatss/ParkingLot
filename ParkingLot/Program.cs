using System;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingLot = new ParkingLot();

            int userInput = 0;
            do
            {
                userInput = DisplayMenu();
                
                switch (userInput)
                {
                    // TODO : Use enum
                    case 1:
                        var mototCycle = new MotorCycle(ReadInput(VehicleType.Motorcycle));
                        var availableFloor = parkingLot.GetEmptyFloor(VehicleType.Motorcycle);
                        if (availableFloor != null)
                        {
                            PrintParkedVeichle(availableFloor.Park(mototCycle), VehicleType.Motorcycle);
                        }
                        else
                        {
                            Console.WriteLine("No parking floors avalable");
                        }
                        
                        break;
                        
                    case 2:
                        var car = new Car(ReadInput(VehicleType.Car));
                        if (parkingLot.GetEmptyFloor(VehicleType.Car) != null)
                        {
                            PrintParkedVeichle(parkingLot.GetEmptyFloor(VehicleType.Car).Park(car), VehicleType.Car);
                        }
                        else
                        {
                            Console.WriteLine("No parking floors avalable");
                        }
                        break;

                    case 3:
                            var bus = new Bus(ReadInput(VehicleType.Bus));
                        if (parkingLot.GetEmptyFloor(VehicleType.Bus) != null)
                        {
                            PrintParkedVeichle(parkingLot.GetEmptyFloor(VehicleType.Bus).Park(bus), VehicleType.Bus);
                        }
                        else
                        {
                            Console.WriteLine("No parking floors available");
                        }
                        break;
                    case 4:
                        PrintAllParkedVeichles(parkingLot);
                        break;
                    case 5:
                        var vehicle = ReadInput(VehicleType.All);
                        parkingLot.UnPark(vehicle);
                        break;
                    default:
                        Console.WriteLine("Incorrect choice");
                        break;
                }

            } while (userInput != 6);

        }
        public static int DisplayMenu()
        {
            Console.WriteLine("\n\n**********Parking Lot**********");
            Console.WriteLine();
            Console.WriteLine("1. Park a Motorcycle");
            Console.WriteLine("2. Park a Car");
            Console.WriteLine("3. Park a Bus");
            Console.WriteLine("4. List all parked vehicles");
            Console.WriteLine("5. Unpark a vehicle");
            Console.WriteLine("6. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }

        public static void PrintAllParkedVeichles(ParkingLot parkingLot)
        {
            Console.WriteLine("----------------All Parked Vehicles----------------");
            int c = 1;
            foreach (var flooor in parkingLot.ParkingFloors)
            {
                foreach (var item in flooor.occupiedSlots)
                {
                    Console.WriteLine($"{c++}. Vehicle Number-{item.Key.ToUpper()}, {item.Value.GetType()} Floor-{flooor.FloorNumber} Slot-{item.Value.GetSlotNumber()}");
                }

            }
        }

        public static void PrintParkedVeichle(Tuple<string, long> parkedPlace, VehicleType type)
        {
            if(parkedPlace== null)
            {
                Console.WriteLine($"No parking space available for {type}");
                return;
            }
            Console.WriteLine("--------------------------------");
                Console.WriteLine($"{type} having number {parkedPlace.Item1} is parked at Place {type}{parkedPlace.Item2 }");
            }

        private static string ReadInput( VehicleType vehicleType)
        {
            Console.WriteLine($"Enter the {vehicleType} number");
            var vehicleNumber = Console.ReadLine();
            return vehicleNumber;
        }
    }

}