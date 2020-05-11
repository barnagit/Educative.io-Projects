using System;
using System.Collections.Generic;

namespace Start_of_LinkedList_Cycle
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

            head.next.next.next.next.next.next = head.next.next;
            Console.WriteLine("LinkedList cycle start: " + LinkedListCycleStart.findCycleStart(head).value);

            head.next.next.next.next.next.next = head.next.next.next;
            Console.WriteLine("LinkedList cycle start: " + LinkedListCycleStart.findCycleStart(head).value);

            head.next.next.next.next.next.next = head;
            Console.WriteLine("LinkedList cycle start: " + LinkedListCycleStart.findCycleStart(head).value);
        }
    }

    class ListNode {
        internal int value = 0;
        internal ListNode next;

        internal ListNode(int value) {
            this.value = value;
        }
    }

    class LinkedListCycleStart {

        public static ListNode findCycleStart(ListNode head) {
            ListNode slow = head;
            ListNode fast = head.next;
            while(slow != fast) {
                slow = slow.next;
                fast = fast.next.next;
            }

            /* THIS IS my original solution */

/*          HashSet<ListNode> visited = new HashSet<ListNode>();
            visited.Add(slow);
            while (!visited.Contains(slow.next)) {
                slow = slow.next;
                visited.Add(slow);
            }

            slow = head;
            while (!visited.Contains(slow)) {
                slow = slow.next;
            } 
            
            return slow;
            */

            /* this is a better one */

            ListNode stop = slow;
            int counter = 0;
            do {
                counter ++;
                slow = slow.next;
            } while (stop != slow);

            ListNode p1 = head;
            ListNode p2 = head;

            for (int i = 0; i < counter; i++) p2 = p2.next;

            while (p1 != p2) {
                p1 = p1.next;
                p2 = p2.next;
            }

            return p1;
        }
    }
}
