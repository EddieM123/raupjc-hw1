using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIntegerList
{
    public class IntegerList : IIntegerList 
    {
        private int[] _internalStorage;
        private int[] temp;
        private bool[] status;
        private bool[] tempstat;
        private int i = 0;

        // default constructor
        public IntegerList()
        {
            _internalStorage = new int[4];
            status = new bool[4];
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
                status = new bool[initialSize];
            }
        }

        public void Add(int x)
        {
            bool t = false;
            for (int i = 0; i < _internalStorage.Length; i++)
            {
                if (status[i] == false)
                {
                    t = true;
                    _internalStorage[i] = x;
                    status[i] = true;
                    break;
                }
            }
            if (!t)
            {
                temp = new int[_internalStorage.Length];
                tempstat = new bool[_internalStorage.Length];

                for (i = 0; i < _internalStorage.Length; i++)
                {
                    temp[i] = _internalStorage[i];
                    tempstat[i] = status[i];
                }

                _internalStorage = new int[_internalStorage.Length * 2];
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

        public bool Remove(int x)
        {
            for (i = 0; i < _internalStorage.Length; i++)
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
            if(index > _internalStorage.Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (status[index] is false) return false;
                _internalStorage[index] = 0;
                status[index] = false;
                for(i = index; i < _internalStorage.Length-1; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                    status[i] = status[i + 1];
                }
                _internalStorage[_internalStorage.Length - 1] = 0;
                status[_internalStorage.Length - 1] = false;

                return true;
            }
        }

       public int GetElement(int index)
        {
            if(index > _internalStorage.Length || index < 0) { throw new IndexOutOfRangeException(); }
            else
            {
                if (status[index]) return (int)_internalStorage[index];
                else return -1;
            }
        }

        // returns index of said item, if not found returns -1
        public int IndexOf(int item)
        {
            for (i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == item) return i;
            }
            return -1;
        }

        public int Count
        {
            get {
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
            for(i = 0; i < _internalStorage.Length; i++) { _internalStorage[i] = 0; status[i] = false; }
        }
     
        public bool Contains(int item)
        {
            for(i = 0; i < _internalStorage.Length; i++)
            {
                if (_internalStorage[i] == item) return true;
            }
            return false;
        }
    }
}