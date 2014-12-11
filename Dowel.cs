using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaftConstruction
{
    public class Dowel<T> : StructElement<T> where T : IComparable, new()
    {
        int b, h;

        public int B
        {
            get
            {
                return b;
            }
        }

        public int H
        {
            get
            {
                return h;
            }
        }

        public Dowel()
        {

        }

        public Dowel
            (int _b, int _h) :
            base()
        {
            try
            {
                this.b = _b;
                this.h = _h;
            }
            catch
            {
                throw new Exception("Dowel hasnt been not constructioned");
            }
        }

        public Dowel
            (T _x, T _y, T _z, T _d) :
            base(_x, _y, _z, _d)
        {
            try
            {
                this.b = 0;
                this.h = 0;
            }
            catch
            {
                throw new Exception("Dowel hasnt been not constructioned");
            }
        }

        public Dowel
            (T _x, T _y, T _z, T _d, int _b, int _h) :
            base(_x, _y, _z, _d)
        {
            try
            {
                this.b = _b;
                this.h = _h;
            }
            catch
            {
                throw new Exception("Dowel hasnt been not constructioned");
            }
        }

        public Dowel
            (string _name, Coordinate<T> _coordinate, T _d) :
            base(_name, _coordinate, _d)
        {
            try
            {
                this.b = 0;
                this.h = 0;
            }
            catch
            {
                throw new Exception("Dowel hasnt been not constructioned");
            }
        }

        override public void print()
        {
            Console.WriteLine("I`m Dowel");
        }

        public bool check
            (List<T> dl, List<T> b, List<T> h)
        {
            // check on equals with GOST for b, h
            for (int i = 1; i < dl.Count; ++i)
            {
                if (this.d.CompareTo(dl[i - 1]) >= 0 && this.d.CompareTo(dl[i]) <= 0
                    &&
                    this.b.CompareTo(b[i - 1]) == 0 && this.h.CompareTo(h[i - 1]) == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
