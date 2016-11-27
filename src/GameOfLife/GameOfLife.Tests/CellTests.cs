using System.Linq;
using NUnit.Framework;

namespace GameOfLife
{
    [TestFixture]
    public class CellTests
    {
        [Test]
        public void GivenAStringRepresentingADeadCellThenAliveIsFalse()
        {
            var cell = new Cell(".");
            Assert.False(cell.Alive);
        }

        [Test]
        public void GivenAStringRepresentingACellThatIsAliveThenAliveIsTrue()
        {
            var cell = new Cell("*");
            Assert.True(cell.Alive);
        }

        [Test]
        public void GivenAnAliveCellThenToStringReturnsAstriks()
        {
            var cell = new Cell("*");
            Assert.That(cell.ToString(), Is.EqualTo("*"));
        }

        [Test]
        public void GivenACellInABoardCellCanFindTopLeftNeighbour()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(1, 1);
            var neighbour = cell.TopLeftNeighbour(board);

            Assert.True(neighbour.Alive);
            Assert.That(neighbour.X, Is.EqualTo(0));
            Assert.That(neighbour.Y, Is.EqualTo(0));
        }

        [Test]
        public void GivenACellInABoardCellCanFindLeftNeighbour()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(1, 1);
            var neighbour = cell.LeftNeighbour(board);

