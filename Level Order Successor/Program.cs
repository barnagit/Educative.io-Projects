using System;
using System.Collections.Generic;

namespace Level_Order_Successor
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
            TreeNode result = LevelOrderSuccessor.findSuccessor(root, 12);
            if (result != null)
                Console.WriteLine(result.val + " ");
            result = LevelOrderSuccessor.findSuccessor(root, 9);
            if (result != null)
                Console.WriteLine(result.val + " ");
        }
    }

        class LevelOrderSuccessor {
        public static TreeNode findSuccessor(TreeNode root, int key) {
            // TODO: Write your code here
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int levelSize = 0;
            bool keyFound = false;
            while (queue.Count>0) {
                levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++) {
                    TreeNode n = queue.Dequeue();
                    if (keyFound) {
                        return n;
                    } else {
                        keyFound = n.val == key;
                    }
                    if (n.left != null) queue.Enqueue(n.left);
                    if (n.right != null) queue.Enqueue(n.right);
                }
            }
            return null;    
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
