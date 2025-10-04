using Leetcode.Helpers;

namespace Leetcode.Trees;

public class SubsetOfAnotherTree
{
    public static bool IsSubtree(TreeNode? root, TreeNode? subRoot)
    {
        if (root is null) return false;

        Stack<TreeNode> stack = new();
        stack.Push(root);

        while (stack.Count > 0)
        {
            TreeNode node = stack.Pop();
            if (node.val == subRoot?.val && CheckSubtree(node, subRoot))
            {
                return true;
            }

            if (node.left is not null) stack.Push(node.left);
            if (node.right is not null) stack.Push(node.right);
        }

        return false;
    }

    private static bool CheckSubtree(TreeNode? treeA, TreeNode? treeB)
    {
        if (treeA is null && treeB is null)
            return true;
        else if (treeA is null || treeB is null)
            return false;
        else if (treeA.val != treeB.val)
            return false;
        else
            return CheckSubtree(treeA.left, treeB.left) &&
                CheckSubtree(treeA.right, treeB.right);
    }
}
