using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary2
{
    class GenericListEnumerator<T> : IEnumerator<T>
    {
        private T[] list;
        private int Cursor;

        public GenericListEnumerator(T[] _list)
        {
            this.list = _list;
            Cursor = -1;

        }

        public void Reset()
        {
            Cursor = -1;
        }


        public bool MoveNext()
        {
            if (Cursor < list.Length) Cursor++;
            return (!(Cursor == list.Length));
        }

        void IDisposable.Dispose() { }

        public T Current
        {
            get
            {
                if ((Cursor < 0) || (Cursor == list.Length)) throw new InvalidOperationException();
                return list[Cursor];
            }
        }

        object System.Collections.IEnumerator.Current
        {
            get
            {
                if ((Cursor < 0) || (Cursor == list.Length)) throw new InvalidOperationException();
                return list[Cursor];
            }
        }
    }
}

