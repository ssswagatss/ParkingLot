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
                    case 1:
                        Console.WriteLine("Enter the car number");
                        var number = Console.ReadLine();
                        var car = new Car(number);
                        parkingPlace.Park(car);
                        ListParkedVeichles(parkingPlace);
                        break;
                    case 2:
                        Console.WriteLine("Enter the MotorCycle number");
                        var mcnumber = Console.ReadLine();
                        var mototCycle = new MotorCycle(mcnumber);
                        parkingPlace.Park(mototCycle);
                        ListParkedVeichles(parkingPlace);
                        break;
                    case 4:
                        ListParkedVeichles(parkingPlace);
                        break;
                    default:
                        break;
                }

            } while (userInput != 5);

        }
        static public int DisplayMenu()
        {
            Console.WriteLine("\n\n**********Parking Lot**********");
            Console.WriteLine();
            Console.WriteLine("1. Park a Car");
            Console.WriteLine("2. Park a Motorcycle");
            Console.WriteLine("3. Park a bus");
            Console.WriteLine("4. List all parked veichles");
            Console.WriteLine("5. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }

        static public void ListParkedVeichles(ParkingPlace parkingPlace)
        {
            Console.WriteLine("----------------All Parked Cars----------------");
            int c = 0;
            foreach (var item in parkingPlace.occupiedSlots)
            {
                Console.WriteLine($"{c++}. Code-{item.Key}, {item.Value.GetSlotNumber()}, Veichle Number-{item.Value}");
            }
        }
    }

}
