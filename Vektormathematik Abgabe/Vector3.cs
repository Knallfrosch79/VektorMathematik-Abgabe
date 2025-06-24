using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektormathematik_Abgabe
{
    internal struct Vector3
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


        /// <summary>
        /// Adds two vectors together and returns the result as a new vector.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Vector3</returns>
        public Vector3 Add(Vector3 other)
        {
            return new Vector3(this.x + other.x, this.y + other.y, this.z + other.z);
        }

        /// <summary>
        /// Subtracts another vector from this vector and returns the result as a new vector.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Vector3</returns>
        public Vector3 Subtract(Vector3 other)
        {
            return new Vector3(this.x - other.x, this.y - other.y, this.z - other.z);
        }

        /// <summary>
        /// Multiplies this vector by a scalar and returns the result as a new vector.
        /// </summary>
        /// <param name="scalar"></param>
        /// <returns>Vector3</returns>
        public Vector3 Multiply(float scalar)
        {
            return new Vector3(this.x * scalar, this.y * scalar, this.z * scalar);
        }

        /// <summary>
        /// Divides this vector by a scalar and returns the result as a new vector.
        /// </summary>
        /// <param name="scalar"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Vector3</exception>
        public Vector3 Divide(float scalar)
        {
            if (scalar <= 0f)
                throw new ArgumentException("Skalar muss positiv und ungleich 0 sein.");
            return new Vector3(this.x / scalar, this.y / scalar, this.z / scalar);
        }

        /// <summary>
        /// Calculates the length (magnitude) of the vector.
        /// </summary>
        /// <returns>float</returns>
        public float Length()
        {
            return (float)Math.Sqrt(SquareLength());
        }

        /// <summary>
        /// Calculates the square of the length (magnitude) of the vector.
        /// </summary>
        /// <returns>float</returns>
        public float SquareLength()
        {
            return x * x + y * y + z * z;
        }

        /// <summary>
        /// Calculates the dot product of this vector with another vector.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Vector3</returns>
        public float Dot(Vector3 other)
        {
            return this.x * other.x + this.y * other.y + this.z * other.z;
        }


        private static Vector3 FloatInVector(float v3x, float v3y, float v3z)
        {
            Vector3 v3;
            v3 = new Vector3(v3x, v3y, v3z);
            return v3;
        }

        private static (float, float, float) VectorInFloat(Vector3 Vektor)
        {
            float VektorX = Vektor.x;
            float VektorY = Vektor.y;
            float VektorZ = Vektor.z;

            return (VektorX, VektorY, VektorZ);
        }
    }
}
