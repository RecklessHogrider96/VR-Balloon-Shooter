using System;
using System.Numerics;
using Utilities;

namespace Lab1VectorMotion
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 7)
            {
                Console.WriteLine("Command line args should have 7 args. 3 for Input Vector, 3 for Final Vector and last one for time.");
                return;
            }

            Vector3 initialPos = new Vector3();
            float.TryParse(args[0], out initialPos.X);
            float.TryParse(args[1], out initialPos.Y);
            float.TryParse(args[2], out initialPos.Z);

            Vector3 finalPos = new Vector3();
            float.TryParse(args[3], out finalPos.X);
            float.TryParse(args[4], out finalPos.Y);
            float.TryParse(args[5], out finalPos.Z);

            int.TryParse(args[6], out int time);

            Console.WriteLine("Start Position: " + initialPos);
            Console.WriteLine("Final Position: " + finalPos);
            Console.WriteLine("Time: " + time);

            // Calculate distance.
            float distance = 0;
            //float distance = Vector3.DistanceSquared(initialPos, finalPos);
            distance = (finalPos.X - initialPos.X) * (finalPos.X - initialPos.X);
            distance += (finalPos.Y - initialPos.Y) * (finalPos.Y - initialPos.Y);
            distance += (finalPos.Z - initialPos.Z) * (finalPos.Z - initialPos.Z);
            distance = MathF.Sqrt(distance);

            Console.WriteLine("Distance: " + distance);

            // Calculate speed.
            float speed = distance/time;

            Console.WriteLine("Speed: " + speed);
            Console.WriteLine("-------------------------------");
            
            // Track position.
            int frames = 10;
            float interval = (float)time / frames;
            float j = 0;
            float distanceTraveled = 0;
            Vector3 translationVect = (finalPos - initialPos) / frames;
            Vector3 currentPos = initialPos;
            for (int iteration = 1; iteration <= frames; iteration++)
            {
                currentPos += translationVect;
                distanceTraveled = Vector3.Distance(initialPos, currentPos);
                j+=interval;

                PrintAllData(iteration, distanceTraveled, currentPos, j);
            }
        }

        private static void PrintAllData(int iteration, float distanceTraveled, Vector3 currentPos, float time)
        {
            Console.WriteLine("Iteration: " + iteration);
            Console.WriteLine("Distance Traveled: " + distanceTraveled);
            Console.WriteLine("Current Position: " + currentPos.Round(2));
            Console.WriteLine("Time: " + time);
            Console.WriteLine("-------------------------------");
        }
    }  
}