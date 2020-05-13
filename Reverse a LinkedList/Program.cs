using System;

namespace Reverse_a_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ListNode head = new ListNode(2);
            head.next = new ListNode(4);
            head.next.next = new ListNode(6);
            head.next.next.next = new ListNode(8);
            head.next.next.next.next = new ListNode(10);

            ListNode result = ReverseLinkedList.reverse(head);
            Console.Write("Nodes of the reversed LinkedList are: ");
            while (result != null) {
            Console.Write(result.value + " ");
            result = result.next;
    }
        }
    }

    class ReverseLinkedList {

        public static ListNode reverse(ListNode head) {
            // TODO: Write your code here
            ListNode p1 = null;
            ListNode p2 = head.next;

            while (p2 != null) {
                ListNode next = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = next;

            }

            return p1;
        }
    }

    class ListNode {
        internal int value = 0;
        internal ListNode next;

        internal ListNode(int value) {
            this.value = value;
        }
    }
}
