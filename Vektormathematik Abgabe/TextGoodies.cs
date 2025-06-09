using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektormathematik_Abgabe
{
    internal class TextGoodies
    {
        /// <summary>
        /// Zeigt eine Ladeanimation an, um dem Nutzer zu signalisieren, dass eine Berechnung durchgeführt wird. Ist nur ein Optisches Goodie.
        /// </summary>
        public static void TextWait()
        {
            Console.WriteLine("");
            for (int i = 0; i < 3; i++)
            {
                Console.Write('.');
                Thread.Sleep(500);
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }
        /// <summary>
        /// Liest eine Zahl vom Nutzer ein und gibt sie als float zurück.
        /// </summary>
        /// <returns></returns>
        public static float ReadInput()
        {

            while (true)
            {
                string input = Console.ReadLine();
                if (float.TryParse(input, out float result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte eine gültige Zahl eingeben.");
                    return ReadInput(); // Rekursive Abfrage bei ungültiger Eingabe
                }
            }
        }

        /// <summary>
        /// Auswahlmenü welche Berechnung man durchführen möchte.
        /// </summary>
        /// <returns></returns>
        public static char OperationsPick()
        {
            string[] options = { "Addition", "Suptraktion", "Multiplikation", "Division", "Vektorlänge", "Distanzrechnung", "Quadratlänge", "Punktproduktrechnung", "Information" };  // Die Auswahlmöglichkeiten
            int selectedIndex = 0;            // Startet bei Option 0 ("Addition")
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Dann wählen wir einmal aus, welche Berechnung wir durchführen möchten:\n(Nutze Hierfür die Pfeiltasten)\n");

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
            if (options[selectedIndex][0] == 'I') // Wenn die Option "Information" ausgewählt wurde
            {
                InformationDraw(); // Zeige die Informationen an
                return OperationsPick(); // Gehe zurück zur Auswahl
            }
            // Gibt die ausgewählte Option zurück
            return options[selectedIndex][0];  // Rückgabe des ersten Zeichens der ausgewählten Option
        }

        /// <summary>
        /// Zeigt ein Ja/Nein-Menü an, in dem der Nutzer eine Auswahl treffen kann.
        /// </summary>
        /// <returns></returns>
        public static bool JaNeinMenu()
        {
            string[] options = { "Ja", "Nein" };
            int selectedIndex = 0;
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                Console.WriteLine("Möchtest du noch eine Berechnung ausführen?\n");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                        DrawCursor('[', options[i], ']');
                    else
                        DrawCursor(' ', options[i], ' ');

                    Console.Write("  ");
                }

                Console.WriteLine("\n\nNavigiere mit den Pfeiltasten und bestätige mit Enter.");

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.LeftArrow && selectedIndex > 0)
                    selectedIndex--;

                else if (keyInfo.Key == ConsoleKey.RightArrow && selectedIndex < options.Length - 1)
                    selectedIndex++;

            } while (keyInfo.Key != ConsoleKey.Enter);

            return selectedIndex == 0; // true bei "Ja", false bei "Nein"
        }

        /// <summary>
        /// Zeigt eine Übersicht der verfügbaren Vektoroperationen und deren Beschreibungen an.
        /// </summary>
        public static void InformationDraw()
        {
            Console.Clear();
            Console.WriteLine("1. Vektoraddition");
            Console.WriteLine("Mit dieser Methode werden zwei Vektoren miteinander addiert.");
            Console.WriteLine("Dabei wird jede Komponente (x, y, z) des ersten Vektors mit der entsprechenden Komponente des zweiten Vektors addiert.");
            Console.WriteLine("Beispiel: (1, 2, 3) + (4, 5, 6) = (5, 7, 9)");
            Console.WriteLine();

            Console.WriteLine("2. Vektorsubtraktion");
            Console.WriteLine("Diese Methode subtrahiert den zweiten Vektor vom ersten.");
            Console.WriteLine("Jede Komponente des zweiten Vektors wird von der entsprechenden Komponente des ersten Vektors abgezogen.");
            Console.WriteLine("Beispiel: (5, 7, 9) - (1, 2, 3) = (4, 5, 6)");
            Console.WriteLine();

            Console.WriteLine("3. Vektormultiplikation mit einer Zahl");
            Console.WriteLine("Ein Vektor wird mit einem Skalar (einer Zahl) multipliziert.");
            Console.WriteLine("Alle Komponenten des Vektors werden mit dieser Zahl multipliziert.");
            Console.WriteLine("Beispiel: (1, 2, 3) × 2 = (2, 4, 6)");
            Console.WriteLine();

            Console.WriteLine("4. Vektordivision durch eine Zahl");
            Console.WriteLine("Hier wird ein Vektor durch einen Skalar (eine Zahl größer als 0) geteilt.");
            Console.WriteLine("Die Division durch 0 oder eine negative Zahl ist nicht erlaubt und wird abgefangen.");
            Console.WriteLine("Beispiel: (4, 8, 12) ÷ 2 = (2, 4, 6)");
            Console.WriteLine();

            Console.WriteLine("5. Vektorlänge (Betrag)");
            Console.WriteLine("Berechnet die Länge eines Vektors – also seine Entfernung vom Nullpunkt im Raum.");
            Console.WriteLine("Verwendet wird die Wurzelformel: √(x² + y² + z²)");
            Console.WriteLine();

            Console.WriteLine("6. Quadratlänge eines Vektors");
            Console.WriteLine("Berechnet die Summe der quadrierten Komponenten eines Vektors.");
            Console.WriteLine("Diese Methode ist eine vereinfachte Form zur Längeberechnung ohne die Quadratwurzel.");
            Console.WriteLine("Formel: x² + y² + z²");
            Console.WriteLine();

            Console.WriteLine("7. Punktprodukt (Skalarprodukt)");
            Console.WriteLine("Berechnet das Skalarprodukt (Punktprodukt) zweier Vektoren.");
            Console.WriteLine("Dieses gibt Informationen über die Lagebeziehung der beiden Vektoren, z. B. ob sie orthogonal zueinander stehen.");
            Console.WriteLine("Ein Ergebnis von 0 bedeutet, dass die Vektoren im rechten Winkel zueinander stehen.");
            TextGoodies.TextWait();
            WaitForEnter();
            Console.Clear();
        }
        /// <summary>
        /// Wartet auf die Eingabe der Enter-Taste, um fortzufahren.
        /// </summary>
        public static void WaitForEnter()
        {
            Console.WriteLine("Drücke 'Enter', um fortzufahren.");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                // Nichts tun, nur auf Enter warten
            }
        }

        /// <summary>
        /// Zeichnet den Cursor für die Auswahlmöglichkeiten im Menü.
        /// </summary>
        /// <param name="LeftChar"></param>
        /// <param name="Text"></param>
        /// <param name="Rightchar"></param>
        private static void DrawCursor(char LeftChar, string Text, char Rightchar)
        {
            Console.Write(LeftChar);
            Console.Write(Text);
            Console.Write(Rightchar);
        }

    }
}
