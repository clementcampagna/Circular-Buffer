using System;
using System.Collections.Generic;

namespace Circular_Buffer
{
	public class CircularBuffer<T>
	{
		private readonly Queue<T> queue;
		private readonly int capacity;

		public CircularBuffer(int capacity)
		{
			queue = new Queue<T>(capacity);
			this.capacity = capacity;
		}

		public T Read()
		{
			if (queue.Count == 0)
				throw new InvalidOperationException("Cannot read from an empty buffer");

			return queue.Dequeue();
		}

		public void Write(T value)
		{
			if (queue.Count == capacity)
				throw new InvalidOperationException("Cannot write to a full buffer (use Overwrite method to force the operation)");

			queue.Enqueue(value);
		}

		public void Overwrite(T value)
		{
			if (queue.Count == capacity)
				queue.Dequeue();

			queue.Enqueue(value);
		}

		public void Clear()
		{
			queue.Clear();
		}
	}
}
