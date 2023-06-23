using System.Collections.Generic;
using System;
using System.Linq;

namespace MonopolyTestTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create sample pallets and boxes
            Pallet pallet1 = new Pallet("P1", 100, 100, 100, 0);
            Pallet pallet2 = new Pallet("P2", 100, 100, 100, 0);
            Pallet pallet3 = new Pallet("P3", 100, 100, 100, 0);
            // ...

            // Add boxes to pallets
            Box box1 = new Box("B1", 10, 10, 10, 10, DateTime.Now);
            Box box2 = new Box("B2", 20, 20, 20, 10, DateTime.Now);
            Box box3 = new Box("B3", 15, 15, 15, 10, DateTime.Now);
            // ...
            pallet1.AddBox(box1);
            pallet2.AddBox(box2);
            pallet3.AddBox(box3);
            // ...

            // Create a list of pallets
            List<Pallet> pallets = new List<Pallet> { pallet1, pallet2, pallet3 };

            // Group pallets by expiration date
            var groupedPallets = pallets.GroupBy(pallet => pallet.GetExpirationDate())
                                        .OrderBy(group => group.Key);

            // Sort pallets within each group by weight
            foreach (var group in groupedPallets)
            {
                var sortedPallets = group.OrderBy(pallet => pallet.GetWeight());
                Console.WriteLine($"Pallets with expiration date {group.Key}:");
                foreach (var pallet in sortedPallets)
                {
                    Console.WriteLine($"Pallet ID: {pallet.ID}, Weight: {pallet.GetWeight()} kg");
                }
                Console.WriteLine();
            }

            // Get the top 3 pallets with the highest expiration date and sort them by volume
            var topPallets = pallets.OrderByDescending(pallet => pallet.GetExpirationDate())
                                    .Take(3)
                                    .OrderBy(pallet => pallet.GetVolume());

            Console.WriteLine("Top 3 pallets with highest expiration date, sorted by volume:");
            foreach (var pallet in topPallets)
            {
                Console.WriteLine($"Pallet ID: {pallet.ID}, Expiration Date: {pallet.GetExpirationDate()}, Volume: {pallet.GetVolume()} cubic units");
            }

            // Wait for user input before closing the console window
            Console.ReadLine();
        }
    }
}

