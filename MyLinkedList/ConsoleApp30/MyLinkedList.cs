using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp30
{
	class MyLinkedList<T> : IEnumerable<T>
	{
		private MyNode<T> _first = null;

		private MyNode<T> GetLastNode()
		{
			if (_first == null)
			{
				throw new Exception("List is empty");
			}

			MyNode<T> node = _first;

			while (node.Next != null)
			{
				node = node.Next;
			}

			return node;
		}

		public void AddFirst(MyNode<T> node)
		{
			if (_first == null)
			{
				_first = node;
				return;
			}
			node.Next = _first;
			_first = node;
		}

		public MyNode<T> AddFirst(T value)
		{
			MyNode<T> node = new MyNode<T> { Value = value };
			AddFirst(node);
			return node;
		}

		public void AddLast(MyNode<T> node)
		{
			if (_first == null)
			{
				_first = node;
				return;
			}

			GetLastNode().Next = node;
		}

		public MyNode<T> AddLast(T value)
		{
			MyNode<T> node = new MyNode<T> { Value = value };
			AddLast(node);
			return node;
		}

		public void AddAfter(MyNode<T> node, MyNode<T> newNode)
		{
			newNode.Next = node.Next;
			node.Next = newNode;
		}

		public MyNode<T> AddAfter(MyNode<T> node, T value)
		{
			MyNode<T> newNode = new MyNode<T> { Value = value };
			AddAfter(node, newNode);
			return newNode;
		}

		public void AddBefore(MyNode<T> node, MyNode<T> newNode)
		{
			if (newNode.Equals(_first))
			{
				AddFirst(newNode);
				return;
			}

			MyNode<T> temp = _first;
			while (temp.Next != null)
			{
				if (temp.Next.Equals(node))
				{
					break;
				}
				temp = temp.Next;
			}
			AddAfter(temp, newNode);
		}

		public MyNode<T> AddBefore(MyNode<T> node, T value)
		{
			MyNode<T> newNode = new MyNode<T> { Value = value };
			AddBefore(node, newNode);
			return newNode;
		}

		public void Remove(MyNode<T> node)
		{
			if (_first.Equals(node))
			{
				_first = _first.Next;
				return;
			}

			MyNode<T> temp = _first;
			while (temp.Next != null)
			{
				if (temp.Next == node)
				{
					temp.Next = node.Next;
					break;
				}
				temp = temp.Next;
			}
		}

		public void RemoveFirst()
		{
			if (_first != null)
			{
				_first = _first.Next;
			}
		}

		public void RemoveLast()
		{
			if (_first == null || _first.Next == null)
			{
				_first = null;
				return;
			}

			MyNode<T> temp = _first;
			while (temp.Next.Next != null)
			{
				temp = temp.Next;
			}
			temp.Next = null;
		}

		public MyNode<T> GetNode(T value)
		{
			if (_first == null)
			{
				return null;
			}

			MyNode<T> node = _first;
			do
			{
				if (node.Value.Equals(value))
				{
					return node;
				}
				node = node.Next;
			}
			while (node.Next != null);

			return null;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new MyEnumerator<T>(_first);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public bool Remove(T value)
		{
			MyNode<T> node = new MyNode<T> { Value = value };
			Remove(node);
			return true;
		}
	}
}
