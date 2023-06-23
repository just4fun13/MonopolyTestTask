using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyTestTask
{
        public class Pallet
        {
            public string ID { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Depth { get; set; }
            public int Weight { get; set; }
            public List<Box> Boxes { get; set; }

            public Pallet(string id, int width, int height, int depth, int weight)
            {
                ID = id;
                Width = width;
                Height = height;
                Depth = depth;
                Weight = weight;
                Boxes = new List<Box>();
            }

            public void AddBox(Box box)
            {
                if (box.Width <= Width && box.Height <= Height && box.Depth <= Depth)
                {
                    Boxes.Add(box);
                }
                else
                {
                    Console.WriteLine($"Box {box.ID} cannot fit on the palletdue to size limitations.");
                }
            }

            public DateTime GetExpirationDate()
            {
                if (Boxes.Count > 0)
                {
                    return Boxes.Min(b => b.GetExpirationDate());
                }
                return DateTime.MinValue;
            }

            public int GetWeight()
            {
                return Boxes.Sum(b => b.Weight) + 30;
            }

            public int GetVolume()
            {
                return Boxes.Sum(b => b.GetVolume()) + (Width * Height * Depth);
            }
        }
}

