using HAHDoingPractice;
using Microsoft.Data.SqlClient;
using System;

class Program
{
    static void Main(string[] args)
    {
        PerfumeService perfumeService = new PerfumeService();

        while (true)
        {
            Console.WriteLine("\nChoose one option!");
            Console.WriteLine("1. Create Perfume");
            Console.WriteLine("2. GetAllPerfume");
            Console.WriteLine("3. GetPerfumeById");
            Console.WriteLine("4. Update Perfume");
            Console.WriteLine("5. Delete Perfume");
            Console.WriteLine("6. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    perfumeService.CreatePerfume();
                    break;

                case "2":
                    perfumeService.GetAllPerfumes();
                    break;

                case "3":
                    perfumeService.GetPerfumeById();
                    break;

                case "4":
                    perfumeService.UpdatePerfume();
                    break;

                case "5":
                    perfumeService.DeletePerfume();
                    break;

                case "6":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
    }
}