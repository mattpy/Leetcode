namespace Leetcode.Arrays;

public class Leetcode_348__Design_Tic_Tac_Toe
{
    public class TicTacToeFastOptimized
    {
        private readonly int[] _rows;
        private readonly int[] _cols;

        private int _diagonal;
        private int _antiDiagonal;

        private readonly int _size;

        public TicTacToeFastOptimized(int n)
        {
            _size = n;
            _rows = new int[n];
            _cols = new int[n];
        }

        public int Move(int row, int col, int player)
        {
            int toAdd = (player == 1) ? 1 : -1;

            _rows[row] += toAdd;
            _cols[col] += toAdd;

            if (row == col)
            {
                _diagonal += toAdd;
            }

            if (row + col == _size - 1)
            {
                _antiDiagonal += toAdd;
            }

            if (Math.Abs(_rows[row]) == _size ||
                Math.Abs(_cols[col]) == _size ||
                Math.Abs(_diagonal) == _size ||
                Math.Abs(_antiDiagonal) == _size)
            {
                return player;
            }

            return 0;
        }
    }

    public class TicTacToeFast
    {
        private readonly int _size;

        private readonly int[] _playerARows;
        private readonly int[] _playerBRows;

        private readonly int[] _playerACols;
        private readonly int[] _playerBCols;

        private int _playerADiagonal = 0;
        private int _playerBDiagonal = 0;

        private int _playerAAntiDiagonal = 0;
        private int _playerBAntiDiagonal = 0;

        public TicTacToeFast(int n)
        {
            _size = n;

            _playerARows = new int[n];
            _playerBRows = new int[n];

            _playerACols = new int[n];
            _playerBCols = new int[n];
        }

        public int Move(int row, int col, int player)
        {
            if (player == 1)
            {
                _playerARows[row]++;
                if (_playerARows[row] == _size) return player;

                _playerACols[col]++;
                if (_playerACols[col] == _size) return player;

                if (row == col)
                {
                    _playerADiagonal++;
                    if (_playerADiagonal == _size) return player;
                }

                if (row + col == _size - 1)
                {
                    _playerAAntiDiagonal++;
                    if (_playerAAntiDiagonal == _size) return player;
                }
            }
            else
            {
                _playerBRows[row]++;
                if (_playerBRows[row] == _size) return player;

                _playerBCols[col]++;
                if (_playerBCols[col] == _size) return player;

                if (row == col)
                {
                    _playerBDiagonal++;
                    if (_playerBDiagonal == _size) return player;
                }

                if (row + col == _size - 1)
                {
                    _playerBAntiDiagonal++;
                    if (_playerBAntiDiagonal == _size) return player;
                }
            }

            return 0;
        }
    }

    public class TicTacToeIterative
    {
        private readonly int[,] _board;

        public TicTacToeIterative(int n)
        {
            _board = new int[n, n];
        }

        public int Move(int row, int col, int player)
        {
            _board[row, col] = player;

            bool isCompletedRow = CheckVertical(player, col)
                || CheckHorizontal(player, row)
                || CheckDiagonal(player);

            return isCompletedRow ? player : 0;
        }

        private bool CheckVertical(int player, int col)
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                if (_board[i, col] != player)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckHorizontal(int player, int row)
        {
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                if (_board[row, i] != player)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckDiagonal(int player)
        {
            int n = _board.GetLength(0);

            bool bottomRightDiagonal = true;
            for (int i = 0; i < n; i++)
            {
                bottomRightDiagonal &= _board[i, i] == player;
                if (!bottomRightDiagonal) break;
            }

            bool topRightDiagonal = true;
            for (int i = 0; i < n; i++)
            {
                topRightDiagonal &= _board[n - i - 1, i] == player;
                if (!topRightDiagonal) break;
            }

            return bottomRightDiagonal || topRightDiagonal;
        }
    }
}