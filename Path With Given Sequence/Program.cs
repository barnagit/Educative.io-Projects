using System;

namespace Path_With_Given_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(0);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(1);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(5);

            Console.WriteLine("Tree has path sequence: " + PathWithGivenSequence.findPath(root, new int[] { 1, 0, 7 }));
            Console.WriteLine("Tree has path sequence: " + PathWithGivenSequence.findPath(root, new int[] { 1, 1, 6 }));
        }
    }

    class PathWithGivenSequence {
        public static bool findPath(TreeNode root, int[] sequence) {
            // TODO: Write your code here
            return Step(root, sequence, 0);
        }

        private static bool Step(TreeNode node, int[] sequence, int depth) {
            if (node == null) return false;
            
            if (node.val == sequence[depth]) {
                if (node.left == null && node.right == null) return true;
                else return Step(node.left, sequence, depth+1) || Step(node.right, sequence, depth +1);
            }
            else return false;

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
