using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueSimulator
{
    class Queue<T>
    {
        private int _size; // The current _size of the queue
        private readonly int max; // The total allowed _size of the queue
        private int _front; // The poisition in the array that is the front of the queue
        private T[] queueArray; 

        public Queue(int maxQueueSize)
        {
            queueArray = new T[maxQueueSize];
            max = maxQueueSize;
            _size = 0;
            _front = 4;
        }

        /// <summary>
        /// Add the provided item to the queue
        /// </summary>
        /// <param name="item">The item to add to the que</param>
        public void Enqueue(T item)
        {
            if (_size < max)
            {
                int index = (_size + _front) % max;
                queueArray[index] = item;
                _size++;
            }
            else
            {
                throw new Exception("Queue is already full");
            }
        }
        /// <summary>
        /// Remove the item from the front of the queue and return it
        /// </summary>
        /// <returns>The item in the front of the queue</returns>
        public T Deque()
        {
            T toReturn;
            int index = _front;
            toReturn = queueArray[index];
            _size--;
            _front = (_front + 1)%max;
            return toReturn;
        }

        /// <summary>
        /// Return the item in the front of the queue without removing it.
        /// The front will be the item in the front of the queue.
        /// </summary>
        /// <returns>item at the front of the queue</returns>
        public T Front()
        {
            if (queueArray.Length > 0)
            {
                return queueArray[_front];
            }
            else
            {
                throw new Exception("The quuee is empty");
            }
        }

        /// <summary>
        /// Returns the item at the back of the queue without removing it.
        /// The back will be the item added last.
        /// </summary>
        /// <returns>Item at the end of the queue</returns>
        public T Back()
        {
            if (queueArray.Length > 0)
            {
                int index = _getEndIndex();
                return queueArray[index];
            }
            else
            {
                throw new Exception("The quuee is empty");
            }
        }

        public int Size
        {
            get { return _size; }
        }

        public bool IsFull()
        {
            return _size == max;
        }

        private int _getEndIndex()
        {
            return (_front + _size)%max;
        }

    }
}
