using System;
using System.Collections.Generic;

namespace Sum_of_Path_Number
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
            Console.WriteLine("Total Sum of Path Numbers: " + SumOfPathNumbers.findSumOfPathNumbers(root));
        }
    }

    class SumOfPathNumbers {
        List<int> _numbers = new List<int>();
        public static int findSumOfPathNumbers(TreeNode root) {
            // TODO: Write your code here
            SumOfPathNumbers SoPN = new SumOfPathNumbers();
            //SoPN.Step(root, "");
            //int sum = 0;
            // foreach (int i in SoPN._numbers) sum+=i;
            //return sum;
            
            return SoPN.Step(root, 0);
        }
        // this is my string solution
        public void Step(TreeNode node, string path) {
            if (node == null) return;

            path = path + node.val;

            if (node.left == null && node.right == null) {
                
                _numbers.Add(Int32.Parse(path));
            }
            else {
                Step(node.left, path);
                Step(node.right, path);
            }
        }

        // this is a number based clever solution
        public int Step(TreeNode node, int sum) {
            if (node == null) return 0;

            // cleverly just shift left (in radix 10) and add current
            sum = sum*10 + node.val;

            // this represent the value at the leaf
            if (node.left == null && node.right == null) return sum;

            // very cleverly done collecting all the leaf sums at branches. 
            else return Step (node.left, sum) + Step (node.right, sum);
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
