//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
//using System.Text;
//using System.Threading.Tasks;

//namespace Vektormathematik_Abgabe
//{
//    internal class Vector3
//    {
//        public static Vector3 Addition(Vector3 v1, Vector3 v2)
//        {
//            Vector3 v3;
//            var (v1x, v1y, v1z) = VectorInFloat(v1);
//            var (v2x, v2y, v2z) = VectorInFloat(v2);
//            float v3x = v1x + v2x;
//            float v3y = v1y + v2y;
//            float v3z = v1z + v2z;
//            v3 = FloatInVector(v3x, v3y, v3z);
//            return v3;
//        }


//        public static Vector3 Subtraktion(Vector3 v1, Vector3 v2)
//        {
//            Vector3 v3;
//            var (v1x, v1y, v1z) = VectorInFloat(v1);
//            var (v2x, v2y, v2z) = VectorInFloat(v2);
//            float v3x = v1x - v2x;
//            float v3y = v1y - v2y;
//            float v3z = v1z - v2z;
//            v3 = FloatInVector(v3x, v3y, v3z);
//            return v3;
//        }

//        public static Vector3 Multiplikation(Vector3 v1, float num01)
//        {
//            Vector3 v3;
//            float v3x = v1.x * num01;
//            float v3y = v1.y * num01;
//            float v3z = v1.z * num01;
//            v3 = FloatInVector(v3x, v3y, v3z);
//            return v3;
//        }
//        public static Vector3 Division(Vector3 v1, float num01)
//        {
//            Vector3 v3;
//            while (num01 <= 0f)
//            {
//                Console.WriteLine(num01 == 0f
//                    ? "Division durch 0 ist nicht erlaubt. Bitte neue Zahl eingeben:"
//                    : "Division durch eine negative Zahl ist nicht erlaubt. Bitte neue Zahl eingeben:");
//                num01 = float.Parse(Console.ReadLine());
//                if (num01 == 0f)
//                {
//                    Console.WriteLine("Division durch 0 ist nicht erlaubt. Bitte neue Zahl eingeben:");
//                }
//                else
//                {
//                    Console.WriteLine("Division durch eine negative Zahl ist nicht erlaubt. Bitte neue Zahl eingeben:");
//                }
//            }
//            float v3x = v1.x / num01;
//            float v3y = v1.y / num01;
//            float v3z = v1.z / num01;
//            v3 = FloatInVector(v3x, v3y, v3z);
//            return v3;
//        }
//        public static float Vektorlaenge(Vector3 v)
//        {
//            float xQuadrat = v.x * v.x;
//            float yQuadrat = v.y * v.y;
//            float zQuadrat = v.z * v.z;

//            float summe = xQuadrat + yQuadrat + zQuadrat;
//            float länge = (float)Math.Sqrt(summe);

//            return länge;
//        }
//        public static float Quadratlaenge(Vector3 v)
//        {
//            float xQuadrat = v.x * v.x;
//            float yQuadrat = v.y * v.y;
//            float zQuadrat = v.z * v.z;

//            float quadratLänge = xQuadrat + yQuadrat + zQuadrat;
//            return quadratLänge;
//        }
//        public static float Punktprodukt(Vector3 v1, Vector3 v2)
//        {
//            float xProdukt = v1.x * v2.x;
//            float yProdukt = v1.y * v2.y;
//            float zProdukt = v1.z * v2.z;

//            float punktprodukt = xProdukt + yProdukt + zProdukt;
//            return punktprodukt;
//        }


//        private static Vector3 FloatInVector(float v3x, float v3y, float v3z)
//        {
//            Vector3 v3;
//            v3 = new Vector3(v3x, v3y, v3z);
//            return v3;
//        }

//        private static (float, float, float) VectorInFloat(Vector3 Vektor)
//        {
//            float VektorX = Vektor.x;
//            float VektorY = Vektor.y;
//            float VektorZ = Vektor.z;

//            return (VektorX, VektorY, VektorZ);
//        }
//    }
//}
