using System;

namespace Middle_of_the_LinkedList
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
            Console.WriteLine("Middle Node: " + MiddleOfLinkedList.findMiddle(head).value);

            head.next.next.next.next.next = new ListNode(6);
            Console.WriteLine("Middle Node: " + MiddleOfLinkedList.findMiddle(head).value);

            head.next.next.next.next.next.next = new ListNode(7);
            Console.WriteLine("Middle Node: " + MiddleOfLinkedList.findMiddle(head).value);
        }
    }


    class ListNode {
        internal int value = 0;
        internal ListNode next;

        internal ListNode(int value) {
            this.value = value;
        }
    }

    class MiddleOfLinkedList {

        public static ListNode findMiddle(ListNode head) {
            ListNode slow = head;
            ListNode fast = head.next;
            while (fast != null) {
                fast = fast.next;
                if(fast != null) fast = fast.next;
                slow = slow.next;
            }
            return slow;
        }
    }
}
