using System;

namespace Reverse_a_Sub_list
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            ListNode result = ReverseSubList.reverse(head, 1, 4);
            Console.WriteLine("Nodes of the reversed LinkedList are: ");
            while (result != null) {
                Console.WriteLine(result.value + " ");
                result = result.next;
            }
        }
    }

    class ReverseSubList {

        public static ListNode reverse(ListNode head, int p, int q) {
            // TODO: Write your code here
            int i = 0;
            ListNode p1 = null, p2 = head;
            while (i<p-1) {
                p1 = p2;
                p2 = p2.next;
                i++;
            }
            ListNode s = p1;
            ListNode ss = p2;
            while (i < q) {
                ListNode t = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = t;
                i++;
            }
            if (s != null) {
                s.next.next = p2;
                s.next = p1;
            } else {
                head = p1;
                ss.next = p2;
            }

            return head;
        }
    }

    internal class ListNode {
        internal int value = 0;
        internal ListNode next;

        internal ListNode(int value) {
            this.value = value;
        }
    }
}
