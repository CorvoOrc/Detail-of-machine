using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaftConstruction
{
    public class SlotDirect<T> : StructElement<T> where T : IComparable, new()
    {
        T z, D;

        public T Z
        {
            get
            {
                return z;
            }
        }

        public T _D
        {
            get
            {
                return D;
            }
        }

        public SlotDirect() :
            base()
        {
            // empty constructor
        }

        public SlotDirect
            (T _x, T _y, T _z, T _d) :
            base(_x, _y, _z, _d)
        {
            try
            {
                this.z = new T();
                this.D = new T();
            }
            catch
            {
                throw new Exception("SlotDirect hasnt been not constructioned");
            }
        }

        public SlotDirect
            (T Z, T _D) :
            base()
        {
            try
            {
                this.z = Z;
                this.D = _D;
            }
            catch
            {
                throw new Exception("SlotDirect hasnt been not constructioned");
            }
        }

        public SlotDirect
            (T _x, T _y, T _z, T _d, T Z, T _D) :
            base(_x, _y, _z, _d)
        {
            try
            {
                this.z = Z;
                this.D = _D;
                this.name = "шпонка прямозубая";
            }
            catch
            {
                throw new Exception("SlotDirect hasnt been not constructioned");
            }
        }

        public SlotDirect
            (string _name, Coordinate<T> _coordinate, T _d) :
            base(_name, _coordinate, _d)
        {

        }

        public SlotDirect
            (string _name, Coordinate<T> _coordinate, T _d, T _z, T _D) :
            base(_name, _coordinate, _d)
        {
            try
            {
                this.z = _z;
                this.D = _D;
                this.name = "шпонка прямозубая";
            }
            catch
            {
                throw new Exception("SlotDirect hasnt been not constructioned");
            }

        }

        override public void print()
        {
            Console.WriteLine("I`m SlotDirect");
        }
    }
}
