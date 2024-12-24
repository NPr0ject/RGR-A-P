using System;
using System.Data.SqlTypes;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading;
class Programm
{
    static void Main()
    {
        int N = Convert.ToInt32(Console.ReadLine());
        string[] deystvie = new string[N];
        string[] argument = new string[N];
        for (int i = 0; i < N; i++)
        {
            string s = Console.ReadLine();
            string[] sSplit = s.Split(' ');
            argument[i] = sSplit[1];
            deystvie[i] = sSplit[0];
        }
        int last = Convert.ToInt32(Console.ReadLine());
        int XCount = 1;
        int[] k = new int[N + 1];
        k[0] = 0;    
        for (int i = 0; i < N; i++)
        {
            switch (deystvie[i])
            {
                case "+":
                    if (int.TryParse(argument[i], out int resultplus))
                    {
                        k[i + 1] = k[i] + resultplus;
                    } 
                    else
                    {
                        XCount++;
                        k[i + 1] = k[i];
                    }
                    break;
                case "-":
                    if (int.TryParse(argument[i], out int resultminus))
                    {
                        k[i + 1] = k[i] - resultminus;
                    }
                    else
                    {
                        XCount--;
                        k[i + 1] = k[i];
                    }
                    break;
                case "*":
                    XCount *= Convert.ToInt32(argument[i]);
                    k[i+ 1] = k[i] * Convert.ToInt32(argument[i]);
                    break;
                default:
                    Console.WriteLine("ошибка switch");
                    break;
            }
        }
        if (XCount != 0)
        {
            int ans = (last - k[N]) / XCount;
            Console.WriteLine(ans);
        }
    }
}
