using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ListImplementation.LinkedList
{
    internal class DoublyLinkedList<T>
    {
        Node<T> Head;
        Node<T> Tail;
        public int Count { get; private set; }
        public DoublyLinkedList()
        {
            Head = Tail = null;
            Count = 0;
        }
        private bool IsEmpty()=>Count == 0;
        public void Add(T item)
        {
            Node<T> newnode = new Node<T>();
            newnode.Value = item;
            if (IsEmpty())
            {
                Head = Tail = newnode;
                newnode.Next = newnode.Previous = null;
            }
            else
            {
                newnode.Previous = Tail;
                newnode.Next = null;
                Tail.Next = newnode;
                Tail = newnode;
            }
            Count++;
        }
        public void InsertAtBegining(T item)
        {
            Node<T> newnode = new Node<T>();
            newnode.Value = item;
            if(IsEmpty())
            {
                Head = Tail = newnode;
                newnode.Previous = newnode.Next = null;
            }
            else
            {
                newnode.Next = Head;
                newnode.Previous = null;
                Head.Previous = newnode;
                Head = newnode;
            }
            Count++;
        }
        public void InsertAt(int Posetion,T item)
        {
            if (Posetion < 0 || Posetion > Count)
                throw new Exception("List out of range");
            else
            {
                if (Posetion == 0)
                    InsertAtBegining(item);
                else if (Posetion == Count)
                    Add(item);
                else
                {
                    Node<T> current = Head;
                    Node<T> newnode = new Node<T>();
                    newnode.Value = item;
                    for (int i = 1; i < Posetion; i++)
                        current = current.Next;
                    newnode.Next = current.Next;
                    newnode.Previous = current;
                    current.Next.Previous = newnode;
                    current.Next = newnode;
                    Count++;
                }

            }
        }
        public void RemoveFromFirst()
        {
            if(IsEmpty())
                throw new Exception("List is empty");
            else if(Count==1)
            {
                Head = Tail = null;
                
            }
            else
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            Count--;
        }
        public void RemoveFromLast()
        {
            if (IsEmpty())
                throw new Exception("List is empty");
            else if (Count == 1)
                Head = Tail = null;
            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            Count--;
        }
        public void RemoveAt(int posetion)
        {
            if (posetion < 0 || posetion > Count)
                throw new Exception("Out of range");
            else if (posetion == 0)
                RemoveFromFirst();
            else if (posetion == Count)
                RemoveFromLast();
            else
            {
                Node<T> current = Head.Next;
                for(int i=1;i<posetion;i++)
                {
                    current=current.Next;
                }
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
                current = null;
            }
            Count--;
        }
        public void Remove(T item)
        {
            if (IsEmpty())
                throw new Exception("List is Empty");
            else if (EqualityComparer<T>.Default.Equals(Head.Value, item))
            {
                RemoveFromFirst();
                return;
            }
            else if(EqualityComparer<T>.Default.Equals(Tail.Value, item))
            {
                RemoveFromLast();
                return;
            }
            else
            {
                Node<T> current = Head.Next;
                while (current != null)
                {
                    if (EqualityComparer<T>.Default.Equals(current.Value, item))
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                        current = null;
                        Count--;
                        return;
                    }
                    current = current.Next;
                }
                throw new Exception("Item Not Found");
            }
        }
        public void ReversePrint()
        {
            if (IsEmpty())
                throw new Exception("List is empty");
            else
            {
                Node<T> current = Tail;
                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    current = current.Previous;
                }
            }
        }

        public void Print()
        {
            if (IsEmpty())
                throw new Exception("List is empty");
            else
            {
                Node<T> current = Head;
                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    current = current.Next;
                }
            }
        }
    }
}