            Assert.False(neighbour.Alive);
            Assert.That(neighbour.X, Is.EqualTo(0));
            Assert.That(neighbour.Y, Is.EqualTo(1));
        }

        [Test]
        public void GivenACellInABoardCellCanFindBottomLeftNeighbour()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(1, 1);
            var neighbour = cell.BottomLeftNeighbour(board);

            Assert.True(neighbour.Alive);
            Assert.That(neighbour.X, Is.EqualTo(0));
            Assert.That(neighbour.Y, Is.EqualTo(2));
        }

        [Test]
        public void GivenACellInABoardCellCanFindTopNeighbour()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(1, 1);
            var neighbour = cell.TopNeighbour(board);

            Assert.That(neighbour.X, Is.EqualTo(1));
            Assert.That(neighbour.Y, Is.EqualTo(0));
        }

        [Test]
        public void GivenACellInABoardCellCanFindTopRightNeighbour()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(1, 1);
            var neighbour = cell.TopRightNeighbour(board);

            Assert.That(neighbour.X, Is.EqualTo(2));
            Assert.That(neighbour.Y, Is.EqualTo(0));
        }

        [Test]
        public void GivenACellInABoardCellCanFindRightNeighbour()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(1, 1);
            var neighbour = cell.RightNeighbour(board);

            Assert.That(neighbour.X, Is.EqualTo(2));
            Assert.That(neighbour.Y, Is.EqualTo(1));
        }

        [Test]
        public void GivenACellInABoardCellCanFindBottomRightNeighbour()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(1, 1);
            var neighbour = cell.BottomRightNeighbour(board);

            Assert.That(neighbour.X, Is.EqualTo(2));
            Assert.That(neighbour.Y, Is.EqualTo(2));
        }

        [Test]
        public void GivenACellInABoardCellCanFindBottomNeighbour()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(1, 1);
            var neighbour = cell.BottomNeighbour(board);

            Assert.That(neighbour.X, Is.EqualTo(1));
            Assert.That(neighbour.Y, Is.EqualTo(2));
        }

        [Test]
        public void GivenTheFirstCellInABoardThenTopLeftNeighbourDoesNotExist()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(0, 0);
            var neighbour = cell.TopLeftNeighbour(board);
            Assert.That(neighbour, Is.Null);
        }

        [Test]
        public void GivenTheFirstCellInABoardThenLeftNeighbourDoesNotExist()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(0, 0);
            var neighbour = cell.LeftNeighbour(board);
            Assert.That(neighbour, Is.Null);
        }

        [Test]
        public void GivenTheFirstCellInABoardThenBottomLeftNeighbourDoesNotExist()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(0, 0);
            var neighbour = cell.BottomLeftNeighbour(board);
            Assert.That(neighbour, Is.Null);
        }

        [Test]
        public void GivenTheFirstCellInABoardThenTopNeighbourDoesNotExist()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(0, 0);
            var neighbour = cell.TopNeighbour(board);
            Assert.That(neighbour, Is.Null);
        }

        [Test]
        public void GivenTheFirstCellInABoardThenTopRightNeighbourDoesNotExist()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(0, 0);
            var neighbour = cell.TopRightNeighbour(board);
            Assert.That(neighbour, Is.Null);
        }

        [Test]
        public void GivenACellInTheFirstRowOfTheBoardThenTopLeftNeighbourDoesNotExist()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(1, 0);
            var neighbour = cell.TopLeftNeighbour(board);
            Assert.That(neighbour, Is.Null);
        }

        [Test]
        public void GivenACellInTheFirstRowOfTheBoardThenTopNeighbourDoesNotExist()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(1, 0);
            var neighbour = cell.TopNeighbour(board);
            Assert.That(neighbour, Is.Null);
        }

        [Test]
        public void GivenACellInTheFirstRowOfTheBoardThenTopRightNeighbourDoesNotExist()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(1, 0);
            var neighbour = cell.TopRightNeighbour(board);
            Assert.That(neighbour, Is.Null);
        }

        [Test]
        public void GivenTheRightMostCellInABoardThenTopRightNeighbourDoesNotExist()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(3, 1);
            var neighbour = cell.TopRightNeighbour(board);
            Assert.That(neighbour, Is.Null);
        }

        [Test]
        public void GivenTheRightMostCellInABoardThenRightNeighbourDoesNotExist()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(3, 1);
            var neighbour = cell.RightNeighbour(board);
            Assert.That(neighbour, Is.Null);
        }

        [Test]
        public void GivenTheRightMostCellInABoardThenBottomRightNeighbourDoesNotExist()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(3, 1);
            var neighbour = cell.BottomRightNeighbour(board);
            Assert.That(neighbour, Is.Null);
        }

        [Test]
        public void GivenTheFirstCellInTheLastRowThenTopLeftNeighboutDoesNotExist()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(0, 2);
            var neighbour = cell.TopLeftNeighbour(board);
            Assert.That(neighbour, Is.Null);
        }

        [Test]
        public void GivenTheFirstCellInTheLastRowThenLeftNeighboutDoesNotExist()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(0, 2);
            var neighbour = cell.LeftNeighbour(board);
            Assert.That(neighbour, Is.Null);
        }

        [Test]
        public void GivenTheFirstCellInTheLastRowThenBottomNeighboutDoesNotExist()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(0, 2);
            var neighbour = cell.BottomNeighbour(board);
            Assert.That(neighbour, Is.Null);
        }

        [Test]
        public void GivenTheFirstCellInTheLastRowThenBottomRightNeighboutDoesNotExist()
        {
            var board = new Board(@"*...
....
*...");
            var cell = board.GetCellAtPosition(0, 2);
            var neighbour = cell.BottomRightNeighbour(board);
            Assert.That(neighbour, Is.Null);
        }

        [Test]
        public void GivenACellInTheBottomRowThenBottomLeftNeighbourDoesNotExist()
        {
            var board = new Board(@"**..
....
*...");
            var cell = board.GetCellAtPosition(1, 2);
            var neighbour = cell.BottomLeftNeighbour(board);

            Assert.That(neighbour, Is.Null);
        }

        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(3, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(0, 2)]
        [TestCase(1, 2)]
        [TestCase(2, 2)]
        [TestCase(3, 2)]
        public void GivenACellInABoardWhenGetNeighboursIsCalledThenAllNeighboursAreAsExpected(int xPosition, int yPosition)
        {
            var board = new Board(@"**..
....
*...");
            var cell = board.GetCellAtPosition(xPosition, yPosition);
            var neighbours = cell.GetNeighbours(board);

            Assert.That(neighbours.Count, Is.EqualTo(8));

            var topLeftNeighbour = cell.TopLeftNeighbour(board);
            Assert.That(neighbours[0], Is.EqualTo(topLeftNeighbour));

            var topNeighbour = cell.TopNeighbour(board);
            Assert.That(neighbours[1], Is.EqualTo(topNeighbour));

            var topRightNeighbour = cell.TopRightNeighbour(board);
            Assert.That(neighbours[2], Is.EqualTo(topRightNeighbour));

            var leftNeighbour = cell.LeftNeighbour(board);
            Assert.That(neighbours[3], Is.EqualTo(leftNeighbour));

            var rightNeighbour = cell.RightNeighbour(board);
            Assert.That(neighbours[4], Is.EqualTo(rightNeighbour));

            var bottomLeftNeighbour = cell.BottomLeftNeighbour(board);
            Assert.That(neighbours[5], Is.EqualTo(bottomLeftNeighbour));

            var bottomNeighbour = cell.BottomNeighbour(board);
            Assert.That(neighbours[6], Is.EqualTo(bottomNeighbour));

            var bottomRightNeighbour = cell.BottomRightNeighbour(board);
            Assert.That(neighbours[7], Is.EqualTo(bottomRightNeighbour));
        }
    }
}