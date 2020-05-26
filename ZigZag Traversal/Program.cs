using System;
using System.Collections.Generic;
using System.Linq;

namespace ZigZag_Traversal
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
            root.right.left.left = new TreeNode(20);
            root.right.left.right = new TreeNode(17);
            List<List<int>> result = ZigzagTraversal.traverse(root);
            Console.WriteLine("Zigzag traversal: " + result);
        }
    }

    class ZigzagTraversal {
        public static List<List<int>> traverse(TreeNode root) {
            List<List<int>> result = new List<List<int>>();
            // TODO: Write your code here

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int rownum = 1;
            while (queue.Count > 0) {
                int levelSize = queue.Count;
                LinkedList<int> row = new LinkedList<int>();
                for (int i = 0; i < levelSize; i++) {
                    TreeNode n = queue.Dequeue();
                    if (rownum%2==1) row.AddLast(n.val);
                    else row.AddFirst(n.val);
                    if (n.left != null) queue.Enqueue(n.left);
                    if (n.right != null) queue.Enqueue(n.right);
                }
                rownum++;
                result.Add(row.ToList());
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
