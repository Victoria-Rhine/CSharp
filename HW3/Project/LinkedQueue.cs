namespace Project
{
    public class LinkedQueue<T> : IQueueInterface<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public LinkedQueue()
        {
            head = null;
            tail = null;
        }

        public T Push(T element)
        {
            if(element == null)
            {
                throw new QueueUnderflowException("Element is null");
            }

            if (IsEmpty())
            {
                Node<T> temp = new Node<T>(element, null);
                tail = head = temp;
            }
            else
            {
                Node<T> temp = new Node<T>(element, null);
                tail.next = temp;
                tail = temp;
            }
            return element;
        }

        public T Pop()
        {
            T temp;

            if (IsEmpty())
            {
                throw new QueueUnderflowException("Cannot remove element from empty list");
            }
            else if (head == tail)
            {
                temp = head.data;
                head = null;
                tail = null;
            }
            else
            {
                temp = head.data;
                head = head.next;
            }
            return temp;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("Cannot return element from empty list");
            }
            return head.data;
        }

        public bool IsEmpty()
        {
            if (head == null && tail == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
