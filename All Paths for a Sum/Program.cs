using System;
using System.Collections.Generic;

namespace All_Paths_for_a_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(4);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);
            int sum = 23;
            List<List<int>> result = FindAllTreePaths.findPaths(root, sum);
            Console.WriteLine("Tree paths with sum " + sum + ": " + result);
        }
    }
    
    class FindAllTreePaths {
        private List<List<int>> _allPaths;
        public static List<List<int>> findPaths(TreeNode root, int sum) {
            FindAllTreePaths fatp = new FindAllTreePaths();
            fatp._allPaths = new List<List<int>>();
            fatp.Step(root, sum, 0, new List<int>());
            // TODO: Write your code here
            return fatp._allPaths;
        }

        private void Step(TreeNode node, int sum, int val, List<int> path) {
            if (node == null) return;

            path.Add(node.val);

            if (node.left == null && node.right == null && val+node.val == sum) {
                // Chapter 1.2
                // so we need to make the copy here not at Chapter 1.1 to keep the path
                // for eternity
                _allPaths.Add(new List<int>(path));
            }
            else if (node.val + val < sum) 
            {
                // Chapter 1.1
                // more clever if we remove the node when needed, so don't need to maintain
                // a list for each leaf.
                Step(node.left, sum, val+node.val, path);
                Step(node.right, sum, val+node.val, path);
            }

            // Chapter 1.3
            // Here comes the removal
            path.RemoveAt(path.Count-1);
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
