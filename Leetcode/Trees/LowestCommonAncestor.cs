using Leetcode.Helpers;

namespace Leetcode.Trees;

public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root is null)
            return null;

        if (root == p || root == q)
            return root;

        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);

        if (left is not null && right is not null)
            return root;

        return (left is not null) ? left : right;
    }
}
