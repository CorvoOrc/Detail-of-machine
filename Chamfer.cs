using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaftConstruction
{
    public class Chamfer<T> : StructElement<T> where T : IComparable, new()
    {
        T c;

        public T C
        {
            get
            {
                return c;
            }
        }

        public Chamfer()
        {

        }

        public Chamfer
            (T _x, T _y, T _z, T _d) :
            base(_x, _y, _z, _d)
        {

        }

        public Chamfer
            (T _c) :
            base()
        {
            try
            {
                this.c = _c;
            }
            catch
            {
                throw new Exception("Chamfer hasnt been not constructioned");
            }
        }

        public Chamfer
            (T _x, T _y, T _z, T _d, T _c) :
            base(_x, _y, _z, _d)
        {
            try
            {
                this.c = _c;
            }
            catch
            {
                throw new Exception("Chamfer hasnt been not constructioned");
            }
        }

        public Chamfer
            (string _name, Coordinate<T> _coordinate, T _d) :
            base(_name, _coordinate, _d)
        {

        }

        public Chamfer
            (string _name, Coordinate<T> _coordinate, T _d, T _c) :
            base(_name, _coordinate, _d)
        {
            try
            {
                this.c = _c;
            }
            catch
            {
                throw new Exception("Chamfer hasnt been not constructioned");
            }
        }

        override public void print()
        {
            Console.WriteLine("I`m Chamfer");
        }

        public bool check
            (List<T> dl, List<T> c)
        {
            // check on equals with GOST for c
            for (int i = 1; i < dl.Count; ++i)
            {
                if (this.d.CompareTo(dl[i - 1]) >= 0 && this.d.CompareTo(dl[i]) <= 0 && this.c.CompareTo(c[i - 1]) == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
