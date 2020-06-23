using ConsoleAppData.Stack.Model;
using System;

namespace ConsoleAppData.Stack
{
    class Program
    {
        static void Main()
        {
            MyEasyStack<string> myEasyStack = new MyEasyStack<string>();

            myEasyStack.Push("Hi");
            myEasyStack.Push("Hellow");
            myEasyStack.Push("World");

            Print(myEasyStack);

            var newStack = myEasyStack.Clone();
            myEasyStack.Push("People");
            Print(myEasyStack);
            Console.Write("Клонированный ");
            Print(newStack);

            MyStack<int> myStack = new MyStack<int>();
            
            myStack.Push(1);
            myStack.Push(3);
            myStack.Push(5);
            Print(myStack);
            var newMyStack = myStack.Clone();
            myStack.Push(7);
            Print(myStack);
            Console.Write("Клонированный ");
            Print(newMyStack);


            MyArrayStack<string> myArrayStack = new MyArrayStack<string>(6);

            myArrayStack.Push("1");
            myArrayStack.Push("3");
            myArrayStack.Push("5");
            Print(myArrayStack);
            var newMyArrayStack = myArrayStack.Clone();
            
            
            myArrayStack.Push("7");
            Print(myArrayStack);



            Console.Write("Клонированный ");
            newMyArrayStack.Push("new");
            Print(newMyArrayStack);

        }

        public static void Print<T>(MyEasyStack<T> stack)
        {
            Console.WriteLine(stack);
            Console.WriteLine($"Текущий элемент: {stack.Peek()}");
            Console.WriteLine();
        }

        public static void Print<T> (MyStack<T> stack)
        {
            Console.WriteLine(stack);
            Console.WriteLine($"Текущий элемент: {stack.Peek()}");
            Console.WriteLine();
        }

        public static void Print<T>(MyArrayStack<T> stack)
        {
            Console.WriteLine(stack);
            Console.WriteLine($"Текущий элемент: {stack.Peek()}");
            Console.WriteLine();
        }

    }
}
