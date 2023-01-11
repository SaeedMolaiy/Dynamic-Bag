using System;

namespace DynamicBag
{
    internal class Program
    {
        private static void Main()
        {
            dynamic bag = new Model.DynamicBag();

            bag.FirstName = "Saeed";
            bag.LastName = "Molaiy";

            Console.WriteLine($"Author Full Name is : {bag.FirstName} {bag.LastName}");

            Console.ReadKey();
        }
    }
}
