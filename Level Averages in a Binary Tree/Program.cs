using System;
using System.Collections.Generic;

namespace Level_Averages_in_a_Binary_Tree
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
            root.left.right = new TreeNode(2);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);
            List<Double> result = LevelAverage.findLevelAverages(root);
            Console.WriteLine("Level averages are: " + result);
        }
    }

    class LevelAverage {
        public static List<double> findLevelAverages(TreeNode root) {
            List<double> result = new List<double>();
            // TODO: Write your code here
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int levelSize = 0;
            double rowSum;
            while (queue.Count > 0) {
                levelSize = queue.Count;
                rowSum = 0.0;
                for (int i = 0; i < levelSize; i++) {
                    TreeNode n = queue.Dequeue();

                    if (n.left != null) queue.Enqueue(n.left);
                    if (n.right != null) queue.Enqueue(n.right);

                    rowSum += n.val;
                }
                result.Add(rowSum / levelSize);

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
