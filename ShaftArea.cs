/*autor Steshenko A.S. IVT-465*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ShaftConstruction
{
    //public class ShaftArea<TArea, TElement> where TElement : IComparable, new()
    public class ShaftArea<TArea>
    {
        static UInt64 max_id = 0;
        UInt64 id; // Better rewrite with DB

        List<object> structElements;
        bool baseArea;
        bool maxDim;
        TArea len, d;
        TypeArea typeArea;
        AccuracyClass accuracyClass;
        TypeTreatment typeTreatment;

        public UInt64 Id
        {
            get
            {
                return id;
            }
        }

        public List<object> StructElements
        {
            get
            {
                return structElements;
            }
        }

        public bool BaseArea
        {
            get
            {
                return baseArea;
            }
        }

        public TArea Len
        {
            get
            {
                return len;
            }
        }

        public TArea D
        {
            get
            {
                return d;
            }
        }

        public TypeArea TypeArea
        {
            get
            {
                return typeArea;
            }
        }

        public AccuracyClass AccuracyClass
        {
            get
            {
                return accuracyClass;
            }
        }

        public TypeTreatment TypeTreatment
        {
            get
            {
                return typeTreatment;
            }
        }

        public ShaftArea()
        {
            try
            {
                this.id = max_id;
                //this.structElements = new List<StructElement<TElement>>();
                this.structElements = new List<object>();
                this.baseArea = false;
                this.maxDim = false;
                this.len = default(TArea);
                this.d = default(TArea);
                this.typeArea = TypeArea.canon;
                this.accuracyClass = AccuracyClass.accurate;
                this.typeTreatment = TypeTreatment.facing;

                ++max_id;
            }
            catch
            {
                throw new Exception("ShaftArea hasnt been not constructioned");
            }

        }

        public ShaftArea
            (TArea _len, TArea _d)
        {
            try
            {
                this.id = max_id;
                //this.structElements = new List<StructElement<TElement>>();
                this.structElements = new List<object>();
                this.baseArea = false;
                this.maxDim = false;
                this.len = _len;
                this.d = _d;
                this.typeArea = TypeArea.canon;
                this.accuracyClass = AccuracyClass.accurate;
                this.typeTreatment = TypeTreatment.facing;

                ++max_id;
            }
            catch
            {
                throw new Exception("ShaftArea hasnt been not constructioned");
            }
        }

        public bool AddStructElement <TElement>
            (string name, TypeStructElement type)
            where TElement : IComparable, new()
        {
            StructElement<TElement> structElement;

            switch (type)
            {
                case (TypeStructElement.slotDirect):
                    {
                        try
                        {
                            structElement = new SlotDirect<TElement>();
                            structElements.Add(structElement);
                        }
                        catch
                        {
                            return false;
                        }

                        break;
                    }
                case (TypeStructElement.slotEvolvent):
                    {
                        try
                        {
                            structElement = new SlotEvolvent<TElement>();
                            structElements.Add(structElement);
                        }
                        catch
                        {
                            return false;
                        }

                        break;
                    }
                case (TypeStructElement.fillet):
                    {
                        try
                        {
                            structElement = new Fillet<TElement>();
                            structElements.Add(structElement);
                        }
                        catch
                        {
                            return false;
                        }

                        break;
                    }
                case (TypeStructElement.chamfer):
                    {
                        try
                        {
                            structElement = new Chamfer<TElement>();
                            structElements.Add(structElement);
                        }
                        catch
                        {
                            return false;
                        }

                        break;
                    }
                case (TypeStructElement.dowel):
                    {
                        try
                        {
                            structElement = new Dowel<TElement>();
                            structElements.Add(structElement);
                        }
                        catch
                        {
                            return false;
                        }
                        break;
                    }
                case (TypeStructElement.thread):
                    {
                        try
                        {
                            structElement = new Thread<TElement>();
                            structElements.Add(structElement);
                        }
                        catch
                        {
                            return false;
                        }
                        break;
                    }
            }

            return true;
        }

        public bool DeleteStructElement
            (UInt64 id)
        {
            for (int i = 0; i < structElements.Count; ++i)
            {
                object obj = structElements[i];
                Type typeObj = obj.GetType();
                PropertyInfo propInfo = typeObj.GetProperty("Id");

                if (propInfo.Equals(id))
                {
                    try
                    {
                        structElements.RemoveAt(i);
                    }
                    catch
                    {
                        return false;
                    }

                    return true;
                }
            }

            return false;
        }

        public bool EditStructElement <TElement>
            (UInt64 id, Coordinate<TElement> coordinate, TElement d, string name, TypeStructElement type)
            where TElement : IComparable, new()
        {
            for (int i = 0; i < structElements.Count; ++i)
            {
                object obj = structElements[i];
                Type typeObj = obj.GetType();
                PropertyInfo propInfo = typeObj.GetProperty("Id");

                //if (structElements[i].Id == id)
                if (propInfo.Equals(id))
                {
                    StructElement<TElement> structElement;

                    switch (type)
                    {
                        case (TypeStructElement.slotDirect):
                            {
                                try
                                {
                                    structElement = new SlotDirect<TElement>(name, coordinate, d);
                                    structElements[i] = structElement;
                                }
                                catch
                                {
                                    return false;
                                }

                                break;
                            }
                        case (TypeStructElement.slotEvolvent):
                            {
                                try
                                {
                                    structElement = new SlotEvolvent<TElement>(name, coordinate, d);
                                    structElements[i] = structElement;
                                }
                                catch
                                {
                                    return false;
                                }

                                break;
                            }
                        case (TypeStructElement.fillet):
                            {
                                try
                                {
                                    structElement = new Fillet<TElement>(name, coordinate, d);
                                    structElements[i] = structElement;
                                }
                                catch
                                {
                                    return false;
                                }

                                break;
                            }
                        case (TypeStructElement.chamfer):
                            {
                                try
                                {
                                    structElement = new Chamfer<TElement>(name, coordinate, d);
                                    structElements[i] = structElement;
                                }
                                catch
                                {
                                    return false;
                                }

                                break;
                            }
                        case (TypeStructElement.dowel):
                            {
                                try
                                {
                                    structElement = new Dowel<TElement>(name, coordinate, d);
                                    structElements[i] = structElement;
                                }
                                catch
                                {
                                    return false;
                                }

                                break;
                            }
                        case (TypeStructElement.thread):
                            {
                                try
                                {
                                    structElement = new Thread<TElement>(name, coordinate, d);
                                    structElements[i] = structElement;
                                }
                                catch
                                {
                                    return false;
                                }

                                break;
                            }
                    }

                    break;
                }
            }

            return true;
        }
    }

    public class Coordinate<T> where T : new()
    {
        public T X,
                 Y,
                 Z;

        public Coordinate()
        {
            try
            {
                X = new T();
                Y = new T();
                Z = new T();
            }
            catch
            {
                throw new Exception("Coordinate hasnt been not constructioned");
            }
        }

        public Coordinate(T _x, T _y, T _z)
        {
            try
            {
                X = _x;
                Y = _y;
                Z = _z;
            }
            catch
            {
                throw new Exception("Coordinate hasnt been not constructioned");
            }
        }
    }

    public enum AccuracyClass
    {
        accurate,
        average,
        rough,
        very_rough
    }

    public enum TypeTreatment
    {
        grinding,
        polishing,
        facing
    }

    public enum TypeArea
    {
        cylindr,
        canon,
        nonstand
    }

    public enum TypeStructElement
    {
        slotDirect,
        slotEvolvent,
        fillet,
        chamfer,
        dowel,
        thread
    }
}
