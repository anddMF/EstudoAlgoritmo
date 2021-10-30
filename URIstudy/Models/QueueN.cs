using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URIstudy.Models
{
    public class QueueN<T>
    {
        public List<T> elements;

        public QueueN()
        {
            elements = new List<T>();
        }

        public void Enqueue(T element)
        {
            elements.Add(element);
        }

        public void Dequeue()
        {
            elements.Remove(elements[0]);
        }

        public void PrintFirstElement()
        {
            Console.WriteLine(elements[0]);
        }
    }
}
