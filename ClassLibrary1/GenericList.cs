using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    public class GenericList<X> : IGenericList<X> 
    {

        private X[] _internalStorage;
        private X[] temp;
        private bool[] status;
        private bool[] tempstat;
        private int i = 0;



        // enumerator implementation
        public IEnumerator<X> GetEnumerator()
        {
            return new lib.GenericListEnumerator<X>(this._internalStorage);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        


        // default constructor
        public GenericList()
        {
            _internalStorage = new X[4];
            status = new bool[4];

            for (int i = 0; i < _internalStorage.Length; i++)
            {
                _internalStorage[i] = default(X);
            }

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
                status = new bool[initialSize];
            }
        }

        public void Add(X x)
        {
            bool t = false;
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (!status[i])
                {
                    t = true;
                    _internalStorage[i] = x;
                    status[i] = true;
                    break;
                }
            }
            if (!t)
            {
                temp = new X[_internalStorage.Length];
                tempstat = new bool[_internalStorage.Length];

                for (i = 0; i < _internalStorage.Length; i++)
                {
                    temp[i] = _internalStorage[i];
                    tempstat[i] = status[i];
                }

                _internalStorage = new X[_internalStorage.Length * 2];
                status = new bool[_internalStorage.Length * 2];

                for (i = 0; i < temp.Length; i++)
                {
                    _internalStorage[i] = temp[i];
                    status[i] = tempstat[i];
                }

                _internalStorage[temp.Length] = x;
                status[temp.Length] = true;
            }
        }

        public bool Remove(X x)
        {
            for (i = 0; i < _internalStorage.Length; i++)
            {
                if (status[i])
                {
                    if (_internalStorage[i].Equals(x)) return RemoveAt(i);
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
            else
            {
                if (!status[index]) return false;
                _internalStorage[index] = default(X);
                status[index] = false;

                for (i = index; i < _internalStorage.Length - 1; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                    status[i] = status[i + 1];
                }
                _internalStorage[_internalStorage.Length - 1] = default(X);
                status[_internalStorage.Length - 1] = false;

                return true;
            }
        }

        public X GetElement(int index)
        {
            if (index > _internalStorage.Length || index < 0) { throw new IndexOutOfRangeException(); }
            else
            {
                if (status[index]) return (X)_internalStorage[index];
                else return (X)Convert.ChangeType(-1, typeof(X)); ;
            }
        }

        // returns index of said item, if not found returns -1
        public int IndexOf(X item)
        {
            for (i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i].Equals(item)) return i;
            }
            return -1;
        }

        public int Count
        {
            get
            {
                int x = 0;
                for (i = 0; i < _internalStorage.Length; i++)
                {
                    if (status[i]) x++;
                }
                return x;
            }
        }

        public void Clear()
        {
            for (i = 0; i < _internalStorage.Length; i++) { _internalStorage[i] = default(X); status[i] = false; }
        }

        public bool Contains(X item)
        {
            for (i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i].Equals(item)) return true;
            }
            return false;
        }


    }
}
