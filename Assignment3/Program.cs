using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            
            list.AddLast("a");
            list.AddLast("b");
            list.AddLast("c");
            list.AddLast("d");
            list.AddLast("e");
            list.AddLast("f");

            for (int i = 0; i < list.count; ++i)
            {
                Console.Write(list.Get(i)?.data);
            }

            Console.WriteLine();
            
            list.Pop(3);
            
            for (int i = 0; i < list.count; ++i)
            {
                Console.Write(list.Get(i)?.data);
            }
        }
    }
}
