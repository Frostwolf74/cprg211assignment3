using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using Assignment3;
using System.Xml.Linq;

namespace Assignment3
{
    [Serializable]
    [DataContract]
    public class SLL : ILinkedListADT
    {
        private Node head;

        public void Add(User item) => AddLast(item);

        public void AddFirst(User item)
        {
            var newNode = new Node(item) { Next = head };
            head = newNode;
        }

        public void AddLast(User item)
        {
            var newNode = new Node(item);
            if (head == null)
                head = newNode;
            else
            {
                var current = head;
                while (current.Next != null)
                    current = current.Next;
                current.Next = newNode;
            }
        }

        public void Insert(User item, int index)
        {
            if (index == 0) AddFirst(item);
            else
            {
                var newNode = new Node(item);
                var current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    if (current == null) throw new IndexOutOfRangeException();
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }

        public void Replace(User item, int index)
        {
            var current = head;
            for (int i = 0; i < index; i++)
            {
                if (current == null) throw new IndexOutOfRangeException();
                current = current.Next;
            }
            current.Data = item;
        }

        public int Count()
        {
            int count = 0;
            var current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public User GetValue(int index)
        {
            var current = head;
            for (int i = 0; i < index; i++)
            {
                if (current == null) throw new IndexOutOfRangeException();
                current = current.Next;
            }
            return current.Data;
        }

        public int IndexOf(User item)
        {
            int index = 0;
            var current = head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                    return index;
                index++;
                current = current.Next;
            }
            return -1;
        }

        public bool Contains(User item) => IndexOf(item) != -1;

        public bool IsEmpty() => head == null;

        public void Clear() => head = null;

        public void Remove(int index)
        {
            if (index == 0) { RemoveFirst(); return; }
            var current = head;
            for (int i = 0; i < index - 1; i++)
            {
                if (current == null || current.Next == null) throw new IndexOutOfRangeException();
                current = current.Next;
            }
            current.Next = current.Next?.Next;
        }

        public void RemoveFirst()
        {
            if (head == null) throw new InvalidOperationException("List is empty.");
            head = head.Next;
        }

        public void RemoveLast()
        {
            if (head == null) throw new InvalidOperationException("List is empty.");
            if (head.Next == null) head = null;
            else
            {
                var current = head;
                while (current.Next.Next != null)
                    current = current.Next;
                current.Next = null;
            }
        }

        public void Reverse()
        {
            Node prev = null, current = head, next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }

        public byte[] SerializeToBytes()
        {
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, this);
                return ms.ToArray();
            }
        }

        public static SLL DeserializeFromBytes(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                return (SLL)new BinaryFormatter().Deserialize(ms);
            }
        }
    }
}
