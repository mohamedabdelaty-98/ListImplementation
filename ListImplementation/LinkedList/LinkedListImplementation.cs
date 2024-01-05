using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ListImplementation.LinkedList
{
    internal class LinkedListImplementation<T>
    {
        Node<T> Head, Tail;
        public int Count { get; private set; }
        public LinkedListImplementation()
        {
            Head = Tail = null;
            Count = 0;
        }
        private bool IsEmpty() => Count == 0;
        public void Add(T item)
        {
            Node<T> newnode = new Node<T>();
            newnode.Value = item;
            //base case
            if(IsEmpty())
            {
                Head = Tail = newnode;
                newnode.Next = null;
                Count++;
            }
            else
            {
                Tail.Next = newnode;
                Tail= newnode;
                newnode.Next = null;
                Count++;
            }
        }
        public void InsertAtBegain(T item)
        {
            Node<T> newnode=new Node<T>();
            newnode.Value = item;
            //base case
            if(IsEmpty())
            {
                Head = Tail = newnode;
                newnode.Next = null;
                Count++;
            }
            else
            {
                newnode.Next = Head;
                Head = newnode;
                Count++;
            }
        }
        public void InsertAt(int posetion,T item)
        {
            
            if (posetion == 0)
                InsertAtBegain(item);
            else if (posetion == Count)
                Add(item);
            else
            {
                Node<T> newnode = new Node<T>();
                Node<T> Current = Head;
                newnode.Value = item;
                for (int i = 1; i < posetion; i++)
                    Current = Current.Next;
                newnode.Next = Current.Next;
                Current.Next = newnode;
                Count++;
            }
        }
        public void RemoveFromFisrt()
        {
            if (IsEmpty())
                throw new Exception("List is empty");
            else if (Count == 1)
            {
                Head = Tail = null;
                Count--;
            }
            else
            {
                Head = Head.Next;
                Count--;
            }
        }
        public void RemoveFromLast()
        {
            if (IsEmpty())
                throw new Exception("List is empty");
            else if (Count == 1)
            {
                Head = Tail = null;
                Count--;
            }
            else
            {
                Node<T> prev = Head;
                Node<T> Current = Head.Next;
                while(Current!=Tail)
                {
                    prev = Current;
                    Current = Current.Next;
                }
                Tail = prev;
                prev.Next = null;
                Count--;
            }
        }
        public void RemoveAt(int index)
        {
            if(IsEmpty())
                throw new Exception("List is empty");
            if (index == 0)
                RemoveFromFisrt();
            else if (index == Count-1)
                RemoveFromLast();
            else if(index<0||index>=Count)
                throw new Exception("index out of range");
            else
            {
                Node<T> Prev = Head;
                Node<T> Cureent = Head.Next;
                for(int i=1;i<index;i++)
                {
                    Prev = Cureent;
                    Cureent = Cureent.Next;
                }
                Prev.Next = Cureent.Next;
                Cureent = null;
                Count--;
            }

        }
        public void Remove(T Element)
        {
            if (IsEmpty())
                throw new Exception("List is empty");
            if (EqualityComparer<T>.Default.Equals(Head.Value, Element))
            {
                RemoveFromFisrt();
                return;
            }
            else
            {
                Node<T> Prev = Head;
                Node<T> Current = Head.Next;
                while (Current != null)
                {
                    if (EqualityComparer<T>.Default.Equals(Current.Value, Element))
                    {
                        Prev.Next = Current.Next;
                        Current = null;
                        Count--;
                        return;
                    }
                    Prev = Current;
                    Current = Current.Next;
                }
                throw new Exception("Item Not Found");
            }
        }
        public void Reverse()
        {
            Node<T> Current = Head;
            Node<T> Next = Current.Next;
            Node<T> Prev = null;
            while(Current != null)
            {
                Next = Current.Next;
                Current.Next = Prev;
                Prev = Current;
                Current = Next;
            }
            Head = Prev;
        }
        public bool Search(T item)
        {
            Node<T> Current = Head;
            while (Current != null)
            {
                if (EqualityComparer<T>.Default.Equals(Current.Value, item))
                    return true;
                Current = Current.Next;
            }
            return false;
        }
        public void Print()
        {
            if (!IsEmpty())
            {
                Node<T> current = Head;
                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    current = current.Next;
                }
            }
            else
                throw new Exception("List is empty");
        }
     
    }
}
