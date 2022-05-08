using System;
using System.Linq;

namespace GameOfLife
{
    class Cell : Generation
    {
        public Cell(int row, int coloumn, int numberOfAliveCell)
            :base(row ,coloumn,numberOfAliveCell)
        {
           
        }
        public Cell()
            :base()
        {

        }
        public override void NextState()
        {
            base.NextState();

            getNumberOfAlive[i] = numberOfAlive;
            int theSameNumber = 0;
            if (i == 8)
            {
                for (int k = 0; k < getNumberOfAlive.Length-1; k++)
                {
                    if (getNumberOfAlive[k] == getNumberOfAlive[k + 1])
                    {
                        theSameNumber++;
                    }
                    else if (theSameNumber == 7)
                    {
                        goto exit;
                    exit:
                        Console.WriteLine("These board is exactly the same as before");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                }
                Array.Clear(getNumberOfAlive, 0, getNumberOfAlive.Length);
                i = 0;
            }

            //var equal =
            //  Grid.Rank == new_grid.Rank &&
            //  Enumerable.Range(0, new_grid.Rank).All(dimension => Grid.GetLength(dimension) == new_grid.GetLength(dimension)) &&
            //  Grid.Cast<bool>().SequenceEqual(new_grid.Cast<bool>());

            //if (equal)
            //{
            //    Console.WriteLine("These board is exactly the same as before");
            //    Console.WriteLine("Press any key to exit");
            //    Console.ReadKey();
            //    Environment.Exit(1);
            //}
        }
    }
}
