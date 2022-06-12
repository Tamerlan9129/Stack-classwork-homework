using System;
using System.Collections;
namespace Stack_classwork
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stack<int> adas = new Stack<int>();
            //adas.Push(56);
            //adas.Push(43);
            //adas.Push(36);
            //foreach (var item in adas)
            //{
            //    Console.WriteLine(item);
            //}
            //int[] newArr = { 35, 42, 36, 55 };
            //MyList<int> list = new MyList<int>();
            //list.Add(5);
            //list.Add(6);
            //list.Add(8);
            //list.Add(9);
            //list.Add(65);
            //list.TrimToSize();
            //Console.WriteLine($"Capacity =  { list.Capacity}");

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            MyCircular<int> list = new MyCircular<int>();
            list.AddFirst(5);
            list.AddFirst(8);
            list.AddFirst(9);
            list.AddLast(12);
            list.AddAfter(list.Head.Next, 65);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            
        }

    }

    class MyStack<T>:IEnumerable
    {
        private int Capacity { get; set; }
        public int Count { get; set; }
        private T[] _arr;
        public MyStack() 
        {
            Capacity = 4;
            _arr = new T[Capacity];
        }
        public MyStack(int capacity)
        {
            Capacity = capacity;
            _arr = new T[capacity];
        }

        

        public void Push(T a)
        {
            if (Count == Capacity) 
            {
                Capacity = Capacity * 2;
                Array.Resize(ref _arr, Capacity);
            }
            for (int i = 0; i < Count-1; i++)
            {
                _arr[_arr.Length-1] = a;
            }
            Count++;
        }
        public void Peek() 
        { 
        
        }
        public void Pop() 
        { 
        
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _arr[i];
            }
        }
    }
    class MyList<T>:IEnumerable
    {
        public int Capacity { get; set; }
        public int Count { get; set; }
        private T [] _arr;
        public MyList() 
        {
            Capacity = 4;
            _arr = new T [Capacity];
        }
        public MyList (int capacity) 
        {
            _arr = new T[capacity];
        }
        public void Add(T value) 
        {

            if (Count == Capacity)
            {
                Capacity = Capacity * 2;
                Array.Resize(ref _arr, Capacity);

            }
            _arr[Count] = value;
            Count++;
        }

        public void Remove(T value) 
        {
            for (int i = Array.IndexOf(_arr,value); i < _arr.Length-1; i++)
            {
                _arr[i] = _arr[i + 1];
            }
            Count--;
        }
        public void RemoveAt(int index) 
        {
            for (int i = index; i < _arr.Length-1; i++)
            {
                _arr[i] = _arr[i + 1];
            }
            Array.Resize(ref _arr, _arr.Length - 1);
            Count--;
        }
        public void AddRange(T[] array) 
        {
            foreach (var item in array)
            {
                Array.Resize(ref _arr, _arr.Length + 1);
                _arr[_arr.Length - 1] = item;
                Count++;
            }
            
        }
        public void TrimToSize()
        {
            for (int i = 0; i < _arr.Length; i++)
            {


                Capacity = Count;
                
            }
        }


        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _arr[i];
            }
            
        }
    }
    class MyCircular<T>:IEnumerable
    {
        public int Count { get; set; }
        public Node<T> Head { get; set; }

        public Node<T> AddFirst(T value)
        {
            if (Head == null)
            {
                var newNode = new Node<T> { Value = value };
                Head = newNode;
                Count++;
                return newNode;

            }
            else 
            {
                var oldHead = Head;
                var newNode = new Node<T> { Value = value, Next = oldHead };
                Head = newNode;
                oldHead.Previous = newNode.Next;
                oldHead.Next = newNode.Previous;
                Count++;
                return Head;
            
            }

        }

        public Node<T> AddLast(T value) 
        {
            var lastNode = Head;
            while (lastNode.Next != null) 
            {
                lastNode = lastNode.Next;
            }
            var newNode = new Node<T> { Value = value, Previous = lastNode, Next = lastNode.Next };
            lastNode.Next = newNode;
            return newNode;
        }
        public Node<T> AddAfter(Node<T> node, T value)
        {
            var newNode = new Node<T> { Value = value, Previous = node, Next = node.Next };
            node.Next.Previous = newNode;
            node.Next = newNode;
            Count++;
            return newNode;

        }
        public Node<T> AddBefore(Node<T> node, T value)
        {
            var newNode = new Node<T> { Value = value, Previous = node.Previous, Next = node };
            node.Previous.Next = newNode;
            node.Previous = newNode;
            Count++;
            return newNode;

        }


        public IEnumerator GetEnumerator()
        {
            var node = Head;
            while (node != null) 
            {
                yield return node.Value;
                node = node.Next;
            }
        }
    }

    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

    }
}



        

    


