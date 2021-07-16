using System;
using System.Resources;
using System.Text;
using System.Threading;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace GameOfLifeTests
{
    public class GolTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        
        private const bool Dead = false;
        private const bool Live = true;
        private const bool _ = Dead;
        private const bool X = Live;

        [Theory]
        [InlineData("Underpopulated dies", Live, 0, Dead)]
        [InlineData("Underpopulated dies", Live, 1, Dead)]
        [InlineData("Survives", Live, 2, Live)]
        [InlineData("Survives", Live, 3, Live)]
        [InlineData("Overpopulation kills", Live, 4, Dead)]
        [InlineData("Overpopulation kills", Live, 5, Dead)]
        [InlineData("Overpopulation kills", Live, 6, Dead)]
        [InlineData("Overpopulation kills", Live, 7, Dead)]
        [InlineData("Overpopulation kills", Live, 8, Dead)]
        [InlineData("Reproduce", Dead, 3, Live)]
        [InlineData("Stays dead", Dead, 2, Dead)]
        [InlineData("Stays dead", Dead, 4, Dead)]
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
            var initalGrid = new []
            {
                new []{X,_,_,_},
                new []{_,X,_,_},
                new []{_,_,X,_}
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
            var initalGrid = new []
            {
                new []{_,_,_,_},
                new []{_,X,_,_},
                new []{_,_,_,_}
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
            var initalGrid = new []
            {
                new []{_,_,_,_},
                new []{X,X,X,_},
                new []{_,_,_,_}
            };
            InitGrid(game, initalGrid);
            ShowGrid(game);
            game.Grid[1, 1].Should().Be(Live);
            game.Tick();
            game.Grid[1, 1].Should().Be(Live);
            ShowGrid(game);
        }
        
        [Fact]
        public void DeathFromOverPopulation()
        {
            var game = new Gol(4, 3);
            var initalGrid = new []
            {
                new []{X,X,X,_},
                new []{X,X,X,_},
                new []{_,_,_,_}
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
            var initalGrid = new []
            {
                new []{_,_,_,_},
                new []{X,X,X,_},
                new []{_,_,_,_}
            };
            InitGrid(game, initalGrid);
            ShowGrid(game);
            game.Grid[1, 0].Should().Be(Dead);
            game.Tick();
            game.Grid[1, 0].Should().Be(Live);
            ShowGrid(game);
        }
        private void InitGrid(Gol game, bool[][] initialGrid)
        {
            for (var c = 0; c < game.Columns; ++c)
            {

                for (var r = 0; r < game.Rows; ++r)
                {
                    game.Grid[c, r] = initialGrid[r][c];
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
                    if (game.Grid[c, r])
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