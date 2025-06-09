using System;
using System.Security.Principal;

namespace Vektormathematik_Abgabe
{
    internal class Program
    {
        private static bool repeat = true;
        
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("Willommen zum Vektormathematikrechner.");
            TW();
            Console.WriteLine("Mithilfe dieses Rechners, können wir gemeinsam Vektorberechnungen durchführen.");
            TW();
            TextGoodies.WaitForEnter();
            Console.Clear();
            //Console.WriteLine("[DEBUG] Wir starten jetzt in die ChoosingOperation Formel");
            while (repeat == true)
            {
                OperatorChoosing.ChoosingOperation();
                Console.WriteLine("Möchtest du noch eine Berechnung durchführen?");
                bool JaNein = TextGoodies.JaNeinMenu();
                if (JaNein == true)
                {
                    Console.Clear();
                    repeat = true;
                }
                else
                {
                    repeat = false;
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("Vielen Dank für die Nutzung des Vektormathematikrechners. \n");
                    Console.WriteLine("Auf Wiedersehen!");
                    TW();
                    Console.WriteLine("");
                }
            }


        }

        /// <summary>
        /// Verweis auf die Methode TextWait() in der Klasse TextGoodies, für die kürzere Schreibweise in der Main Methode.
        /// </summary>
        private static void TW()
        {
            TextGoodies.TextWait();
        }
        
    }
}