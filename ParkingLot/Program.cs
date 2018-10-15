using System;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingPlace = new ParkingPlace();

            int userInput = 0;
            do
            {
                userInput = DisplayMenu();
                
                switch (userInput)
                {
                    // TODO : Use enum
                    case 1:
                        var mototCycle = new MotorCycle(ReadInput(VehicleType.Motorcycle));
                        PrintParkedVeichle(parkingPlace.Park(mototCycle), VehicleType.Motorcycle);
                        break;
                        
                    case 2:
                        var car = new Car(ReadInput(VehicleType.Car));
                        PrintParkedVeichle(parkingPlace.Park(car),VehicleType.Car);
                        break;

                    case 3:
                        
                        var bus = new Bus(ReadInput(VehicleType.Bus));
                        PrintParkedVeichle(parkingPlace.Park(bus),VehicleType.Bus);
                        break;
                    case 4:
                        PrintAllParkedVeichles(parkingPlace);
                        break;
                    default:
                        Console.WriteLine("Incorrect choice");
                        break;
                }

            } while (userInput != 5);

        }
        public static int DisplayMenu()
        {
            Console.WriteLine("\n\n**********Parking Lot**********");
            Console.WriteLine();
            Console.WriteLine("1. Park a Motorcycle");
            Console.WriteLine("2. Park a Car");
            Console.WriteLine("3. Park a Bus");
            Console.WriteLine("4. List all parked vehicles");
            Console.WriteLine("5. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }

        public static void PrintAllParkedVeichles(ParkingPlace parkingPlace)
        {
            Console.WriteLine("----------------All Parked Vehicles----------------");
            int c = 1;
            foreach (var item in parkingPlace.occupiedSlots)
            {
                Console.WriteLine($"{c++}. Vehicle Number-{item.Key}, {item.Value.GetType()} {item.Value.GetSlotNumber()}");
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