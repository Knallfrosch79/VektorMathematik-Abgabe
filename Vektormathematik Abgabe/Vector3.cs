using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektormathematik_Abgabe
{
    internal class Vector3
    {
        // Felder der Klasse
        public float x;
        public float y;
        public float z;

        // Default-Konstruktor (setzt alle Felder auf 0)
        public Vector3()
        {
            this.x = 0f;
            this.y = 0f;
            this.z = 0f;
        }

        // Konstruktor mit Parametern (initialisiert Felder mit übergebenen Werten)
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Beispiel: Überschreibe ToString(), damit man den Vektor leicht ausgeben kann
        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }
    }
}
