using System;
using System.Collections.Generic;


namespace Binary_Tree_Level_Order_Traversal
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
            List<List<int>> result = LevelOrderTraversal.traverse(root);
            Console.WriteLine("Level order traversal: " + result);
        }
    }

    class LevelOrderTraversal {
        public static List<List<int>> traverse(TreeNode root) {
            List<List<int>> result = new List<List<int>>();
            // TODO: Write your code here
            Queue<TreeNode> currentLevel;
            Queue<TreeNode> nextLevel;

            currentLevel = new Queue<TreeNode>();
            currentLevel.Enqueue(root);
            while (currentLevel.Count > 0) {
                nextLevel = new Queue<TreeNode>();
                List<int> row = new List<int>();
                while (currentLevel.Count > 0) {
                    TreeNode n = currentLevel.Dequeue();
                    if (n.left != null) nextLevel.Enqueue(n.left);
                    if (n.right != null) nextLevel.Enqueue(n.right);
                    row.Add(n.val);
                }
                currentLevel = nextLevel;
                result.Add(row);
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
