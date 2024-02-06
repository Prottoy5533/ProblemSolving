using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public class CircularLinkedList
    {
        Node head;
        Node tail;
        public class Node
        {
            public int val { get; set; }
            public Node next { get; set; }

            public Node(int val) { this.val = val; }
            public Node(int val, Node next)
            {
                this.val = val;
                this.next = next;
            }
        }

        public void insert(int val)
        {
            Node node = new Node(val);
            if(head == null)
            {
                head = node;
                tail = node;
                return;
            }

            tail.next = node;
            node.next = head;
            tail = node;
        }

        public void display()
        {
            var node = head;
            if(head!= null)
            {
                do
                {
                    Console.Write(node.val + "-> ");
                    node = node.next;
                } while (node != head);
            }
            
        }

        public void delete(int val)
        {
            Node node = head;
            if (node == null)
                return;
            if(node.val == val)
            {
                head = head.next;
                tail.next = head;
                return;
            }

            do
            {
                Node n = node.next;
                if(n.val == val)
                {
                    node.next = n.next;
                    break;
                }
                node = node.next;
            }while(node != head);
        }

       
    }
}
