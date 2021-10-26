using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URIstudy.Models
{
    public class Node
    {
        public Node left, right;
        public int data;
        
        public void insert(int value)
        {
            if(value <= data)
            {
                if(left != null)
                {
                    left.insert(value);
                } else
                {
                    left.data = value;
                }
            } else
            {
                if(right != null)
                {
                    right.insert(value);
                } else
                {
                    right.data = value;
                }
            }
        }

        public bool contains(int value)
        {
            if(value == data)
            {
                return true;
            }
            
            if(value <= data)
            {
                if(left != null)
                {
                    return left.contains(value);
                } else
                {
                    return false;
                }
            } else
            {
                if(right != null)
                {
                    return right.contains(value);
                } else
                {
                    return false;
                }
            }
        }

    }
}
