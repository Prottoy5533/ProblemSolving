using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }


        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return head;
            var node = head;

            while(node.next != null)
            {
                if(node.val == node.next.val)
                {
                    node.next = node.next.next;
                }
                else
                {
                    node = node.next;

                }
                    
            }

            return head;

        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var newList = new ListNode();
            var current = newList;

            while(list1!= null && list2 !=null)
            {
                if(list1.val < list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                     
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }

                current = current.next;
            }

            if(list1 != null)
            {
                current.next = list1;
            }
            
            if(list2 != null) { 
                current.next = list2;
            
            }

            return newList.next;


        }

        public bool HasCycle(ListNode head)
        {
            var fast = head;
            var slow = head;

            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (fast == slow) return true;
                
            }

            return false;

        }

        public int CycleLength(ListNode head)
        {
            var fast = head;
            var slow = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (fast == slow)
                {
                    int length = 0;
                    var temp = slow;
                    do
                    {
                        slow = slow.next;
                        length++;
                    } while (temp != slow);
                    return length;
                }


            }

            return 0;

        }

        public ListNode DetectCycle(ListNode head)
        {
            int length = 0;

            var fast = head;
            var slow = head;

            while(fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if(fast == slow)
                {
                    length = CycleLength(slow);
                    break;
                }
            }

            if(length == 0) return null;

            var f = head;
            var s = head;

            //find the start node
            while (length > 0)
            {

                s = s.next;
                length--;
            }

            while(f != s)
            {
                f=f.next;
                s=s.next;
            }

            return f;

        }


        public bool IsHappy(int n)
        {
            int slow = n;
            int fast = n;

            do
            {
                slow = FindSquare(slow);
                fast = FindSquare(FindSquare(fast));
            } while( slow != fast );

            if(slow == 1) return true;
            return false;


        }

        private int FindSquare(int num)
        {
            int ans = 0;
            while(num>0)
            {
                int reminder = num % 10;
                ans += reminder * reminder;
                num /= 10;
            }

            return ans;
        }

        public ListNode MiddleNode(ListNode head)
        {
            var slow = head;
            var fast = head;

            // double speed er ta jokhn 100% hobe half speed er ta tokhn 50% hobe.
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

            }

            return slow;

        }

        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
                

            var mid = MiddleNode(head);
            var left = SortList(head);
            var right = SortList(mid);

            return MergeTwoLists(left, right);


        }
    }

    


}
