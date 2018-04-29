using System;
using System.Collections.Generic;
using System.Linq;

namespace L05_progC
{
    public class Tree<T>
    {
        public T _value;
        public List<Tree<T>> _children = new List<Tree<T>>();

        public Tree<T> CreateNode(T value)
        {
            Tree<T> newValue = new Tree<T>
            {
                _value = value
            };
            return newValue;
        }

        public void AppendChild(Tree<T> child)
        {
            _children.Add(child);
        }
        public void RemoveChild(Tree<T> child)
        {
            _children.Remove(child);
        }
        public void PrintTree(String str = "")
        {
            Console.WriteLine(str + _value);
            foreach (Tree<T> child in _children)
            {
                child.PrintTree(str + "*");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<String>();
            var root = tree.CreateNode("root");
            var child1 = tree.CreateNode("child1");
            var child2 = tree.CreateNode("child1");
            root.AppendChild(child1);
            root.AppendChild(child2);
            var grand11 = tree.CreateNode("grand11");
            var grand12 = tree.CreateNode("grand12");
            var grand13 = tree.CreateNode("grand13");
            child1.AppendChild(grand11);
            child1.AppendChild(grand12);
            child1.AppendChild(grand13);
            var grand21 = tree.CreateNode("grand21");
            child2.AppendChild(grand21);
            child1.RemoveChild(grand12);

            root.PrintTree();
        }
    }
}