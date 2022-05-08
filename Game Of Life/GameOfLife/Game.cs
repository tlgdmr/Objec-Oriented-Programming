using System;
using System.IO;
using System.Threading;

namespace GameOfLife
{
    class Game 
    {
        private static string path = @"A:\ProjectForC#\GameOfLife\GameOfLife\";
        public static Cell generation = new Cell();

        public static void Main(string[] args)
        {
            //int alive = 0;
            //int i = 0, j = 0;
            //string[,] result = new string[10, 10];
            //foreach (var row in filePath.Split('\n'))
            //{
            //    j = 0;
            //    foreach (var col in row.Split(' '))
            //    {
            //        result[i, j] = col.Trim();
            //        j++;
            //    }
            //    i++;
            //}
            //for (int z = 0; z < result.GetLength(0); z++)
            //{
            //    for (int c = 0; c < result.GetLength(1); c++)
            //    {
            //        if (result[c, z] == "■")
            //        {
            //            alive++;
            //        }
            //    }
            //}
            //Console.WriteLine(alive);


            Console.WriteLine("Write Number for column and row (e.g '20 20') = ");
            string input = Console.ReadLine();
            string[] givenValue = input.Split(" ");

            int row = int.Parse(givenValue[0]);
            int coloumn = int.Parse(givenValue[1]);

            if (row <= 0 || coloumn <= 0)
            {
                Console.WriteLine("Do not write the negative number or zero");
                Main(null);
            }

            Console.WriteLine($"Write number of Alive cell (Max:{row * coloumn})");
            int numberOfAliveCell = int.Parse(Console.ReadLine());

            if (numberOfAliveCell >= row * coloumn)
            {
                Console.WriteLine($"Do not write the number of Alive cell bigger than 'Max' or negative number ");
                Main(null);
            }
            Cell generation = new Cell(row, coloumn, numberOfAliveCell);
            Console.Clear();


            while (!Console.KeyAvailable)
            {
                Thread.Sleep(20);
                generation.Display();
                generation.NextState();
            }
            var filePath = path + "Board " + 1 + ".txt";
            SaveToFile(filePath, generation);
        }
        private static void SaveToFile(string path, Generation generation)
        {
            bool[,] Grid = generation.Grid;

            int numberOfAlive = generation.numberOfAlive;
            int numberOfDead = generation.numberOfDead;

            if (Directory.Exists(path)!)
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                using (StreamWriter writeToFile = new StreamWriter(path))
                {
                    for (int y = 0; y < Grid.GetLength(0); y++)
                    {
                        writeToFile.WriteLine();
                        for (int x = 0; x < Grid.GetLength(1); x++)
                        {
                            if (Grid[y, x])
                            {
                                writeToFile.Write("■");
                            }
                            else
                            {
                                writeToFile.Write(" ");
                            }
                        }
                    }
                    writeToFile.WriteLine(" ");
                    writeToFile.WriteLine($"Number of Alive Cell For This State: {numberOfAlive}");
                    writeToFile.WriteLine($"Number of Dead Cell For This State: {numberOfDead}");
                }
            }
        }
    }
}
