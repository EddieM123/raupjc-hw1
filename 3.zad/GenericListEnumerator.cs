using _3.zad;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.zad
{
    class GenericListEnumerator<T> : IEnumerator<T>
    {
        private GenericList<T> list;
        private int point;
        

        public GenericListEnumerator(GenericList<T> _list)
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
            if (point < list.Count) point++;

            if (point == list.Count) return false;
            else return true;
        }

        public T Current
        {
            get
            {
                if ((point == list.Count) || (point < 0)) throw new InvalidOperationException();
                return list.GetElement(point);
            }
        }

        object System.Collections.IEnumerator.Current
        {
            get
            {
                if ((point == list.Count) || (point < 0)) throw new InvalidOperationException();
                return list.GetElement(point);
            }
        }

        void IDisposable.Dispose() { }
    }
}

