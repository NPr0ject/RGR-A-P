using System;
using System.IO;

class Programm
{
    static int[] SortPuz(int[] array)
    {
        int temp;
        for (int i = 0; i  array.Length - 1; i++)
        {
            for (int j = 0; j  array.Length - i - 1; j++)
            {
                if (array[j + 1]  array[j])
                {
                    temp = array[j + 1];обычная сортировка пузыриками
                    array[j + 1] = array[j];
                    array[j] = temp;
                }
            }
        }
        return array;
    }

    public static int perevodtokopeiki(int[] E, int[] N, int[] K)  передаём сначала Е, вторым еденицы измерения,  а потом передаём а потом передаём исключения
    { по факту получаем раельное кол во копеек ( наименьшей денежной еденицы) без этих счастливых чисел
        int newcount = 0; count для проверки на последнейсистеме 
        for (int i = 0; i  K.Length; i++)
        {
            if (E[E.Length - 1] = K[i])
            {
                newcount++;
            }
            else
            {
                break;УСКОРЕНИЕ!!!!!! (СРАБОТАЕТ В СРЕДНЕМ ПОЛ РАЗА)))
            }
        }

        int result = E[E.Length - 1] - newcount;
        for (int i = 0; i  E.Length - 1; i++)
        {
            int Ecount = 0;
            int[] perevodchik = new int[E.Length - i];
            perevodchik[0] = E[i]; принимаю значение
            for (int j = 0; j  K.Length; j++)  обработка несчастливых чисел
            {
                if (E[i] = K[j])
                {
                    Ecount++;
                }
                else
                {
                    break;УСКОРЕНИЕ!!!!!! (СРАБОТАЕТ В СРЕДНЕМ ПОЛ РАЗА)))
                }
            }
            perevodchik[0] = E[i] - Ecount; 
            for (int j = 0; j  perevodchik.Length - 1; j++) это второй вложенный цикол и находится он в for ( int i = 0...) а не в for( int j = 0...)!
            {
                perevodchik[j + 1] += perevodchik[j]  N[j + i];
            }
            result += perevodchik[perevodchik.Length - 1];
        }
        return result;
    }

     перевод в новую денежную систему 

    public static int[] perevodtoreal(int kopeiki, int[] N, int[] K)
    {
        int[] ans = new int[N.Length + 1];
        ans[N.Length] = kopeiki;     с конца заполняем
        int[] Nchis = new int[N.Length];  массив хранящий кол во невузичих чисел в каждой денежной системе
        for (int i = N.Length; i  0; i--)
        {
            ans[i - 1] = ans[i]  N[i - 1];
            ans[i] = ans[i]%N[i - 1];
        }
        for (int i = 0; i  ans.Length; i++)
        {
            for (int j = 0; j  K.Length; j++)
            {
                if (ans[i] = K[j])
                {
                    ans[i]++;  Если исключение совпадает с текущим значением, увеличиваем счётчик
                }
            }
        }
        return ans;
    }

     вводы для для удобства передачи данных

    public static int[] inputN(String S)
    {
        String[] Ssplit = S.Split(' ');
        int N = Convert.ToInt32(Ssplit[0]);
        int[] C = new int[N - 1];
        for (int i = 0; i  N - 1; i++)
        {
            C[i] = Convert.ToInt32(Ssplit[i + 1]);
        }
        return C;
    }
    public static int[] inputK(String S)
    {
        String[] Ssplit = S.Split(' ');
        int K = Convert.ToInt32(Ssplit[0]);
        int[] A = new int[K];
        for (int i = 0; i  K; i++)
        {
            A[i] = Convert.ToInt32(Ssplit[i + 1]);
        }
        return SortPuz(A);
    }
    public static int[] inputE(String S)
    {
        String[] Ssplit = S.Split(' ');
        int[] A = new int[Ssplit.Length];
        for (int i = 0; i  Ssplit.Length; i++)
        {
            A[i] = Convert.ToInt32(Ssplit[i]);
        }
        return A;
    }

     Main() с вводом данных (изменённый Console.ReadLine()), записью значений функций описанных выше, выводом.

    static void Main()
    {
        byte[] inputBuffer = new byte[1024];
        Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
        Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length)); нестандартно решил разрширить Console.ReadLine() ибо 11 тест заставил меня задуматься над смыслом жизни

        string NplusCLine = Console.ReadLine();
        int[] C = inputN(NplusCLine);  данные первой строки с N исх 
        string KLine = Console.ReadLine();
        int[] K = inputK(KLine);  данные второй строки с K исх 
        string NplusDLine = Console.ReadLine();
        int[] D = inputN(NplusDLine);  данные трете строки с N исх 
        string BLine = Console.ReadLine();
        int[] B = inputK(BLine);  данные четвёртой строки с K исх 
        string ELine = Console.ReadLine();
        int[] E = inputE(ELine);  данные 5 строки строки с K исх 
        int kopeiki = perevodtokopeiki(E, C, K);
        int[] ans = perevodtoreal(kopeiki, D, B);
        for (int i = 0; i  ans.Length; i++)
        {
            Console.Write(ans[i] +  );
        }
    }
}
