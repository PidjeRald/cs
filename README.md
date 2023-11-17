using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using NPOI.SS.Formula.Functions;

namespace ClassLibrary1
{
    public interface IStack<T> : IEnumerable<T>
    {
        void Push(T value);
        void Clear();
        T Pop();
        T Peek();
        int Count { get; }
        bool isEmpty { get; }
    }

    public class StackException : Exception
    {
        public StackException(string message) : base(message) { }
    }

    public class ArrayStack<T> : IStack<T>
    {
        private T[] items;
        private int top;

        public ArrayStack(int count)
        {
            items = new T[count];
            top = -1;
        }

        public void Push(T value)
        {
            if (top == items.Length - 1)
            {
                throw new StackException("Stack is full");
            }
            items[++top] = value;
        }

        public void Clear()
        {
            Array.Clear(items, 0, top + 1);
            top = -1;
        }

        public T Pop()
        {
            if (top == -1)
            {
                throw new StackException("Stack is empty");
            }
            T value = items[top];
            Array.Clear(items, top--, 1);
            return value;
        }

        public T Peek()
        {
            if (top == -1)
            {
                throw new StackException("Stack is empty");
            }
            return items[top];
        }

        public int Count
        {
            get { return top + 1; }
        }

        public bool isEmpty
        {
            get { return top == -1; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = top; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class LinkedStack<T> : IStack<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
        }

        private Node top;

        public LinkedStack() { top = null; }

        public void Push(T value)
        {
            Node newNode = new Node { Value = value, Next = top };
            top = newNode;
        }

        public void Clear()
        {
            top = null;
        }

        public T Pop()
        {
            if (top == null)
            {
                throw new StackException("Stack is empty");
            }
            T value = top.Value;
            top = top.Next;
            return value;
        }

        public T Peek()
        {
            if (top == null)
            {
                throw new StackException("Stack is empty");
            }
            return top.Value;
        }

        public int Count
        {
            get
            {
                int count = 0;
                Node current = top;
                while (current != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
            }
        }

        public bool isEmpty
        {
            get { return top == null; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = top;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class UnmutableStack<T> : IStack<T>
    {
        private readonly IStack<T> stack;

        public UnmutableStack(IStack<T> stack)
        {
            this.stack = stack;
        }

        public void Push(T value)
        {
            throw new StackException("Cannot push to unmutable stack");
        }

        public void Clear()
        {
            throw new StackException("Cannot clear unmutable stack");
        }

        public T Pop()
        {
            throw new StackException("Cannot pop from unmutable stack");
        }

        public T Peek()
        {
            return stack.Peek();
        }

        public int Count
        {
            get { return stack.Count; }
        }

        public bool isEmpty
        {
            get { return stack.isEmpty; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return stack.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    public static class StackUtils
    {
        public delegate bool CheckDelegate<T>(T value);
        public delegate IStack<T> StackConstructorDelegate<T>();
        public delegate TO ConvertDelegate<TI, TO>(TI value);
        public delegate void ActionDelegate<T>(T value);

        public static bool Exists<T>(IStack<T> stack, CheckDelegate<T> checkDelegate)
        {
            foreach (T value in stack)
            {
                if (checkDelegate(value))
                {
                    return true;
                }
            }
            return false;
        }

        public static IStack<T> FindAll<T>(IStack<T> stack, CheckDelegate<T> checkDelegate, StackConstructorDelegate<T> constructorDelegate)
        {
            IStack<T> result = constructorDelegate();
            foreach (T value in stack)
            {
                if (checkDelegate(value))
                {
                    result.Push(value);
                }
            }
            return result;
        }

        public static IStack<TO> ConvertAll<TI, TO>(IStack<TI> stack, ConvertDelegate<TI, TO> convertDelegate, StackConstructorDelegate<TO> constructorDelegate)
        {
            IStack<TO> result = constructorDelegate();
            foreach (TI value in stack)
            {
                result.Push(convertDelegate(value));
            }
            return result;
        }

        public static void ForEach<T>(IStack<T> stack, ActionDelegate<T> actionDelegate)
        {
            foreach (T value in stack)
            {
                actionDelegate(value);
            }
        }

        public static bool CheckForAll<T>(IStack<T> stack, CheckDelegate<T> checkDelegate)
        {
            foreach (T value in stack)
            {
                if (!checkDelegate(value))
                {
                    return false;
                }
            }
            return true;
        }

        public static readonly StackConstructorDelegate<T> ArrayStackConstructor = () => new ArrayStack<T>(1);
        public static readonly StackConstructorDelegate<T> LinkedStackConstructor = () => new LinkedStack<T>();
    }
}
