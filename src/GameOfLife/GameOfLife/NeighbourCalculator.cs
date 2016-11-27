using System.Linq;

namespace GameOfLife
{
    public class NeighbourCalculator
    {
        private readonly Board _board;

        public NeighbourCalculator(Board board)
        {
            _board = board;
        }

        public int CalculateLivingNeighboursForCell(Cell cell)
            => cell.GetNeighbours(_board).Count(neighbour => neighbour != null && neighbour.Alive);
    }
}