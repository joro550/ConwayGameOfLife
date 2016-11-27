using System;
using NUnit.Framework;

namespace GameOfLife
{
    [TestFixture]
    public class GameTests
    {
        private static readonly string newLine = Environment.NewLine;
        public static string[][] _gameScenarios =
        {
            new[] {$"........{newLine}....*...{newLine}...**...{newLine}........",$"........{newLine}...**...{newLine}...**...{newLine}........"},
            new[] {$"*.......{newLine}*...*...{newLine}...**...{newLine}........",$"........{newLine}...**...{newLine}...**...{newLine}........"},
            new[] {$"........{newLine}....*...{newLine}...**...{newLine}....*...",$"........{newLine}...**...{newLine}....**..{newLine}........"}
        };

        [Test, TestCaseSource(nameof(_gameScenarios))]
        public void GivenAGenerationOfCellsCalculateTheNextGeneration(string generation, string expectedNextGeneration)
        {
            var gameOfLife = new Board(generation);
            var newGeneration = gameOfLife.CalculateNextGeneration(generation);
            Assert.That(newGeneration.ConvertToString(), Is.EqualTo(expectedNextGeneration));
        }

        [TestCase("...", 3)]
        [TestCase(".....", 5)]
        [TestCase(".......", 7)]
        [TestCase(@".......
.......", 7)]
        public void GivenABoardOfCellsThenBoardWidthIsAsExpected(string cells, int expectedWidth)
        {
            var gameOfLife = new Board(cells);
            Assert.That(gameOfLife.Width, Is.EqualTo(expectedWidth));
        }

        [TestCase(@"........
....*...
...**...
........", 4)]
        [TestCase(@"........
....*...
...**...", 3)]
        public void GivenABoardOfCellsThenBoardHeightIsAsExpected(string cells, int expectedHeight)
        {
            var gameOfLife = new Board(cells);
            Assert.That(gameOfLife.Height, Is.EqualTo(expectedHeight));
        }

        [TestCase(@"........
....*...
...**...", 0, 0, false)]
        [TestCase(@".*......
....*...
...**...", 1, 0, true)]
        [TestCase(@".*......
....*...
...**...", 4, 1, true)]
        public void GivenABoardOfCellsThenBoardCanRetrieveCellsFromPosition(string board, int xPosition, int yPosition, bool alive)
        {
            var gameOfLife = new Board(board);
            var cell = gameOfLife.GetCellAtPosition(xPosition, yPosition);

            Assert.That(cell.Alive, Is.EqualTo(alive));
            Assert.That(cell.X, Is.EqualTo(xPosition));
            Assert.That(cell.Y, Is.EqualTo(yPosition));
        }
    }
}