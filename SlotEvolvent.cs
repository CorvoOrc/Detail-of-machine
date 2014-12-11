using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaftConstruction
{
    public class SlotEvolvent<T> : StructElement<T> where T : IComparable, new()
    {
        T z, D, rCurvature;

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

        public T Rcurvature
        {
            get
            {
                return rCurvature;
            }
        }

        public SlotEvolvent()
        {

        }

        public SlotEvolvent
            (T _x, T _y, T _z, T _d) :
            base(_x, _y, _z, _d)
        {
            try
            {
                this.z = new T();
                this.D = new T();
                this.rCurvature = new T();
            }
            catch
            {
                throw new Exception("SlotEvolvent hasnt been not constructioned");
            }
        }

        public SlotEvolvent
            (T Z, T _D, T _rCurvature) :
            base()
        {
            try
            {
                this.z = Z;
                this.D = _D;
                this.rCurvature = _rCurvature;
            }
            catch
            {
                throw new Exception("SlotEvolvent hasnt been not constructioned");
            }
        }

        public SlotEvolvent
            (T _x, T _y, T _z, T _d, T Z, T _D, T _rCurvature) :
            base(_x, _y, _z, _d)
        {
            try
            {
                this.z = Z;
                this.D = _D;
                this.rCurvature = _rCurvature;
                this.name = "эвольвента";
            }
            catch
            {
                throw new Exception("SlotEvolvent hasnt been not constructioned");
            }
        }

        public SlotEvolvent
            (string _name, Coordinate<T> _coordinate, T _d) :
            base(_name, _coordinate, _d)
        {

        }

        public SlotEvolvent
            (string _name, Coordinate<T> _coordinate, T _d, T Z, T _D, T _rCurvature) :
            base(_name, _coordinate, _d)
        {
            try
            {
                this.z = Z;
                this.D = _D;
                this.rCurvature = _rCurvature;
            }
            catch
            {
                throw new Exception("SlotEvolvent hasnt been not constructioned");
            }
        }

        override public void print()
        {
            Console.WriteLine("I`m SlotEvolvent");
        }
    }
}
