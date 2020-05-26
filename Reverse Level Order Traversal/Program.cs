using System;
using System.Collections.Generic;

namespace Reverse_Level_Order_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(9);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);
            LinkedList<List<int>> result = ReverseLevelOrderTraversal.traverse(root);
            Console.WriteLine("Reverse level order traversal: " + result);
        }
    }

    class ReverseLevelOrderTraversal {
        public static LinkedList<List<int>> traverse(TreeNode root) {
            LinkedList<List<int>> result = new LinkedList<List<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0) {
                int levelSize = queue.Count;
                List<int> row = new List<int>();
                for (int i = 0; i < levelSize; i++) {
                    TreeNode n = queue.Dequeue();
                    row.Add(n.val);
                    if (n.left != null) queue.Enqueue(n.left);
                    if (n.right != null) queue.Enqueue(n.right);
                }
                result.AddFirst(row);
            }


            return result;
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
