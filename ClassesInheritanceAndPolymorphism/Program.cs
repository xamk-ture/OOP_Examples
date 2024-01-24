namespace ClassesInheritanceAndPolymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("Toyota", "Corolla", "Inline-4", 132);
            //calls Vehicle class PrintVehicleDetails() method
            myCar.PrintVehicleDetails();
            myCar.Start();
            myCar.Honk();
            myCar.Stop();
       

            Truck myTruck = new Truck("Ford", "F-150", "V8", 450);
            myTruck.Start();

            //calls IMechanical DisplayInfo() method
            myTruck.DisplayInfo();
            myTruck.Tow();
            myTruck.Stop();


            //We can create a list of IMechanical objects and add our Car and Truck objects to it.
            //because both Car and Truck implement the IMechanical interface.
            //So we can add any object that implements the IMechanical interface to the list.
            List<IMechanical> vehicles = new List<IMechanical>();
            vehicles.Add(myCar);
            vehicles.Add(myTruck);

            //We can then iterate through the list and call the DisplayInfo() method on each object.
            //Note that we can only call methods that are defined in the interface.
            foreach (IMechanical vehicle in vehicles)
            {
                vehicle.DisplayInfo();
            }
        }
    }
}