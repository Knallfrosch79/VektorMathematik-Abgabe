using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Vektormathematik_Abgabe
{
    internal class V_Calculation
    {
        public static Vector3 Addition(Vector3 v1, Vector3 v2) 
        {
            Vector3 v3;

            v3 = v1.x + v2;

            return v3;
        }

        public static Vector3 Subtraktion(Vector3 v1, Vector3 v2)
        {
            Vector3 v3;
            v3 = v1.x + v2.x;
            return v3;
        }

        public static Vector3 Multiplikation(Vector3 v1, Vector3 v2)
        {
            Vector3 v3;
            v3 = v1.x * v2;
            return v3;
        }
        public static Vector3 Division(Vector3 v1, Vector3 v2)
        {
            Vector3 v3;
            v3 = v1.x / v2;
            return v3;
        }
        public static float Vektorlaenge(Vector3 v)
        {
            return (float)Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
        }
        public static float Quadratlaenge(Vector3 v1, Vector3 v2)
        {
            return (float)(Math.Pow(v1.x, 2) + Math.Pow(v1.y, 2) + Math.Pow(v1.z, 2) + Math.Pow(v2.x, 2) + Math.Pow(v2.y, 2) + Math.Pow(v2.z, 2));
        }
        public static float Punktprodukt(Vector3 v1, Vector3 v2)
        {
            return (v1.x * v2.x + v1.y * v2.y + v1.z * v2.z);
        }

    }
}
