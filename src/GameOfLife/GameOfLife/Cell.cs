namespace GameOfLife
{
    public class Cell
    {
        public bool Alive { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(string cellString)
        {
            Alive = cellString == "*";
        }

        public Cell TopLeftNeighbour(Board board) => IsCellFirstInRow() && Y != 0 ? board.GetCellAtPosition(X - 1, Y - 1) : null;
        public Cell LeftNeighbour(Board board) =>  IsCellFirstInRow() ? board.GetCellAtPosition(X - 1, Y) : null;
        public Cell BottomLeftNeighbour(Board board) => IsCellFirstInRow() && CellWithinBoardHeight(board) ? board.GetCellAtPosition(X - 1, Y + 1) : null;

        public Cell TopNeighbour(Board board) => Y != 0 ? board.GetCellAtPosition(X, Y - 1) : null;
        public Cell BottomNeighbour(Board board) => CellWithinBoardHeight(board) ? board.GetCellAtPosition(X, Y + 1) : null;

        public Cell TopRightNeighbour(Board board) => Y != 0 && CellWithinBoardWidth(board) ? board.GetCellAtPosition(X + 1, Y - 1) : null;
        public Cell RightNeighbour(Board board) => CellWithinBoardWidth(board) ? board.GetCellAtPosition(X + 1, Y) : null;
        public Cell BottomRightNeighbour(Board board) => CellWithinBoardHeight(board) && CellWithinBoardWidth(board) ?  board.GetCellAtPosition(X + 1, Y + 1) : null;

        public override string ToString() => Alive ? "*" : ".";

        private bool CellWithinBoardHeight(Board board) => Y < board.Height - 1;
        private bool CellWithinBoardWidth(Board board) => X < board.Width - 1;
        private bool IsCellFirstInRow() => X != 0;

        public Cell[] GetNeighbours(Board board) => new[]
        {
            TopLeftNeighbour(board), TopNeighbour(board), TopRightNeighbour(board), LeftNeighbour(board),
            RightNeighbour(board), BottomLeftNeighbour(board), BottomNeighbour(board), BottomRightNeighbour(board)
        };
    }
}