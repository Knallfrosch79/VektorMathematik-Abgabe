using System;

namespace Vektormathematik_Abgabe
{
    internal enum OperationType
    {
        Add,       // A
        Subtract,  // S
        Multiply,  // M
        Divide,    // D
        Length,    // L
        Square,    // Q
        DotProduct,// P
        Invalid
    }

    internal class OperatorChoosing
    {
        public static void ChoosingOperation()
        {
            // Wähle und parse Operation
            char opChar = TextGoodies.OperationsPick();
            OperationType operation = ParseOperation(opChar);

            // Hole benötigte Eingaben
            Vector3 v1 = default, v2 = default;
            float scalar = 0f;

            switch (operation)
            {
                case OperationType.Multiply:
                    (v1, scalar) = VectorNumInput();
                    break;
                case OperationType.Square:
                case OperationType.Length:
                    v1 = VectorInput();
                    break;
                case OperationType.Add:
                case OperationType.Subtract:
                case OperationType.DotProduct:
                    (v1, v2) = TwoVectorInput();
                    break;
                case OperationType.Divide:
                    // Für Division: Skalar wiederholt abfragen, bis ein gültiger (>0) eingegeben wird
                    v1 = VectorInput();
                    do
                    {
                        Console.Write("Bitte gib eine positive Zahl (>0) ein: ");
                        scalar = TextGoodies.ReadInput();
                        if (scalar <= 0f)
                            Console.WriteLine("Ungültig. Der Skalar muss größer als 0 sein.");
                    }
                    while (scalar <= 0f);
                    break;
                default:
                    Console.WriteLine("Ungültige Operation. Bitte A, S, M, D, L, Q oder P wählen.");
                    return;
            }

            // Führe Operation aus
            switch (operation)
            {
                case OperationType.Add:
                    var addRes = v1.Add(v2);
                    Console.WriteLine($"Das Ergebnis der Addition ist: {addRes}");
                    break;
                case OperationType.Subtract:
                    var subRes = v1.Subtract(v2);
                    Console.WriteLine($"Das Ergebnis der Subtraktion ist: {subRes}");
                    break;
                case OperationType.Multiply:
                    var mulRes = v1.Multiply(scalar);
                    Console.WriteLine($"Das Ergebnis der Multiplikation ist: {mulRes} (Vektor * {scalar})");
                    break;
                case OperationType.Divide:
                    var divRes = v1.Divide(scalar);
                    Console.WriteLine($"Das Ergebnis der Division ist: {divRes} (Vektor / {scalar})");
                    break;
                case OperationType.Length:
                    float len = v1.Length();
                    Console.WriteLine($"Die Länge des Vektors ist {len}.");
                    break;
                case OperationType.Square:
                    float sq = v1.SquareLength();
                    Console.WriteLine($"Die Quadratlänge des Vektors ist {sq}.");
                    break;
                case OperationType.DotProduct:
                    float dot = v1.Dot(v2);
                    Console.WriteLine($"Das Punktprodukt der beiden Vektoren ist {dot}.");
                    break;
            }

            TextGoodies.TextWait();
            TextGoodies.WaitForEnter();
        }

        private static OperationType ParseOperation(char c) => c switch
        {
            'A' => OperationType.Add,
            'S' => OperationType.Subtract,
            'M' => OperationType.Multiply,
            'D' => OperationType.Divide,
            'L' => OperationType.Length,
            'Q' => OperationType.Square,
            'P' => OperationType.DotProduct,
            _ => OperationType.Invalid
        };

        private static Vector3 VectorInput()
        {
            Console.Write("Bitte gib 3 Werte für den Vektor ein (z.B. \"1.0 2.5 -3\"): ");
            return ReadVectorFromConsole();
        }

        private static (Vector3, float) VectorNumInput()
        {
            Console.WriteLine("Gib einen Vektor und danach eine Zahl ein.");
            Console.Write("Bitte gib 3 Werte für den Vektor ein (z.B. \"1.0 2.5 -3\"): ");
            Vector3 v = ReadVectorFromConsole();
            Console.Write("Bitte gib eine Zahl ein (z.B. \"2.5\"): ");
            float scalar = TextGoodies.ReadInput();
            return (v, scalar);
        }

        private static (Vector3, Vector3) TwoVectorInput()
        {
            Console.WriteLine("Jetzt brauchen wir zwei Vektoren:");
            Console.Write("Bitte gib 3 Werte für den ersten Vektor ein (z.B. \"1.0 2.5 -3\"): ");
            Vector3 v1 = ReadVectorFromConsole();
            Console.WriteLine();
            Console.Write("Bitte gib 3 Werte für den zweiten Vektor ein (z.B. \"1.0 2.5 -3\"): ");
            Vector3 v2 = ReadVectorFromConsole();
            return (v1, v2);
        }

        private static Vector3 ReadVectorFromConsole()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Leere Eingabe. Bitte drei Zahlen eingeben (Format: x y z).");
                    continue;
                }

                string[] parts = input.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 3
                    || !float.TryParse(parts[0], out float x)
                    || !float.TryParse(parts[1], out float y)
                    || !float.TryParse(parts[2], out float z))
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte genau drei Werte eingeben (Format: x y z). Beispiel: 1.0 2.5 -3");
                    continue;
                }

                return new Vector3(x, y, z);
            }
        }
    }
}
