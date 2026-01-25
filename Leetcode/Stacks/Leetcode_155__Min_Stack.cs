namespace Leetcode.Stacks;

public class MinStack
{
    private readonly Stack<(int min, int element)> _stack;

    public MinStack()
    {
        _stack = new Stack<(int, int)>();
    }

    public void Push(int val)
    {
        int newMin = _stack.Count == 0 ? val : Math.Min(val, _stack.Peek().min);
        _stack.Push((newMin, val));
    }

    public void Pop()
    {
        _stack.Pop();
    }

    public int Top()
    {
        var (_, top) = _stack.Peek();
        return top;
    }

    public int GetMin()
    {
        (int min, _) = _stack.Peek();
        return min;
    }
}
