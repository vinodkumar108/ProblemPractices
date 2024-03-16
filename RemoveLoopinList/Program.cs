using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveLoopinList
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public ListNode solve(ListNode A)
        {

            ListNode P1 = findMeetingPointer(A);
            ListNode P2 = A;

            while (P2 != null)
            {
                P1 = P1.next;
                P2 = P2.next;
                if (P1 == P2)
                {
                    P1.next = null;
                    break;
                }
            }

            return A;
        }
        public ListNode findMeetingPointer(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast) return slow;
            }
            return null;
        }
    }

    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { this.val = x; this.next = null; }
    }
}
