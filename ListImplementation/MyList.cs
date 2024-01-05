using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListImplementation
{
    internal class MyList<T>:IEnumerable
    {
        T[] arr;
        int LastIndex, size;
        public MyList(int size=5)
        {
            this.size=size<=0 ? 5 : size;
            arr = new T[size];
            LastIndex = -1;
        }
        private void Extend(int size)
        {
            this.size = size;
            T[]newarr= new T[this.size];
            Array.Copy(arr,newarr,arr.Length);
            arr = newarr;
        }
        private bool IsFulll()=>LastIndex==size-1;
        private bool IsEmpty() => LastIndex < 0;
        public void Add(T item)
        {
            if (!IsFulll())
                arr[++LastIndex] = item;
            else
            {
                Extend(size * 2);
                arr[++LastIndex]=item;
            }
        }
        public void InsertAt(int Posetion,T item)
        {
            if (IsFulll())
                Extend(size * 2);
            //throw new ArgumentOutOfRangeException("Posetion out if range");
            if (Posetion < 0 || Posetion > arr.Length-1)
                throw new ArgumentOutOfRangeException("Posetion out if range");
            //shift right
            for (int i = arr.Length-1; i > Posetion; i--)
                arr[i] = arr[i - 1];
            arr[Posetion]= item;
            LastIndex++;
        }
        public void RemoveAt(int Posetion)
        {
            if(IsEmpty())
                throw new ArgumentOutOfRangeException("List Is Empty");
            if(Posetion<0||Posetion>arr.Length-1)
                throw new ArgumentOutOfRangeException("Posetion out if range");
            //shift left
            for(int i=Posetion;i<arr.Length-1;i++)
                arr[i] = arr[i+1];
            LastIndex--;

        }
        public bool Search(T item)
        {
            for(int i=0;i<arr.Length;i++ )
            {
                if (arr[i].Equals(item))
                    return true;
            }
            return false;
        }
        public T GetByIndex(int index)
        {
            if (index < 0 || index > size - 1)
                throw new Exception("index Out of range");
            else
                return arr[index];
        }
        public void UpdateAt(int position,T item)
        {
            if (position < 0 || position > size - 1)
                throw new Exception("Out of range ");
            else
                arr[position] = item;
        }
        public IEnumerator GetEnumerator()
        {
            return new Iterator(this);
        }
        class Iterator : IEnumerator
        {
            int currentindex;
            MyList<T> list;
            public Iterator(MyList<T> list)
            {
                currentindex = -1;
                this.list = list;
            }
            public object Current => list.arr[currentindex];

            public bool MoveNext()
            {
                currentindex++;
                return currentindex <= list.LastIndex;
            }

            public void Reset()
            {
                currentindex = -1;
            }
        }
    }
}
