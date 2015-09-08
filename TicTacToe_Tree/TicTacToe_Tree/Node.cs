using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Tree
{
    public class Node<T>
    {
        public T Data { get; set; }

        public List<Node<T>> ChildrenList
        {
            get { return childrenList; }
            set
            {
                childrenList = value;
                childrenChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private List<Node<T>> childrenList;

        public event EventHandler childrenChanged;

        public Node(T data)
        {
            this.Data = data;
        } 
    }
}
