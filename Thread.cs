using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaftConstruction
{
    public class Thread<T> : StructElement<T> where T : IComparable, new()
    {
        T dIn, dOut;
        T p; // step
        T l;

        public Thread()
        {

        }

        public Thread
            (T _x, T _y, T _z, T _d) :
            base(_x, _y, _z, _d)
        {
            try
            {
                this.dIn = new T();
                this.dOut = new T();
                this.p = new T();
                this.l = new T();
            }
            catch
            {
                throw new Exception("Thread hasnt been not constructioned");
            }
        }

        public Thread
            (T _x, T _y, T _z, T _d, T _dIn, T _dOut, T _p, T _l) :
            base(_x, _y, _z, _d)
        {
            try
            {
                this.dIn = _dIn;
                this.dOut = _dOut;
                this.p = _p;
                this.l = _l;
            }
            catch
            {
                throw new Exception("Thread hasnt been not constructioned");
            }
        }

        public Thread
            (string _name, Coordinate<T> _coordinate, T _d) :
            base(_name, _coordinate, _d)
        {

        }

        public Thread
            (string _name, Coordinate<T> _coordinate, T _d, T _dIn, T _dOut, T _p, T _l) :
            base(_name, _coordinate, _d)
        {
            try
            {
                this.dIn = _dIn;
                this.dOut = _dOut;
                this.p = _p;
                this.l = _l;
            }
            catch
            {
                throw new Exception("Thread hasnt been not constructioned");
            }
        }

        override public void print()
        {
            Console.WriteLine("I`m Thread");
        }

        public bool check
            (T lShaftArea, T normdIn, T dShaftArea)
        {
            if (this.l.CompareTo(lShaftArea) <= 0 && this.dIn.CompareTo(normdIn) >= 0 && this.dOut.CompareTo(dShaftArea) <= 0)
            {
                return true;
            }

            return false;
        }
    }
}
