using System;
using System.Collections.Generic;

namespace Connect_Level_Order_Siblings
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
            ConnectLevelOrderSiblings.connect(root);
            Console.WriteLine("Level order traversal using 'next' pointer: ");
            root.printLevelOrder();
        }
    }

    class ConnectLevelOrderSiblings {
        public static void connect(TreeNode root) {
            // TODO: Write your code here
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int sizeOfLevel;

            while (queue.Count>0) {
                sizeOfLevel = queue.Count;
                TreeNode p = null;
                for (int i = 0; i < sizeOfLevel; i++) {
                    TreeNode n = queue.Dequeue();
                    if (p != null) p.next = n;
                    p = n;

                    if (n.left != null) queue.Enqueue(n.left);
                    if (n.right != null) queue.Enqueue(n.right);
                }

            }

        }
    }

    class TreeNode {
        internal int val;
        internal TreeNode left;
        internal TreeNode right;
        internal TreeNode next;

        internal TreeNode(int x) {
            val = x;
        }

        internal void printLevelOrder() {
            TreeNode nextLevelRoot = this;
            while (nextLevelRoot != null) {
                TreeNode current = nextLevelRoot;
                nextLevelRoot = null;
                while (current != null) {
                    Console.Write(current.val + " ");
                    if (nextLevelRoot == null) {
                        if (current.left != null)
                            nextLevelRoot = current.left;
                        else if (current.right != null)
                            nextLevelRoot = current.right;
                    }
                    current = current.next;
                }
                Console.WriteLine();
            }
        }
    }
}
