using System;



namespace GameOfLife
{
    class Generation
    {
        public bool[,] Grid;

        protected bool[,] new_grid;
        protected int[] getNumberOfAlive = new int[10];

        public int numberOfAlive;
        public int numberOfDead;

        public static int i = -1;
        public Generation()
        {
            
        }
        public void InitializingRandomly(int row, int column , int numberOfAliveCell)
        {
            Grid = new bool[row, column];
            Random engine = new Random();
            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
                {
                    Grid[y, x] = engine.Next() % 2 == 0;
                }
            }
        }
        public Generation(int x, int y, int z)
        {
            Grid = new bool[y, x];

            int population = z;

            Random row = new Random();
            Random coloumn = new Random();
            for (int i = 0; i < population; i++)
            {
                int _row = row.Next(0, y);
                int _coloumn = coloumn.Next(0, x);
                if (Grid[_row, _coloumn] == false)
                {
                    Grid[_row, _coloumn] = true;
                }
                else
                {
                    population++;
                }
            }
        }
        public Generation(int x, int y, double density)
        {
            Grid = new bool[y, x];
            
            int livingCellCount =  (x * y) * (int) density;

            Random row = new Random();
            Random coloumn = new Random();
            for (int i = 0; i < livingCellCount; i++)
            {
                int _row = row.Next(0, y);
                int _coloumn = coloumn.Next(0, x);
                if (Grid[_row, _coloumn] == false)
                {
                    Grid[_row, _coloumn] = true;
                }
                else
                {
                    livingCellCount++;
                }
            }
        }
        public void Display()
        {
            i++;
            Console.SetCursorPosition(0, Console.WindowTop);
            numberOfAlive = 0;
            numberOfDead = 0;
            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
                {
                    if (Grid[y, x])
                    {
                        Console.Write("■");
                        numberOfAlive++;
                    }
                    else
                    {
                        Console.Write(" ");
                        numberOfDead++;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(" ");
            Console.WriteLine($"==> Number Of Alive = {numberOfAlive} \n==> Number Of Dead = {numberOfDead}");
            
        }
        public virtual void NextState()
        {
           new_grid = new bool[Grid.GetLength(0), Grid.GetLength(1)];
            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
                {
                    int aliveNeighbours = CheckNeighbours(x, y);
                    if (Grid[y, x]) 
                    {
                        if (aliveNeighbours == 2 || aliveNeighbours == 3)
                        {
                            new_grid[y, x] = true;
                        }
                        else
                        {
                            new_grid[y, x] = false;
                        }
                    }
                    else
                    {
                        if (aliveNeighbours == 3)
                        {
                            new_grid[y, x] = true;
                        }
                        else
                        {
                            new_grid[y, x] = false;
                        }
                    }
                }
            }
            Grid = new_grid;
        }
        private int CheckNeighbours(int cell_y, int cell_x)
        {
            int aliveNeighbours = 0;
            int dx = Grid.GetLength(0);
            int dy = Grid.GetLength(1);
            if (Grid[(cell_x - 1 + dx) % dx, (cell_y - 1 + dy) % dy])
            {
                aliveNeighbours++;
            }
            if (Grid[cell_x, (cell_y - 1 + dy) % dy])
            {
                aliveNeighbours++;
            }
            if (Grid[(cell_x + 1) % dx, (cell_y - 1 + dy) % dy])
            {
                aliveNeighbours++;
            }
            if (Grid[(cell_x - 1 + dx) % dx, cell_y])
            {
                aliveNeighbours++;
            }
            if (Grid[(cell_x + 1) % dx, cell_y])
            {
                aliveNeighbours++;
            }
            if (Grid[(cell_x - 1 + dx) % dx, (cell_y + 1) % dy])
            {
                aliveNeighbours++;
            }
            if (Grid[cell_x, (cell_y + 1) % dy])
            {
                aliveNeighbours++;
            }
            if (Grid[(cell_x + 1) % dx, (cell_y + 1) % dy])
            {
                aliveNeighbours++;
            }
            return aliveNeighbours;
        }
    }
}