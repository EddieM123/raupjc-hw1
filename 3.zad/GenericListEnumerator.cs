using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.zad
{
    class GenericListEnumerator<T> : IEnumerator<T>
    {

        public T Current
        {
            get
            {
                return T.GetType;
            }
        }
    }
}
