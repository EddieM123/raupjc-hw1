using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.zad
{
    public class IntegerList : IIntegerList 
    {
        private int[] _internalStorage;
        private int[] temp;
        private int i = 0;

        int indeks = 0;

        // default constructor
        public IntegerList()
        {
            _internalStorage = new int[4];
        }

        // Specified size constructor
        public IntegerList(int initialSize)
        {
            if (initialSize <= 0)
            {
                throw new ArgumentException("Argument has to be greater than 0."); 
            }
            else
            {
                _internalStorage = new int[initialSize];
            }
        }

        public void Add(int x)
        {
            if(indeks < _internalStorage.Length) {
                _internalStorage[indeks] = x;
                indeks++;
            }
            

            else
            {
                temp = new int[_internalStorage.Length];

                for (i = 0; i < _internalStorage.Length; i++)
                {
                    temp[i] = _internalStorage[i];
                }

                _internalStorage = new int[_internalStorage.Length * 2];

                for (i = 0; i < temp.Length; i++)
                {
                    _internalStorage[i] = temp[i];
                }

                _internalStorage[indeks] = x;

                indeks++;
            }
        }

        public bool Remove(int x)
        {
            for (i = 0; i < indeks; i++)
            {
                if (_internalStorage[i] == x)
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

       public int GetElement(int index)
        {
            if(index > _internalStorage.Length || index < 0) { throw new IndexOutOfRangeException(); }
            else
            {
                if (index < indeks) return (int)_internalStorage[index];
                else return -1;
            }
        }

        // returns index of said item, if not found returns -1
        public int IndexOf(int item)
        {
            for (i = 0; i < indeks; i++)
            {
                if (_internalStorage[i] == item) return i;
            }
            return -1;
        }

        public int Count
        {
            get {
                return indeks;
                }
        }

        public void Clear()
        {
            indeks = 0;
        }
     
        public bool Contains(int item)
        {
            for(i = 0; i < indeks; i++)
            {
                if (_internalStorage[i] == item) return true;
            }
            return false;
        }
    }
}