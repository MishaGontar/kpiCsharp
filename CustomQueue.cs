namespace KpiCs
{
    public class CustomQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public event EventHandler<T> OnItemAdded;
        public event EventHandler<T> OnItemRemoved;
        public event EventHandler OnCollectionCleared;
        public event EventHandler<T> OnItemAddedToBeginning;
        public event EventHandler<T> OnItemAddedToEnd;

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (tail == null)
            {
                head = newNode;
                OnItemAddedToBeginning?.Invoke(this, item);
            }
            else
            {
                tail.Next = newNode;
                OnItemAddedToEnd?.Invoke(this, item);
            }

            tail = newNode;

            OnItemAdded?.Invoke(this, item);
        }

        public void Remove(T item)
        {
            if (!Contains(item))
            {
                throw new Exception("No item found!");
            }

            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }

                    OnItemRemoved?.Invoke(this, item);
                    return;
                }

                previous = current;
                current = current.Next;
            }
        }

        public bool Contains(T item)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                    return true;
                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            OnCollectionCleared?.Invoke(this, EventArgs.Empty);
        }

        public T Peek()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return head.Data;
        }

        public int Count()
        {
            int count = 0;
            Node<T> current = head;

            while (current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node<T> current = head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current.Data;
                }

                currentIndex++;
                current = current.Next;
            }

            throw new IndexOutOfRangeException("Index is out of range.");
        }

        public void PrintAll()
        {
            Node<T> current = head;

            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
}