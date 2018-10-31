using System;
/*Given a singly linked list, find middle of the linked list. 
             * For example, if given linked list is 1->2->3->4->5 then output should be 3. 
                If there are even nodes, then there would be two middle nodes, we need to print second middle element. 
               For example, if given linked list is 1->2->3->4->5->6 then output should be 4.
             * */
namespace LinkedList_21
{
    public class Node
    {
        public int data;
        public Node next;
        public Node()
        {
            data = 0;
            next = null;
        }
        public Node(int value)
        {
            data = value;
            next = null;
        }
    }
    
    public class MyLL
    {
        public Node head;

        public void AddTail(int val)
        {        
            Node nodenew = new Node(val);
            if (head == null)
            {
                head = nodenew;
            }
            else
            {
                Node node = head;
                while (node.next != null)
                {
                    node = node.next;
                }
                node.next = nodenew;
            }
        }

        public Node MiddleLL()
        {
            if (head == null) return null;
            Node slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }

        public Node RotateLL(int k)
        {
            if (k == 0) return null;
            if (head == null) return null;
            /* Given a singly linked list, rotate the linked list counter-clockwise by k nodes. 
             * Where k is a given positive integer smaller than or equal to length of the linked list. 
             * For example, if the given linked list is 10->20->30->40->50->60 and k is 4, 
             * the list should be modified to 50->60->10->20->30->40.
             * */
            Node nodeh = head;
            Node nodek = head, nodetail = head;
            int i = 1;
            while (nodetail.next != null)
            {
                if (i < k)
                {
                    nodek = nodek.next;
                    i++;
                }
                nodetail = nodetail.next;

            }
            //k is greater than or equal to count 
            // of nodes in linked list. Don't change the list in this case
            if (i < k)
                return head;

            head = nodek.next;
            nodek.next = null;
            nodetail.next = nodeh;
            return head;
        }

        public Node ReverseKNode(Node head, int k)
        {
            /* Given a linked list, write a function to reverse every k nodes 
             * (where k is an input to the function).
             * If a linked list is given as 1->2->3->4->5->6->7->8->NULL and k = 3 
             * then output will be 3->2->1->6->5->4->8->7->NULL.
             * */
            if (head == null) return null;

            Node prev = null;
            Node cur = head;
            Node next = head;
            int i = 0;
            while (cur != null && i < k)
            {
                next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
                i++;
            }
            if (next != null)
                head.next = ReverseKNode(next, k);

            return prev;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            MyLL myLL = new MyLL();
            myLL.AddTail(10);
            myLL.AddTail(20);
            myLL.AddTail(30);
            myLL.AddTail(40);
            myLL.AddTail(50);
            myLL.AddTail(60);
            myLL.AddTail(70);
            myLL.AddTail(80);

            /*Node node = myLL.MiddleLL();
            if (node == null)
                Console.WriteLine("Linked List is empty");
            else
                Console.WriteLine("Middle is " + node.data);


            node = myLL.RotateLL(7);
            while (node.next != null)
            {
                Console.WriteLine(node.data + "->");
                node = node.next;
            }
            Console.WriteLine(node.data);
            */

            Node node = myLL.head;
            string userInput;
            int k;
            
            Console.Write("Enter kth value: ");
            userInput = Console.ReadLine();
            /* Converts to integer type */
            k = Convert.ToInt32(userInput);

            node = myLL.ReverseKNode(node, k);
        }
    }
}
