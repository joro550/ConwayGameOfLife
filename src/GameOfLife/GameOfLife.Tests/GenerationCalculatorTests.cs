using System.Linq;
using NUnit.Framework;

namespace GameOfLife
{
    [TestFixture]
    public class GenerationCalculatorTests
    {
        [Test]
        public void GivenABoardOfCellsWhereACellHasFewerThanTwoLivingNeighboursThenTheCellDiesFromUnderPopulation()
        {
            var board = new Board(@"...
.*.
...");
            var generationCalculator = new GenerationCalculator(board);
            var nextGenerationBoard = generationCalculator.GenerateNextGeneration();
            var nextGeneration = nextGenerationBoard.GetCells();

            Assert.That(nextGeneration.Count, Is.EqualTo(9));
            Assert.That(nextGeneration.Any(cell => cell.Alive), Is.False);
        }

        [Test]
        public void GivenABoardOfCellsWhereACellHasMoreThanThreeLivingNeighboursThenTheCellDiesFromOverPopulation()
        {
            var board = new Board(@"***
**.
...");
            var generationCalculator = new GenerationCalculator(board);
            var nextGenerationBoard = generationCalculator.GenerateNextGeneration();
            var cell = nextGenerationBoard.GetCellAtPosition(1, 1);

            Assert.That(cell.Alive, Is.False);
        }

        [Test]
        public void GivenABoardOfCellsWhereACellHasExactlyThreeLivingNeighboursThenCellShouldLiveInTheNextGeneration()
        {
            var board = new Board(@"...
..*
.**");
            var generationCalculator = new GenerationCalculator(board);
            var nextGenerationBoard = generationCalculator.GenerateNextGeneration();
            var cell = nextGenerationBoard.GetCellAtPosition(1, 1);

            Assert.That(cell.Alive, Is.True);
        }
    }
}