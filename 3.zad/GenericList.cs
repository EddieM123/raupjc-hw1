﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.zad
{
    public class GenericList<X> : IGenericList<X> where X : struct
    {
        private X?[] _internalStorage;
        private X?[] temp;
        private int i = 0;

        
        // default constructor
        public GenericList()
        {
            _internalStorage = new X?[4];
        }

        // Specified size constructor
        public GenericList(int initialSize)
        {
            if (initialSize <= 0)
            {
                Console.WriteLine("Number can't be less or equal than 0.");
            }
            else _internalStorage = new X?[initialSize];
        }

        // enumerator implementation
        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(X x)
        {
            bool t = false;
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] is null)
                {
                    t = true;
                    _internalStorage[i] = x;
                    break;
                }
            }
            if (!t)
            {
                temp = new X?[_internalStorage.Length];
                for (i = 0; i < _internalStorage.Length; i++)
                {
                    temp[i] = _internalStorage[i];
                }

                _internalStorage = new X?[_internalStorage.Length * 2];

                for (i = 0; i < temp.Length; i++)
                {
                    _internalStorage[i] = temp[i];
                }

                _internalStorage[temp.Length] = x;
            }
        }

        public bool Remove(X x)
        {
            for (i = 0; i < _internalStorage.Length; i++)
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
            else
            {
                if (_internalStorage[index] is null) return false;
                _internalStorage[index] = null;
                for (i = index; i < _internalStorage.Length - 1; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
                _internalStorage[_internalStorage.Length - 1] = null;

                return true;
            }
        }

        public X GetElement(int index)
        {
            if (index > _internalStorage.Length || index < 0) { throw new IndexOutOfRangeException(); }
            else
            {
                if (_internalStorage[index] != null) return (X)_internalStorage[index];
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
                    if (_internalStorage[i] != null) x++;
                }
                return x;
            }
        }

        public void Clear()
        {
            for (i = 0; i < _internalStorage.Length; i++) { _internalStorage[i] = null; }
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