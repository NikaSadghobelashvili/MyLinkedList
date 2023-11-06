using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp30
{
    class MyEnumerator<T> : IEnumerator<T>
    {
        private MyNode<T> _first;
        private MyNode<T> _node;

        public MyEnumerator(MyNode<T> first)
        {
            _first = first;
        }

        public T Current => _node.Value;

        public bool MoveNext()
        {
			if (_node == null)
			{
                _node = _first;
                return true;
			}

			if (_node.Next != null)
			{
                _node = _node.Next;
                return true;
			}

            return false;
        }

        public void Reset()
        {
            _node = null;
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }
    }
}
