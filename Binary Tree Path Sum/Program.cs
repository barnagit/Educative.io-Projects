using System;

namespace Binary_Tree_Path_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(9);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);
            Console.WriteLine("Tree has path: " + TreePathSum.hasPath(root, 23));
            Console.WriteLine("Tree has path: " + TreePathSum.hasPath(root, 16));
        }
    }

        class TreePathSum {
        public static bool hasPath(TreeNode root, int sum) {
            // TODO: Write your code here

            return Step(root, sum, 0);
        }

        private static bool Step(TreeNode root, int sum, int val) {
            if (root == null) return false;
            else if (root.left == null && root.right == null) { // this is a leaf
                if (val + root.val == sum) return true;
                else return false;
            }
            else if (val + root.val >= sum) // we went over
                return false;
            else // we still in
                return Step(root.left, sum, val + root.val) || Step(root.right,sum, val+root.val);
        }
    }

    class TreeNode {
        internal int val;
        internal TreeNode left;
        internal TreeNode right;

        internal TreeNode(int x) {
            val = x;
        }
    }
}
