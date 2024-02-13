using System;
using System.Collections.Generic;
using System.Text;
namespace LList
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public override string ToString() => Data.ToString();
    }

    public class LList<T>
    {
        Node<T> head; // bosh/birinchi element
        public void Print()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        public int Count()
        {
            int count = 0;
            Node<T> current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        // ro‘yxat boshiga qo‘shish
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
        }
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> current = head;
            if (current == null)
                head = node;
            else
            {
                while (current.Next != null)
                { current = current.Next; }
                current.Next = node;
            }
        }
        public void Insert(T data, int pos)
        {
            int k = 1;
            Node<T> node = new Node<T>(data);
            Node<T> current = head;
            while (current.Next != null && k < pos)
            { k++; current = current.Next; }
            node.Next = current.Next;
            current.Next = node;
        }
        public void Delete(int pos)
        {
            int k = 1;
            Node<T> current = head;
            Node<T> previous = null;
            while (current.Next != null && k < pos)
            {
                k++; previous = current; current = current.Next;
            }
            if (pos <= 1) head = head.Next;
            else previous.Next = current.Next;
        }
        public void Clear()
        {
            head = null;
        }

        public void TarkorlaBirinchiMusbat()
        {
            Node<T> cur = head;
            int k = 1;
            while (cur != null)
            {
                if (Convert.ToInt32(cur.Data) > 0)
                {
                    Insert(cur.Data, k);
                    break;
                    //Node<T> tugun = new Node<T>(cur.Data);
                    //cur.Next = tugun;
                    //tugun.Next = cur.Next;
                }
                cur = cur.Next;
                k++;
            }
        }

        public void TarkorlaBerilgan(T data1)
        {
            Node<T> cur = head;
            //int k = 1;
            while (cur != null)
            {
                if (Convert.ToInt32(cur.Data) > Convert.ToInt32(data1))
                {
                    Node<T> tugun = new Node<T>(cur.Data);
                    tugun.Next = cur.Next;
                    cur.Next = tugun;

                    cur = cur.Next;

                }
                cur = cur.Next;
                // k++;
            }
        }

        public void Doubled()
        {
            Node<T> current = head;
            while (current != null)
            {
                current.Data = (T)Convert.ChangeType(Convert.ToInt32(current.Data) * 2, typeof(T));
                current = current.Next;
            }
        }

        public void AddElements(T data, int count)
        {
            if (count <= 0)
            {
                return; 
            }


            for (int i = 0; i < count; i++)
            {
                Node<T> newNode = new Node<T>(data);
                newNode.Next = head;
                head = newNode;
            }
        }

        public T MaxElement()
        {
            if (head == null)
            {
                Console.WriteLine("Ro'yxat bo'sh");
            }

            T maxData = head.Data;
            Node<T> current = head.Next;

            while (current != null)
            {
                if (Comparer<T>.Default.Compare(current.Data, maxData) > 0)
                {
                    maxData = current.Data;
                }
                current = current.Next;
            }

            return maxData;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            LList<int> linkedList = new LList<int>();
            // Elementlar qo‘shish
            linkedList.Add(-13);
            linkedList.Add(10);
            linkedList.Add(0);
            linkedList.Add(32);
           // linkedList.TarkorlaBirinchiMusbat();
            linkedList.AddElements(4, 5);

            linkedList.Print();
            Console.WriteLine("Max: ");
            Console.WriteLine( linkedList.MaxElement());
        }
    }
}


