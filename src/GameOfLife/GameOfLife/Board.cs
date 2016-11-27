using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class Board
    {
        private readonly IList<Cell> _cells;
        public int Height { get; set; }
        public int Width { get; set; }

        public Board(string cells)
        {
            var cellString = cells.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

            _cells = new List<Cell>();
            Width = cellString[0].Length;
            Height = cellString.Length;

            CreateCells(cellString);
        }

        private void CreateCells(IReadOnlyList<string> cellString)
        {
            for (var lineIndex = 0; lineIndex < cellString.Count; lineIndex++)
            {
                var cellLine = cellString[lineIndex];
                for (var cellIndex = 0; cellIndex < cellLine.Length; cellIndex++)
                {
                    var cell = cellLine[cellIndex];
                    _cells.Add(new Cell(cell.ToString()) {X = cellIndex, Y = lineIndex});
                }
            }
        }

        public Board CalculateNextGeneration(string cellGeneration)
        {
            var generationCalculator = new GenerationCalculator(this);
            return generationCalculator.GenerateNextGeneration();
        }

        public string ConvertToString()
        {
            var boardString = new StringBuilder();
            for (var height = 0; height < Height; height++)
            {
                for (var width = 0; width < Width; width++)
                {
                    boardString.Append(GetCellAtPosition(width, height));
                    if (width == Width - 1 && height != Height - 1) boardString.Append(Environment.NewLine);

                }
            }
            return boardString.ToString();
        }

        public Cell GetCellAtPosition(int xPosition, int yPosition) => _cells[xPosition + (yPosition * Width)];
        public IEnumerable<Cell> GetCells() => _cells;

        public void UpdateCell(Cell cell)
        {
            var obj = _cells.FirstOrDefault(c => c.X == cell.X && c.Y == cell.Y);
            if (obj != null) obj = cell;
        }
    }
}