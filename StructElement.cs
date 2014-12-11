/*autor Steshenko A.S. IVT-465*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaftConstruction
{
    public abstract class StructElement<T> where T : IComparable, new()
    {
        private UInt64 id;
        protected T d;
        protected string name;
        protected Coordinate<T> coordinate;

        private static UInt64 max_id = 0;

        public abstract void print();

        public UInt64 Id
        {
            get
            {
                return id;
            }
        }

        public T D
        {
            get
            {
                return d;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Coordinate<T> Coordinate
        {
            get
            {
                return coordinate;
            }
        }

        public StructElement()
        {
            try
            {
                this.name = "StructElementX";
                this.coordinate = new Coordinate<T>(new T(), new T(), new T());
                this.d = new T(); // standart value = 34.0 (watch Sheynblit, Course design detail of machine, Moscow, 1991)

                this.id = ++max_id;
            }
            catch
            {
                throw new Exception("StructElement hasnt been not constructioned");
            }

        }

        public StructElement
            (T _x, T _y, T _z, T _d)
        {
            try
            {
                this.name = "StructElementX";
                this.coordinate = new Coordinate<T>(_x, _y, _z);
                this.d = _d;

                this.id = ++max_id;
            }
            catch
            {
                throw new Exception("StructElement hasnt been not constructioned");
            }
        }

        public StructElement
            (string _name, Coordinate<T> _coordinate, T _d)
        {
            try
            {
                this.name = _name;
                this.coordinate = _coordinate;
                this.d = _d;

                this.id = ++max_id;
            }
            catch
            {
                throw new Exception("StructElement isnt construction");
            }
        }

        public virtual bool check
            (T dShaftArea)
        {
            if (d.CompareTo(dShaftArea) <= 0)
            {
                return true;
            }

            return false;
        }
    }
}
