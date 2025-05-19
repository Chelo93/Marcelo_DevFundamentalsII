namespace DataStructures
{
    // FIFO
    public class CustomQueue<T>
    {
        // TODO: Implement queue (you can modify the implementation, not the names of the methods)

        private class Node(T value)
        {
            public T Value { get; set; } = value;
            public Node? Next { get; set; } = null!;
        }
        private int _count = 0;
        private Node? _head;
        private Node? _tail;
        public int Count => _count;

        public void Enqueue(T item)
        {
            // Add items
            var newNode = new Node(item);
            if (_tail == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }
            _count++;
            
        }

        public T Dequeue()
        {
            // remove items
            if (_head == null)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T value = _head.Value;
            _head = _head.Next;
            if (_head == null)
            {
                _tail = null;
            } 
            _count--;
            return value;
        }

        public T Peek()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return _head.Value;
        }

        public bool IsEmpty() => _count == 0;

        public T[] ToArray()
        {
            
            var array = new T[_count];
            var current = _head;
            for (int i = 0; i < _count; i++)
            {
                array[i] = current!.Value;
                current = current.Next;
            }
            return array;
        }
    }
}
