namespace ClassesInheritanceAndPolymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("Toyota", "Corolla", "Inline-4", 132);
            myCar.PrintVehicleDetails();
            myCar.Honk();

            Truck myTruck = new Truck("Ford", "F-150", "V8", 450);
            myTruck.PrintVehicleDetails();
            myTruck.Tow();
        }
    }
}