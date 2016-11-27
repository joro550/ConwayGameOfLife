using NUnit.Framework;

namespace GameOfLife
{
    [TestFixture]
    public class LivingNeighbourCalculatorTests
    {
        [TestCase(@"...
***
...", 1, 1, 2)]
        [TestCase(@"...
***
...", 0, 1, 1)]
        [TestCase(@"***
***
***", 1, 1, 8)]
        [TestCase(@"***", 1, 0, 2)]
        public void GivenACellInABoardThenLivingNeighboursCanBeCalculated(string boardString, int xPosition, int yPosition, int expectedLivingNeighbours)
        {
            var board = new Board(boardString);
            var cell = board.GetCellAtPosition(xPosition, yPosition);
            var neighbourCalculator = new NeighbourCalculator(board);
            var livingNeighbourCount = neighbourCalculator.CalculateLivingNeighboursForCell(cell);
            Assert.That(livingNeighbourCount, Is.EqualTo(expectedLivingNeighbours));
        }
    }
}