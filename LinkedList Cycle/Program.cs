using System;

namespace LinkedList_Cycle
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
            head.next.next.next.next.next = new ListNode(6);
            Console.WriteLine("LinkedList has cycle: " + LinkedListCycle.hasCycle(head));

            head.next.next.next.next.next.next = head.next.next;
            Console.WriteLine("LinkedList has cycle: " + LinkedListCycle.hasCycle(head));

            head.next.next.next.next.next.next = head.next.next.next;
            Console.WriteLine("LinkedList has cycle: " + LinkedListCycle.hasCycle(head));
        }
    }

    class ListNode {
        internal int value = 0;
        internal ListNode next;

        internal ListNode(int value) {
            this.value = value;
        }
    }

    class LinkedListCycle {
        public static bool hasCycle(ListNode head) {
            ListNode slow = head;
            ListNode fast = head.next;

            bool cyclic = false;
            while (fast != null && fast.next != null) {
                if (slow == fast) {cyclic = true; break;}
                slow = slow.next;
                fast = fast.next.next;
            }

            return cyclic;
        }
    }
}
