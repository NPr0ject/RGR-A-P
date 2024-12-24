using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Threading;
class ProgrammZylie
{
    public static string Zaklinanye(string[] S, int StartLine)
    {
        string Line = "";

        string[] Singr = S[StartLine - 1].Split(' ');
        for (int i = 1; i < Singr.Length; i++)
        {
            if (int.TryParse(Singr[i], out int number) == true)
            {
                Line += Zaklinanye(S, number);
            }
            else
            {
                Line += Singr[i];
            }
        }
        if (Singr[0] == "DUST")
        {
            Line = "DT" + Line + "TD";//исключение для dust
        }
        else if (Singr[0] != "DUST")
        {
            Line = Convert.ToString(Singr[0][0]) + Convert.ToString(Singr[0][2]) + Line 
                + Convert.ToString(Singr[0][2]) + Convert.ToString(Singr[0][0]);
        }
        return Line;
    }
    static void Main()
    {
        string[] ingr = new string[102];
        int count = 0;
        while ((ingr[count] = Console.ReadLine()) != "")
        {
            count++;
        }
        Console.WriteLine(Zaklinanye(ingr, count));     
    }
}
    }
}
