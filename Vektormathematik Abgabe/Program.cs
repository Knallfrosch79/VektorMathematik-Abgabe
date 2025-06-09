using System;
using System.Security.Principal;

namespace Vektormathematik_Abgabe
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Willommen zum Vektormathematikrechner. \n");
            TW();
            Console.WriteLine("Mithilfe dieses Rechners, können wir gemeinsam Vektorberechnungen durchführen.");
            TW();
            Console.Clear();
                //Console.WriteLine("[DEBUG] Wir starten jetzt in die ChoosingOperation Formel");
            OperatorChoosing.ChoosingOperation();


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