namespace Leetcode.Arrays;

public class Leetcode_348__Design_Tic_Tac_Toe
{
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