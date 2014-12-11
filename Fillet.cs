using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaftConstruction
{
    public class Fillet<T> : StructElement<T> where T : IComparable, new()
    {
        T r, t, c;

        public T R
        {
            get
            {
                return r;
            }
        }

        public T T_
        {
            get
            {
                return t;
            }
        }

        public T C
        {
            get
            {
                return c;
            }
        }

        public Fillet()
        {

        }

        public Fillet(T _x, T _y, T _z, T _d) :
            base(_x, _y, _z, _d)
        {
            try
            {
                this.r = new T();
                this.t = new T();
                this.c = new T();
            }
            catch
            {
                throw new Exception("Fillet hasnt been not constructioned");
            }
        }

        public Fillet(T _r, T _t, T _c) :
            base()
        {
            try
            {
                this.r = _r;
                this.t = _t;
                this.c = _c;
            }
            catch
            {
                throw new Exception("Fillet hasnt been not constructioned");
            }
        }

        public Fillet(T _x, T _y, T _z, T _d, T _r, T _t, T _c) :
            base(_x, _y, _z, _d)
        {
            try
            {
                this.r = _r;
                this.t = _t;
                this.c = _c;
                this.name = "галтель";
            }
            catch
            {
                throw new Exception("Fillet hasnt been not constructioned");
            }
        }

        public Fillet(string _name, Coordinate<T> _coordinate, T _d) :
            base(_name, _coordinate, _d)
        {

        }

        public Fillet(string _name, Coordinate<T> _coordinate, T _d, T _r, T _t, T _c) :
            base(_name, _coordinate, _d)
        {
            try
            {
                this.r = _r;
                this.t = _t;
                this.c = _c;
            }
            catch
            {
                throw new Exception("Fillet hasnt been not constructioned");
            }
        }

        override public void print()
        {
            Console.WriteLine("I`m Fillet");
        }

        public bool check(List<T> dl, List<T> r, List<T> t, List<T> c)
        {
            // check on equals with GOST for r, t, c

            for (int i = 1; i < dl.Count; ++i)
            {
                if (this.d.CompareTo(dl[i - 1]) <= 0 && this.d.CompareTo(dl[i]) <= 0
                    &&
                    this.r.CompareTo(r[i - 1]) == 0
                    &&
                    this.t.CompareTo(t[i - 1]) == 0
                    &&
                    this.c.CompareTo(c[i - 1]) == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
