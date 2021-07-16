namespace GameOfLifeTests
{
    public class Gol
    {
        public Gol(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
            Grid = new int[columns, rows];
        }

        public int Columns { get; }
        public int Rows { get; }
        public int[,] Grid { get; private set; }

        public bool NewState(bool isLive, int neighbours)
        {
            if (isLive)
                return neighbours >= 2 && neighbours < 4;
            return neighbours == 3;
        }

        public void Tick()
        {
            var updatedGrid = new int[Columns, Rows];
            for (var c = 0; c < Columns; ++c)
            {
                for (var r = 0; r < Rows; ++r)
                {
                    var currentState = Grid[c, r] > 0;
                    var newState = NewState(currentState, LiveNeighborsFor(c, r));
                    updatedGrid[c, r] = newState ? 1 : 0;
                }
            }
            Grid = updatedGrid;
        }

        public int LiveNeighborsFor(int column, int row)
        {
            var count = 0;
            for (var c = column - 1; c <= column + 1; ++c)
            {
                for (var r = row - 1; r <= row + 1; ++r)
                {
                    if (r >= 0 && c >= 0 && r < Rows && c < Columns)
                    {
                        if (r != row || c != column)
                        {
                            if (Grid[c, r] > 0)
                                ++count;
                        }
                    }
                }
            }

            return count;
        }
    }
}