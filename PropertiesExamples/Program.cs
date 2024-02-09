namespace PropertiesExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            User user = new User();

            //Using properties to set and get the user's name
            user.Name = "Bob";
            Console.WriteLine(user.Name);

            //Using properties with a private backing field
            user.Name2 = "Alice";
            Console.WriteLine(user.Name2);

            //Using methods to set and get the user's name
            user.SetName("Charlie");

            //Using methods to set and get the user's name
            Console.WriteLine(user.GetName());

            user.Name3 = "David";
            Console.WriteLine(user.Name3);
        }
    }
}
