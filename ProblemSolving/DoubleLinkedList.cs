using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public class DoubleLinkedList
    {
        Node head;

        public void insertFirst(int val)
        {
            var node = new Node(val);
            node.next = head;
            node.prev = null;
            if(head != null)
            {
                head.prev= node;
            }
            head = node;

        }

        public void insertIndex(int val,int index)
        {
            var node = new Node(val);
            var temp = head;

            for(int i = 1; i <index;i++)
            {
                temp= temp.next;    
            }

            node.next = temp.next;
            temp.next = node;
            node.prev = temp;
            if(node.next!= null)
               node.next.prev = node;



        }

        public void insertAfter(int val, int after)
        {
            var node = new Node(val);
            var temp = head;

            while(temp != null && temp.val != after  )
            {
                temp = temp.next;

            }
            if(temp == null)
            {
                Console.WriteLine("Does not exist");
                return;
            }
                

            node.next = temp.next;
            temp.next = node;
            node.prev = temp;
            if (node.next != null)
                node.next.prev = node;



        }


        public void display()
        {
            var node = head;
            while(node != null)
            {
                Console.Write(node.val +" -> ");
                node = node.next;
            }
            Console.WriteLine();
        }

        public void displayReverse()
        {
            var node = head;
            Node last= null;
            while (node != null)
            {
                last = node;
                node = node.next;
            }

            while(last != null)
            {
                Console.Write(last.val +" -> ");
                last = last.prev;
            }
            Console.WriteLine();
        }

        public void insertLast(int val)
        {
            var node = new Node(val);

            var temp = head;

            if(head== null)
            {
                head = node;
                head.prev = null;
                return;
            }

            while(temp.next != null)
            {
                temp= temp.next;    
            }

            temp.next = node;
            node.prev = temp;
            node.next = null;

        }

        public class Node
        {
            public int val { get; set; }
            public Node next { get; set; }
            public Node prev { get; set; }
         
            public Node(int val) { this.val = val; }

            public Node(int val, Node next, Node prev) 
            {
                this.val = val;
                this.next = next;
                this.prev = prev;
            }
        }

    }
}
