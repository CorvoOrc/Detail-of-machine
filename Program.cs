/*autor Steshenko A.S. IVT-465*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ShaftConstruction
{
    class Program
    {
        static bool Sample1(ref Shaft shaft)
        {
            try
            {
                shaft.AddArea<double>(110.55, 160.00);

                object shaftPart = shaft.ShaftArea[0];

                MethodInfo objMethod = shaftPart.GetType().GetMethod("AddStructElement", new Type[] { typeof(string), typeof(TypeStructElement) });

                MethodInfo genericMetod;
                object result;

                genericMetod = objMethod.MakeGenericMethod(typeof(double));
                result = genericMetod.Invoke(shaftPart, new object[] { "detail", TypeStructElement.slotDirect });

                genericMetod = objMethod.MakeGenericMethod(typeof(int));
                result = genericMetod.Invoke(shaftPart, new object[] { "detail", TypeStructElement.chamfer });

                genericMetod = objMethod.MakeGenericMethod(typeof(float));
                result = genericMetod.Invoke(shaftPart, new object[] { "detail", TypeStructElement.slotEvolvent });
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
                return false;
            }

            return true;
        }

        static bool Sample2(ref Shaft shaft)
        {
            try
            {
                shaft.AddArea<int>((int)130.9, (int)32.9);
                shaft.AddArea<int>(130, 32);
                shaft.AddArea<double>(130, 45);

                object shaftPart;
                shaftPart = shaft.ShaftArea[0];

                MethodInfo objMethod;
                objMethod = shaftPart.GetType().GetMethod("AddStructElement", new Type[] { typeof(string), typeof(TypeStructElement) });

                MethodInfo genericMetod;
                object result;


                genericMetod = objMethod.MakeGenericMethod(typeof(double));
                result = genericMetod.Invoke(shaftPart, new object[] { "detail", TypeStructElement.fillet });

                genericMetod = objMethod.MakeGenericMethod(typeof(int));
                result = genericMetod.Invoke(shaftPart, new object[] { "vise", TypeStructElement.chamfer });

                shaftPart = shaft.ShaftArea[1];
                objMethod = shaftPart.GetType().GetMethod("AddStructElement", new Type[] { typeof(string), typeof(TypeStructElement) });

                genericMetod = objMethod.MakeGenericMethod(typeof(int));
                result = genericMetod.Invoke(shaftPart, new object[] { "detail", TypeStructElement.slotDirect });

                genericMetod = objMethod.MakeGenericMethod(typeof(double));
                result = genericMetod.Invoke(shaftPart, new object[] { "detail", TypeStructElement.chamfer });

                genericMetod = objMethod.MakeGenericMethod(typeof(float));
                result = genericMetod.Invoke(shaftPart, new object[] { "detail", TypeStructElement.dowel });

                shaftPart = shaft.ShaftArea[2];
                objMethod = shaftPart.GetType().GetMethod("AddStructElement", new Type[] { typeof(string), typeof(TypeStructElement) });

                genericMetod = objMethod.MakeGenericMethod(typeof(int));
                result = genericMetod.Invoke(shaftPart, new object[] { "detail", TypeStructElement.thread });

                genericMetod = objMethod.MakeGenericMethod(typeof(double));
                result = genericMetod.Invoke(shaftPart, new object[] { "detail", TypeStructElement.chamfer });


                object obj = shaft.ShaftArea[1];
                PropertyInfo propInfo = obj.GetType().GetProperty("Id");
                shaft.DeleteArea((UInt64)propInfo.GetValue(obj));

                /// Override troubles
                /// 
                //obj = shaft.ShaftArea[1];
                //PropertyInfo objProp = obj.GetType().GetProperty("StructElements");
                //var delElement = objProp.GetValue(obj) as IEnumerable<object>;
                //UInt64 target = 0;

                //UInt64 i = 0;
                //foreach (object element in delElement)
                //{
                //    if (i == target)
                //    {
                //        MethodInfo DeleteElement_Metod = element.GetType().GetMethod("DeleteStructElement", new Type[] { typeof(UInt64) });
                //        object verdict = DeleteElement_Metod.Invoke(element, new object[] { target });

                //        break;
                //    }

                //    ++i;
                //}

                foreach (object shaftArea in shaft.ShaftArea)
                {
                    if (shaftArea == null) continue;

                    PropertyInfo propertyInfo = shaftArea.GetType().GetProperty("StructElements");
                    var elements = propertyInfo.GetValue(shaftArea, null) as IEnumerable<object>;

                    foreach (object element in elements)
                    {
                        //MethodInfo Print_Metod = element.GetType().GetMethod("print", new Type[] { typeof(void) });
                        //object result1 = Print_Metod.Invoke(element, new object[] {});
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
                return false;
            }

            return true;
        }

        static bool Sample3()
        {
            List<object> details = new List<object>();
            for (int i = 0; i < 10000000; ++i)
            {
                if (i % 7 == 0)
                {
                    details.Add(new SlotDirect<int>());
                }
                else if (i % 5 == 0)
                {
                    details.Add(new Fillet<float>());
                }
                else if (i % 3 == 0)
                {
                    details.Add(new Thread<double>());
                }
                else if (i % 2 == 0)
                {
                    details.Add(new Chamfer<Int16>());
                }
            }

            Console.WriteLine("Single execution");

            var stopWatch = Stopwatch.StartNew();
            foreach (object detail in details)
            {
                //compute...
                //Console.WriteLine("Thread Id = {0}", Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("Result time = {0} s", stopWatch.Elapsed.TotalSeconds);

            Console.WriteLine("Parallel execution");
            stopWatch = Stopwatch.StartNew();
            Parallel.ForEach(details, detail =>
            {
                // compute...
                //Console.WriteLine("Thread Id = {0}", Thread.CurrentThread.ManagedThreadId);
            }
            );
            Console.WriteLine("Result time = {0} s", stopWatch.Elapsed.TotalSeconds);

            Console.ReadKey();

            return true;
        }

        static void Main(string[] args)
        {
            Shaft shaft1 = new Shaft();
            bool verdict = Sample1(ref shaft1);

            Shaft shaft2 = new Shaft();
            verdict = Sample2(ref shaft2);

            verdict = Sample3();
        }
    }
}
