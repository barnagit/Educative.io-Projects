using System;

namespace Reverse_every_K_element_Sub_list
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
            head.next.next.next.next.next.next = new ListNode(7);
            head.next.next.next.next.next.next.next = new ListNode(8);

            ListNode result = ReverseEveryKElements.reverse(head, 3);
            Console.WriteLine("Nodes of the reversed LinkedList are: ");
            while (result != null) {
            Console.WriteLine(result.value + " ");
            result = result.next;
            }
        }
    }

    class ReverseEveryKElements {

        public static ListNode reverse(ListNode head, int k) {
            // TODO: Write your code here
            int c = 0;
            ListNode p1 = null, p2, s, e, ss;
            p2 = head;
            while (p2 != null) {
                s = p1;
                ss = p2;
                for (c = 0; c < k; c++) {
                    if (p2==null) break;
                    ListNode t = p2.next;
                    p2.next = p1;
                    p1 = p2;
                    p2 = t;
                }
                e = p2;
                if (s != null) s.next = p1;
                else head = p1;
                ss.next = p2;
                p1 = ss;
            }

            return head;
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
