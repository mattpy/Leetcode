using Leetcode.Helpers;

namespace Leetcode.Trees;

public class SameTree
{
    public static bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        if (p is null && q is null)
            return true;
        else if (p is null || q is null)
            return false;
        else if (p.val != q.val)
            return false;
        else
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}
