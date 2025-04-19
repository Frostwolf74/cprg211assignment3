using System;

namespace Assignment3
{
    [Serializable]
    public class Node
    {
        public User Data;
        public Node Next;

        public Node(User Data)
        {
            this.Data = Data;
            Next = null;
        }
    }
}