namespace PredicateExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            // Define a predicate that checks if a number is even
            Predicate<int> isEvenPredicate = x => x % 2 == 0;

            // Use the FindAll method with the predicate to find all even numbers in the list
            List<int> evenNumbers = numbers.FindAll(isEvenPredicate);

            // Print the even numbers
            foreach (int num in evenNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}
