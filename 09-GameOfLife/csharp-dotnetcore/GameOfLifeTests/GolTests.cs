using System;
using System.Resources;
using System.Text;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace GameOfLifeTests
{
    public class GolTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private const int Dead = 0;
        private const int Live = 1;

        [Theory]
        [InlineData("Underpopulated dies", true, 0, false)]
        [InlineData("Underpopulated dies", true, 1, false)]
        [InlineData("Survives", true, 2, true)]
        [InlineData("Survives", true, 3, true)]
        [InlineData("Overpopulation kills", true, 4, false)]
        [InlineData("Overpopulation kills", true, 5, false)]
        [InlineData("Overpopulation kills", true, 6, false)]
        [InlineData("Overpopulation kills", true, 7, false)]
        [InlineData("Overpopulation kills", true, 8, false)]
        [InlineData("Reproduce", false, 3, true)]
        [InlineData("Stays dead", false, 2, false)]
        [InlineData("Stays dead", false, 4, false)]
        public void NewStateTests(string testName, bool currentState, int neighbours, bool expectedNewState)
        {
            var game = new Gol(3, 3);
            game.NewState(isLive: currentState, neighbours: neighbours).Should().Be(expectedNewState);
        }

        [Fact]
        public void GameGrid()
        {
            var game = new Gol(4, 3);
            game.Columns.Should().Be(4);
            game.Rows.Should().Be(3);
            game.Grid.Length.Should().Be(12);
            foreach (var cell in game.Grid)
            {
                cell.Should().Be(Dead);
            }
        }

        [Fact]
        public void NeighborCount()
        {
            var game = new Gol(4, 3);
            int[][] initalGrid = new int[][]
            {
                new int[]{1,0,0,0},
                new int[]{0,1,0,0},
                new int[]{0,0,1,0}
            };
            InitGrid(game, initalGrid);
            ShowGrid(game);
            game.LiveNeighborsFor(0, 0).Should().Be(1);
            game.LiveNeighborsFor(1, 0).Should().Be(2);
            game.LiveNeighborsFor(1, 1).Should().Be(2);
            game.LiveNeighborsFor(3, 2).Should().Be(1);
        }
        
        [Fact]
        public void CellDeathFromIsolation()
        {
            var game = new Gol(4, 3);
            int[][] initalGrid = new int[][]
            {
                new int[]{0,0,0,0},
                new int[]{0,1,0,0},
                new int[]{0,0,0,0}
            };
            InitGrid(game, initalGrid);
            ShowGrid(game);
            game.Grid[1, 1].Should().Be(Live);
            game.Tick();
            game.Grid[1, 1].Should().Be(Dead);
            ShowGrid(game);
        }

        [Fact]
        public void Survival()
        {
            var game = new Gol(4, 3);
            int[][] initalGrid = new int[][]
            {
                new int[]{0,0,0,0},
                new int[]{1,1,1,0},
                new int[]{0,0,0,0}
            };
            InitGrid(game, initalGrid);
            ShowGrid(game);
            game.Grid[1, 1].Should().Be(Live);
            game.Tick();
            game.Grid[1, 1].Should().Be(Live);
            ShowGrid(game);
        }
        
        [Fact]
        public void OverPopulation()
        {
            var game = new Gol(4, 3);
            int[][] initalGrid = new int[][]
            {
                new int[]{1,1,1,0},
                new int[]{1,1,1,0},
                new int[]{0,0,0,0}
            };
            InitGrid(game, initalGrid);
            ShowGrid(game);
            game.Grid[1, 1].Should().Be(Live);
            game.Tick();
            game.Grid[1, 1].Should().Be(Dead);
            ShowGrid(game);
        }
        
        [Fact]
        public void Birth()
        {
            var game = new Gol(4, 3);
            int[][] initalGrid = new int[][]
            {
                new int[]{0,0,0,0},
                new int[]{1,1,1,0},
                new int[]{0,0,0,0}
            };
            InitGrid(game, initalGrid);
            ShowGrid(game);
            game.Grid[1, 0].Should().Be(Dead);
            game.Tick();
            game.Grid[1, 0].Should().Be(Live);
            ShowGrid(game);
        }
        private void InitGrid(Gol game, int[][] initalGrid)
        {
            for (var c = 0; c < game.Columns; ++c)
            {

                for (var r = 0; r < game.Rows; ++r)
                {
                    game.Grid[c, r] = initalGrid[r][c];
                }
            }
        }

        private void ShowGrid(Gol game)
        {
            _testOutputHelper.WriteLine("");
            for (var r = 0; r < game.Rows; ++r)
            {
                var row = new StringBuilder(game.Columns);
                for (var c = 0; c < game.Columns; ++c)
                {
                    if (game.Grid[c, r] > 0)
                        row.Append('X');
                    else
                        row.Append('.');
                }
                _testOutputHelper.WriteLine(row.ToString());
            }

        }

        public GolTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
    }
}