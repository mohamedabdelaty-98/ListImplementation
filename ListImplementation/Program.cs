using ListImplementation.LinkedList;

namespace ListImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region List Using Array
            //MyList<int> list = new MyList<int>();
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            //list.Add(4);
            ////list.Add(5);
            ////list.Add(6);
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("----------------------------");
            //list.InsertAt(4, 45);
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //list.RemoveAt(0);
            //Console.WriteLine("----------------------------");
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //list.InsertAt(4, 55);
            //Console.WriteLine("----------------------------");
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(list.Search(555));
            //Console.WriteLine(list.Search(55));
            //Console.WriteLine(list.GetByIndex(4));
            ////Console.WriteLine(list.GetByIndex(45));
            //list.UpdateAt(0, 15);
            //Console.WriteLine("----------------------------");
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion
            #region LinkedList
            //LinkedListImplementation<int> list=new LinkedListImplementation<int>();
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            //list.Add(4);
            //list.Add(5);
            ////list.InsertAtBegain(11);
            ////list.InsertAtBegain(15);
            ////list.InsertAt(1, 55);
            ////list.InsertAt(0, 0);
            ////list.InsertAt(7, 54);
            ////list.RemoveFromFisrt();
            ////list.RemoveFromFisrt();
            ////list.RemoveFromLast();
            ////list.RemoveFromLast();
            ////list.RemoveAt(3);
            //list.Remove(2);
            //list.Print();
            //Console.WriteLine("------------------------");
            //list.Reverse();
            //list.Print();
            //Console.WriteLine(list.Search(12)); 
            #endregion
            DoublyLinkedList<int> list=new DoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(34);
            //list.InsertAtBegining(4);
            list.InsertAt(1, 22);
            //list.RemoveFromFirst();
            //list.RemoveFromFirst();
            //list.RemoveFromLast();
            //list.RemoveAt(3);
            list.Remove(34);
            list.Remove(3);
            list.Print();
            list.ReversePrint();
        }
    }
}