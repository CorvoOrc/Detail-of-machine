/*autor Steshenko A.S. IVT-465*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ShaftConstruction
{
    class Shaft
    {
        Material material;
        List<object> shaftArea;

        public Material Material
        {
            get
            {
                return material;
            }
        }

        public List<object> ShaftArea
        {
            get
            {
                return shaftArea;
            }
        }

        public Shaft()
        {
            try
            {
                material = Material.alloy;
                shaftArea = new List<object>();
            }
            catch
            {
                throw new Exception("Shaft hasnt been not constructioned");
            }
        }

        public Shaft
            (Material _material)
        {
            try
            {
                material = _material;
                shaftArea = new List<object>();
            }
            catch
            {
                throw new Exception("Shaft hasnt been not constructioned");
            }

        }

        public bool AddArea<TArea>
            (TArea len, TArea d)
        {
            try
            {
                shaftArea.Add(new ShaftArea<TArea>(len, d));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteArea
            (UInt64 id)
        {
            for (int i = 0; i < shaftArea.Count; ++i)
            {
                object obj = shaftArea[i];
                Type typeObj = obj.GetType();
                PropertyInfo propInfo = typeObj.GetProperty("Id");

                if (propInfo.Equals(id))
                {
                    try
                    {
                        shaftArea.RemoveAt(i);
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
    }

    public enum Material
    {
        carbon,
        alloy
    }
}
