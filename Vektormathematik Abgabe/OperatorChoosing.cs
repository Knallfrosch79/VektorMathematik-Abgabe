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
        //ToDo:     Datentypfehlerlösung finden
        //          Berechnungen
        //          Anforderungen analysieren

        public static void ChoosingOperation()
        {
            Vector3 v3;
            float product;
            
            char operation = OperationsPick();
                //Console.WriteLine($"[DEBUG] ausgewähltes Zeichen: '{operation}'\n");
                //Console.WriteLine("[DEBUG] Jetzt rufe ich VektorInput() auf …");
            Console.WriteLine("Du hast die Operation " + operation + " gewählt.\n");

            var (v1 , v2) = VektorInput();
            //Console.WriteLine("[DEBUG] VektorInput() wurde zurückgegeben.\n");

            if (operation == 'A')
            {
                v3 = V_Calculation.Addition(v1, v2);
            }
            else if (operation == 'S')
            {
                v3 = V_Calculation.Subtraktion(v1, v2);
            }
            else if (operation == 'M')
            {
                v3 = V_Calculation.Multiplikation(v1, v2);
            }
            else if (operation == 'D')
            {
                v3 = V_Calculation.Division(v1, v2);
            }
            else if (operation == 'L')
            {
                float length1 = V_Calculation.Vektorlaenge(v1);
                float length2 = V_Calculation.Vektorlaenge(v2);
                Console.WriteLine($"Die Länge des ersten Vektors ist {length1} und die des zweiten {length2}.");
                return;
            }
            else if (operation == 'Q')
            {
                product = V_Calculation.Quadratlaenge(v1, v2);
                Console.WriteLine($"Die Quadratlänge der beiden Vektoren ist {product}.");
                return;
            }
            else if (operation == 'P')
            {
                product = V_Calculation.Punktprodukt(v1, v2);
                Console.WriteLine($"Das Punktprodukt der beiden Vektoren ist {product}.");
                return;
            }
            else
            {
                Console.WriteLine("Ungültige Operation gewählt.");
                return;
            }
        }

        private static (Vector3 , Vector3) VektorInput()
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

        /// <summary>
        /// Auswahlmenü welche Berechnung man durchführen möchte.
        /// </summary>
        /// <returns></returns>
        private static char OperationsPick()
        {
            string[] options = { "Addition", "Suptraktion", "Multiplikation", "Division", "Vektorlänge", "Distanzrechnung", "Quadratlänge", "Punktproduktrechnung" };  // Die Auswahlmöglichkeiten
            int selectedIndex = 0;            // Startet bei Option 0 ("Addition")
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                Console.WriteLine("Dann wählen wir einmal aus, welche Berechnung wir durchführen möchten:\n");

                // Ausgabe aller Optionen nebeneinander
                for (int i = 0; i < options.Length; i++)
                {
                    // Markiere die aktuell ausgewählte Option mit eckigen Klammern
                    if (i == selectedIndex)
                        DrawCursor('[', options[i], ']');
                    else
                        DrawCursor(' ', options[i], ' ');

                    // Füge einen Abstand zwischen den Optionen ein
                    Console.Write("  ");
                }
                Console.WriteLine();

                // Lese die Eingabe des Benutzers
                Console.WriteLine("\nBestätige deine Eingabe mit 'Enter'.");

                keyInfo = Console.ReadKey(true);

                // Bei linker Pfeiltaste wird der Index um 1 verringert (wenn er > 0 ist)
                if (keyInfo.Key == ConsoleKey.LeftArrow && selectedIndex > 0)
                    selectedIndex--; // Auswahl zurücksetzen auf "O" (Option 0)

                // Bei rechter Pfeiltaste wird der Index um 1 erhöht (wenn er < max index ist)
                else if (keyInfo.Key == ConsoleKey.RightArrow && selectedIndex < options.Length - 1)
                    selectedIndex++; // Auswahl auf "X" (Option 1) setzen

            } while (keyInfo.Key != ConsoleKey.Enter); // Schleife bis Enter gedrückt wird

            // Gibt die ausgewählte Option zurück
            return options[selectedIndex][0];  // Rückgabe des ersten Zeichens der ausgewählten Option
        }
        private static void DrawCursor(char LeftChar, string Text, char Rightchar)
        {
            Console.Write(LeftChar);
            Console.Write(Text);
            Console.Write(Rightchar);
        }
    }
}
