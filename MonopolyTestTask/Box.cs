using System;
using System.Security.AccessControl;

namespace MonopolyTestTask
{
        public class Box
        {
            public string ID { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Depth { get; set; }
            public int Weight { get; set; }
            public DateTime ProductionDate { get; set; }
            public Box(string id, int width, int height, int depth, int weight, DateTime productionDate)
            {
                ID = id;
                Width = width;
                Height = height;
                Depth = depth;
                Weight = weight; 
                ProductionDate = productionDate;
            }

            public DateTime GetExpirationDate()
            {
                return ProductionDate.AddDays(100);
            }

            public int GetVolume()
            {
                return Width * Height * Depth;
            }
        }
}

