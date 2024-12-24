using System;
using System.Linq;
using System.Runtime.InteropServices;
//String.Equals
class ProgrammForm
{   
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray); // применяю метод массива
        return new string(charArray);
    }
    public static string UpSide(string ishodnik, string[] Polovinki)
    {
        string s = "";
        string substrIS = ishodnik.Substring(0, 5);
        for (int i = 0; i < Polovinki.Length; i++)
        {
            string substrPOL = Polovinki[i].Replace(" ", "").Substring(0, 5);
            if (substrIS.Equals(substrPOL) || substrIS.Equals(Reverse(substrPOL))) // жить не хочется 00111 
            {
            s += i + " ";
            }
        }
        return s;
    }
    public static string DownSide(string ishodnik, string[] Polovinki, string podhod)
    {// podhod это s из прошлой функции
     //replace
        string s = "";
        string substrIS = ishodnik.Substring(10, 5);
        for (int i = 0; i < Polovinki.Length; i++)
        {
            string substrPOL = Polovinki[i].Replace(" ", "").Substring(10, 5);
            if (podhod.Contains(Convert.ToString(i)))
            {
                if (substrIS.Equals(substrPOL) || substrIS.Equals(Reverse(substrPOL)))
                {
                    s += i + " ";
                }
            }
    }
    return s;
    }
    public static string InSide(string ishodnik, ref string[] Polovinki, string podhod)
    {// podhod это s из прошлой функции
     //replace
        string ans = "";
        int x = -1, y = -1;
        string substrIS1 = ishodnik.Substring(5, 5);
        string substrIS2 = ishodnik.Substring(15, 5);
        for (int i = 0; i < Polovinki.Length; i++)
        {
            string substrPOL = Polovinki[i].Replace(" ", "").Substring(5, 5);
            if (podhod.Contains(Convert.ToString(i)))
            {
                if (substrPOL.Equals(substrIS1) ||  Reverse(substrPOL).Equals(substrIS1))
                    {
                        x = i + 1;
                    }
                    else if (substrPOL.Equals(substrIS2) || Reverse(substrPOL).Equals(substrIS2))
                    {
                        y = i + 1;
                    }
            }
        }
        /*Polovinki[x].Replace('1', '5');
        Polovinki[y].Replace('1', '5');
        Polovinki[x].Replace('0', '5');
        Polovinki[y].Replace('0', '5');// этими строками гарантирую что использованные половинки не буду сильно замедлатья код. (только в Upside) 
        */if (x < y)
        {
            ans = x + " " + y;
        }
        else
        {
            ans = y + " " + x;
        }
        return ans;
     }
    static void Main()
    {
        Console.WriteLine("Введите Кол-во деталей");

        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите Детали");
        string[] ans = new string[n];
        string[] ishod = new string[n];
        for (int i = 0; i < n; i++)
        {
            ishod[i] = Console.ReadLine();
        }
        string[] polovina = new string[2 * n];
        Console.WriteLine("Ввод деталей завершён \nВведите Половинки=");
        for (int i = 0; i < 2 * n; i++)
        {
            polovina[i] = Console.ReadLine();
        }
        for (int i = 0; i < n; i++)
        {
            //Console.WriteLine(polovina[i].Replace(" ", ""));
            ans[i] = InSide(ishod[i].Replace(" ", ""), ref polovina, DownSide(ishod[i].Replace(" ", ""), polovina, UpSide(ishod[i].Replace(" ", ""), polovina)));
            Console.WriteLine(ans[i]);
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(UpSide(ishod[i].Replace(" ", ""), polovina));
            Console.WriteLine(DownSide(ishod[i].Replace(" ", ""), polovina, UpSide(ishod[i].Replace(" ", ""), polovina)));
            Console.WriteLine(ishod[i].Replace(" ", "").Substring(0, 5));
            Console.WriteLine(polovina[i].Replace(" ", "").Substring(0, 5));
        }
        /*for (int i = 0;i < n; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                if (s[1])
            }
        }*/
    }
}
