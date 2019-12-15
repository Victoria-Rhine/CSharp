using System;
using System.IO;


namespace Project
{
    public interface IQueueInterface<T>
    {
        /*
         * Add an element to the rear of the queue
         * @return the element that was queued
         * */
        public T Push(T element);

        /*
         * Remove and return the front element
         * @throws Thrown if the queue is empty
         * */
        public T Pop();

        /*
         * Return but don't remove the front element
         * @throws Thrown if the queue is empty
         * */
        public T Peek();

        /*
         * Test if the queue is empty
         * @return true if the queue is empty; otherwise false
         * */
        public bool IsEmpty();
    }
}
