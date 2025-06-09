using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektormathematik_Abgabe
{
    internal class TextGoodies
    {
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
    }
}
