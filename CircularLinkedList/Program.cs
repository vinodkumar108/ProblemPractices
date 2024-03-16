using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLinkedList
{
   
 ////////////Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { this.val = x; this.next = null; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ListNode N1 = new ListNode(6);
            ListNode N2 = new ListNode(5);
            ListNode N3 = new ListNode(5);
            ListNode N4 = new ListNode(3);
            ListNode N5 = new ListNode(8);

            N1.next = N2;
            N2.next = N3;
            N3.next = N4;
            N4.next = N5;

            ListNode N = solve(N1);

            while(N != null)
            {
                Console.Write(N.val + ",");
                N = N.next;
            }

            Console.Read();

        }
        public static ListNode solve(ListNode A)
        {

            ListNode head = A;
            ListNode head1 = A;
            ListNode head2 = MeetingPoint(A);

            if (head2 == null) return head;

            while (head1 != head2)
            {
                head2 = head2.next;
                head1 = head1.next;
            }

            head1.next = null;
            return head;
        }
        public static ListNode MeetingPoint(ListNode head)
        {
            ListNode slow = head.next;
            ListNode fast = head.next.next;

            while (fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast) return slow;
            }

            return null;

        }
    }
}
