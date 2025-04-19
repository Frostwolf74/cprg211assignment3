namespace Assignment3
{
    public class Node
    {
        public string data;
        public Node? Next;

        public Node(string data)
        {
            this.data = data;
            Next = null;
        }
    }
}