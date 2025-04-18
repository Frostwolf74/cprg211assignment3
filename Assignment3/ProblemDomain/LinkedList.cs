using System;

namespace Assignment3
{
    public class LinkedList
    {
        public int count { get; private set; }
        private Node? head { get; set; }

        public void AddFirst(string value)
        {
            Node node = new(value);
            node.Next = head;
            head = node;
            ++count;
        }

        public void AddLast(string value)
        {
            if (head == null)
            {
                head = new Node(value);
            }
            else
            {
                Node current = head;

                while (current.Next != null)
                {
                    current = current.Next;
                }
                
                current.Next = new Node(value);
            }

            ++count;
        }
        
        public bool RemoveFirst()
        {
            if (head == null) return false;

            head = head.Next;
            --count;

            return true;
        }

        public bool RemoveLast()
        {
            if (head == null) return false;

            if (head.Next == null)
            {
                head = null;
                --count;
                
                return true;
            }
            
            Node? current = head;

            while (current.Next != null)
            {
                current = current.Next;
            }
            
            current.Next = null;
            --count;

            return true;
        }
        
        // remove at index
        public bool Pop(int index)
        {
            Node? current = head;
            Node? partialList1 = head;
            Node? partialList2 = null;
            int countOfPartial1 = index;
            
            for (int i = 0; i < index; ++i)
            {
                if (current == null) return false; // if the specified index doesnt exist 
                
                current = current?.Next; // iterate through each item until we reach the index
            }
            
            partialList2 = current;
            partialList2 = partialList2?.Next; // shift the second half of the list forward effectively deleting the popped index
            
            return true;
        }

        // get at index
        public Node? Get(int index)
        {
            Node? current = head;

            for (int i = 0; i < index; ++i)
            {
                if (current == null) return null;
                
                current = current?.Next;
            }
            
            return current;
        }

        public void PopAll()
        {
            head = null;
        }
        
        public int Count()
        {
            return count;
        }
    }
}