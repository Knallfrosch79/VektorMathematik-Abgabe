using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Vektormathematik_Abgabe
{
    internal class OperatorChoosing
    {
        public static void ChoosingOperation()
        {
            // Deklaration der Variablen
            Vector3 v3;
            Vector3 v1 = new Vector3();
            Vector3 v2 = new Vector3();
            float num01 = 0f; // Initialisierung für den Fall, dass Multiplikation gewählt wird
            float product;
            
            char operation = TextGoodies.OperationsPick();
                //Console.WriteLine($"[DEBUG] ausgewähltes Zeichen: '{operation}'\n");
                //Console.WriteLine("[DEBUG] Jetzt rufe ich VektorInput() auf …");
            if (operation == 'M')
            {
                (v1, num01) = VectorNumInput();
            }
            else if (operation == 'Q')
            {
                (v1) = VectorInput();
            }
            else
            {
                (v1, v2) = TwoVectorInput();
                //Console.WriteLine("[DEBUG] VektorInput() wurde zurückgegeben.\n");
            }

            if (operation == 'A')
            {
                v3 = V_Calculation.Addition(v1, v2);
                TextGoodies.TextWait();
                Console.WriteLine($"Das Ergebnis der Addition ist: Vektor3 {v3}");
                TextGoodies.WaitForEnter();
                return;
            }
            else if (operation == 'S')
            {
                v3 = V_Calculation.Subtraktion(v1, v2);
                TextGoodies.TextWait();
                Console.WriteLine($"Das Ergebnis der Subtraktion ist: Vektor3 {v3}");
                TextGoodies.WaitForEnter();
                return;
            }
            else if (operation == 'M')
            {
                v3 = V_Calculation.Multiplikation(v1, num01);
                TextGoodies.TextWait();
                Console.WriteLine($"Das Ergebnis der Multiplikation ist: Vektor3 {v3} - (Vektor1 * {num01})");
                TextGoodies.WaitForEnter();
                return;
            }
            else if (operation == 'D')
            {
                v3 = V_Calculation.Division(v1, num01);
                TextGoodies.TextWait();
                Console.WriteLine($"Das Ergebnis der Division ist: Vektor3 {v3} - (Vektor3 : {num01})");
                TextGoodies.WaitForEnter();
                return;
            }
            else if (operation == 'L')
            {
                float length1 = V_Calculation.Vektorlaenge(v1);
                float length2 = V_Calculation.Vektorlaenge(v2);
                TextGoodies.TextWait();
                Console.WriteLine($"Die Länge des ersten Vektors ist {length1} und die des zweiten {length2}.");
                TextGoodies.WaitForEnter();
                return;
            }
            else if (operation == 'Q')
            {
                product = V_Calculation.Quadratlaenge(v1);
                TextGoodies.TextWait();
                Console.WriteLine($"Die Quadratlänge des Vektores ist {product}.");
                TextGoodies.WaitForEnter();
                return;
            }
            else if (operation == 'P')
            {
                product = V_Calculation.Punktprodukt(v1, v2);
                TextGoodies.TextWait();
                Console.WriteLine($"Das Punktprodukt der beiden Vektoren ist {product}.");
                TextGoodies.WaitForEnter();
                return;
            }
        }

        /// <summary>
        /// Liest einen Vektor vom Nutzer ein und gibt ihn zurück.
        /// </summary>
        /// <returns></returns>
        private static Vector3 VectorInput()
        {
            Console.Write("Bitte gib 3 Werte für den Vektor ein (z.B.\"1.0 2.5 -3\"):");
            Vector3 v1 = ReadVectorFromConsole();
            return v1;
        }

        /// <summary>
        /// Liest einen Vektor und eine Zahl vom Nutzer ein und gibt sie als Tupel zurück.
        /// </summary>
        /// <returns></returns>
        private static (Vector3 v1, float num01) VectorNumInput()
        {
            Console.WriteLine("Gib jetzt bitte einmal den Vektor ein und danach die Zahl.");
            Console.Write("Bitte gib 3 Werte für den Vektor ein (z.B.\"1.0 2.5 -3\"):");
            Vector3 v1 = ReadVectorFromConsole();
            Console.WriteLine("");
            Console.Write("Bitte gib eine Zahl ein (z.B. \"2.5\"): ");
            float num01 = TextGoodies.ReadInput(); // Liest eine Zahl vom Nutzer ein
            return (v1, num01);
        }

        /// <summary>
        /// Liest zwei Vektoren vom Nutzer ein und gibt sie als Tupel zurück.
        /// </summary>
        /// <returns></returns>
        private static (Vector3 , Vector3) TwoVectorInput()
        {
            Console.WriteLine("Jetzt brauchen wir noch die beiden Vektoren:");
            Console.Write("Bitte gib 3 Werte für den ersten Vektor ein (z.B.\"1.0 2.5 -3\"):");
            Vector3 v1 = ReadVectorFromConsole();
            Console.WriteLine("");
            Console.Write("Bitte gib 3 Werte für den zweiten Vektor ein (z.B.\"1.0 2.5 -3\"):");
            Vector3 v2 = ReadVectorFromConsole();
            return (v1 , v2);
        }

        

        /// <summary>
        /// Liest eine Zeile vom Nutzer ein, erwartet drei durch Leerzeichen getrennte Zahlen,
        /// und wandelt diese in einen Vector3 um.
        /// </summary>
        static Vector3 ReadVectorFromConsole()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Leere Eingabe. Bitte drei Zahlen eingeben (z.B. \"1.0 2.5 -3\").");
                    continue;
                }

                // input.Trim(): Entfernt alle führenden und nachfolgenden Leer- oder Tabulator-Zeichen aus dem eingegebenen String.
                // Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries):
                //   • new[] { ' ', '\t' } gibt an, dass an jedem Leerzeichen (' ') oder Tabulator ('\t') getrennt werden soll.
                //   • StringSplitOptions.RemoveEmptyEntries sorgt dafür, dass aus mehreren aufeinanderfolgenden Leerzeichen/Tabs
                //     keine leeren Einträge im Ergebnis-Array entstehen.
                // Zusammen bedeutet das: Zerlege den bereinigten Eingabe-String an Leerzeichen und Tabs und lösche leere Einträge.
                string[] parts = input.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 3)
                {
                    Console.WriteLine("Falsches Format. Bitte genau drei Werte eingeben (Format: x y z).");
                    continue;
                }

                // Versuchen, die drei Teile in floats zu parsen
                bool okX = float.TryParse(parts[0], out float x);
                bool okY = float.TryParse(parts[1], out float y);
                bool okZ = float.TryParse(parts[2], out float z);

                if (!okX || !okY || !okZ)
                {
                    Console.WriteLine("Ungültige Zahleneingabe. Achte darauf, Punkte oder Komma als Dezimaltrennzeichen zu verwenden.");
                    Console.WriteLine("Beispiel: 1.0 2.5 -3");
                    continue;
                }

                // Alles erfolgreich geparst → neuen Vector3 zurückgeben
                return new Vector3(x, y, z);
            }
        }

       
        


        
    }
}
