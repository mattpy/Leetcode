namespace Leetcode.Trees;

using Leetcode.Helpers;

public class DiameterOfBinaryTree
{
    private int maxDiameter = 0;

    public int DiameterOfBinaryTreeImpl(TreeNode root)
    {
        LongestPath(root);
        return maxDiameter;
    }

    private int LongestPath(TreeNode? root)
    {
        if (root is null) return -1;

        int left = LongestPath(root.left);
        int right = LongestPath(root.right);

        int currentDiameter = left + right + 2;
        maxDiameter = Math.Max(maxDiameter, currentDiameter);

        return Math.Max(left, right) + 1;
    }
}
