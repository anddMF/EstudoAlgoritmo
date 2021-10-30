using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URIstudy.Models
{
    public class LinkedListNodeN
    {
        public int data;
        public LinkedListNodeN next;

        public LinkedListNodeN(int x)
        {
            data = x;
            next = null;
        }
    }

    public class LinkedListN
    {
        LinkedListNodeN head;

        public LinkedListN()
        {
            head = null;
        }

        public void AddNodeToFront(int data)
        {
            LinkedListNodeN node = new LinkedListNodeN(data);
            // points
            node.next = head;

            // points para o novo primeiro elemento da lista
            head = node;
        }

        public void AddNodeToBack(int data)
        {
            LinkedListNodeN node = new LinkedListNodeN(data);

            var runner = head;

            while(runner.next != null)
            {
                runner = runner.next;
            }

            runner.next = node;
        }

        public void DeleteNodeFromBack()
        {
            var runner = head;

            while (runner.next.next != null)
            {
                runner = runner.next;
            }

            runner.next = null;
        }

        public void DeleteNodeFromFront()
        {
            head = head.next;
        }

        public void PrintNodes()
        {
            LinkedListNodeN runner = head;

            while(runner != null)
            {
                Console.WriteLine(runner.data);

                runner = runner.next;
            }
        }

    }
}
