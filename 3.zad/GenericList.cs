using System;
using System.Text;
using _3.zad;
using System.Collections.Generic;

namespace _3.zad
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private X[] temp;
        private int i = 0;

        int indeks = 0;

        // enumerator implementation
        public IEnumerator<X> GetEnumerator()
        {
            return new _3.zad.GenericListEnumerator<X>(this._internalStorage);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        // default constructor
        public GenericList()
        {
            _internalStorage = new X[4];
        }

        // Specified size constructor
        public GenericList(int initialSize)
        {
            if (initialSize <= 0)
            {
                throw new ArgumentException("Argument has to be greater than 0.");
            }
            else
            {
                _internalStorage = new X[initialSize];
            }
        }

        public void Add(X x)
        {
            if (indeks < _internalStorage.Length)
            {
                _internalStorage[indeks] = x;
                indeks++;
            }


            else
            {
                temp = new X[_internalStorage.Length];

                for (i = 0; i < _internalStorage.Length; i++)
                {
                    temp[i] = _internalStorage[i];
                }

                _internalStorage = new X[_internalStorage.Length * 2];

                for (i = 0; i < temp.Length; i++)
                {
                    _internalStorage[i] = temp[i];
                }

                _internalStorage[indeks] = x;
                indeks++;
            }
        }

        public bool Remove(X x)
        {
            for (i = 0; i < indeks; i++)
            {
                if (_internalStorage[i].Equals(x))
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index > _internalStorage.Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index > indeks) return false;
            else
            {

                for (i = index; i < indeks; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
                indeks = indeks - 1;
                return true;
            }
        }

        public X GetElement(int index)
        {
            if (index > _internalStorage.Length || index < 0) { throw new IndexOutOfRangeException(); }
            else
            {
                if (index < indeks) return (X)_internalStorage[index];
                else return (X)Convert.ChangeType(-1, typeof(X)); ;
            }
        }

        // returns index of said item, if not found returns -1
        public int IndexOf(X item)
        {
            for (i = 0; i < indeks; i++)
            {
                if (_internalStorage[i].Equals(item)) return i;
            }
            return -1;
        }

        public int Count
        {
            get
            {
                return indeks;
            }
        }

        public void Clear()
        {
            indeks = 0;
        }

        public bool Contains(X item)
        {
            for (i = 0; i < indeks; i++)
            {
                if (_internalStorage[i].Equals(item)) return true;
            }
            return false;
        }
    }
}