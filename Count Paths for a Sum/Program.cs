using System;
using System.Collections.Generic;

namespace Count_Paths_for_a_Sum
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
            Console.WriteLine("Tree has path: " + CountAllPathSum.countPaths(root, 11));
        }
    }

    class CountAllPathSum {
        private int _countPaths = 0;
        public static int countPaths(TreeNode root, int S) {
            // TODO: Write your code here
            CountAllPathSum CAPS = new CountAllPathSum();
            LinkedList<int> list = new LinkedList<int>();
            CAPS.Step(root, S, list, list.First); // start with empty list
            return CAPS._countPaths;
        }

        public void Step(TreeNode node, int S, LinkedList<int> list, LinkedListNode<int> left) {
            if (node == null) return; //dead end

            list.AddLast(node.val); // expand list with the newest value.
            if (left == null) left = list.Last; // left supposed to be the first element after shrinking the window or zeroing it.
            // either this is the very first step or the window width was zero, we need left to be first then
            LinkedListNode<int> right = left; // start with that single element.
            int sum =  left.Value;;

            while (right != null && left != null) {
                if (sum > S) { // if we are over, then shrink the window from the left
                    sum -= left.Value;
                    left = left.Next;
                }
                else if (sum < S) { // if we are under then shring the window to the right
                    right = right.Next;
                    if (right != null) sum += right.Value;
                }
                else {
                    _countPaths++; // if we found one, that's great
                    sum -= left.Value; // and then shrink the window from the left
                    left = left.Next; // to enable moving to the right
                }
            }
            

            if (node.left == null && node.right == null) { // leaf
                //green
            }
            else { // node
                Step(node.left, S, list, left); // carry on with more resources added by moving
                Step(node.right, S, list, left); // along in the tree path
            }

            list.RemoveLast(); // say goodbye to the last item for enabling recursion
            // as we either added it or passed it and got to zero-width window on the right
            // Backtracking, yea baby
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
