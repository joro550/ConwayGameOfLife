namespace GameOfLife
{
    public class GenerationCalculator
    {
        private readonly Board _board;

        public GenerationCalculator(Board board)
        {
            _board = board;
        }

        public Board GenerateNextGeneration()
        {
            var neighbourCalculator = new NeighbourCalculator(_board);
            foreach (var cell in _board.GetCells())
            {
                var neighbourCount =
                    neighbourCalculator.CalculateLivingNeighboursForCell(cell);
                cell.Alive = neighbourCount == 3;
                _board.UpdateCell(cell);
            }
            return _board;
        }
    }
}