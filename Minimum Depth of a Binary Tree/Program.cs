using System;
using System.Collections.Generic;

namespace Minimum_Depth_of_a_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);
            Console.WriteLine("Tree Minimum Depth: " + MinimumBinaryTreeDepth.findDepth(root));
            root.left.left = new TreeNode(9);
            root.right.left.left = new TreeNode(11);
            Console.WriteLine("Tree Minimum Depth: " + MinimumBinaryTreeDepth.findDepth(root));
        }
    }

    class MinimumBinaryTreeDepth {
        public static int findDepth(TreeNode root) {
            // TODO: Write your code here
            if (root == null) return 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int levelSize = 0;
            int level = 1;
            while (queue.Count > 0){
                levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++) {
                    TreeNode n = queue.Dequeue();

                    if (n.left != null) queue.Enqueue(n.left);
                    if (n.right != null) queue.Enqueue(n.right);
                    if (n.left == null && n.right == null) {// this is a leaf!
                        return level;
                    }
                }
                level++;
            }
            return -1;
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
