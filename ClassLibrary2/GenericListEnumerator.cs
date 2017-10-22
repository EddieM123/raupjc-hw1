using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary2
{
    class GenericListEnumerator<T> : IEnumerator<T>
    {
        private T[] list;
        private int point;

        public GenericListEnumerator(T[] _list)
        {
            this.list = _list;
            point = -1;

        }

        public void Reset()
        {
            point = -1;
        }


        public bool MoveNext()
        {
            if (point < list.Length) point++;
            return (!(point == list.Length));
        }

        void IDisposable.Dispose() { }

        public T Current
        {
            get
            {
                if ((point < 0) || (point == list.Length)) throw new InvalidOperationException();
                return list[point];
            }
        }

        object System.Collections.IEnumerator.Current
        {
            get
            {
                if ((point < 0) || (point == list.Length)) throw new InvalidOperationException();
                return list[point];
            }
        }
    }
}

