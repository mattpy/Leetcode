using Leetcode.Helpers;

namespace Leetcode.Trees;

public class BalancedBinaryTree
{
    private bool _isBalanced = true;

    public bool IsBalanced(TreeNode root)
    {
        FindHeight(root);
        return _isBalanced;
    }

    private int FindHeight(TreeNode? node)
    {
        if (node is null) return 0;

        int left = FindHeight(node.left);
        int right = FindHeight(node.right);

        if (Math.Abs(right - left) > 1)
        {
            _isBalanced = false;
        }

        return Math.Max(left, right) + 1;
    }
}
