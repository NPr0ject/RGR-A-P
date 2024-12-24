using System;
class HelloWorld
{
    static void Main()
    {
        int[] mounts = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        string[] fd = Console.ReadLine().Split('.');
        string[] sd = Console.ReadLine().Split('.');
        int day_proiz = Convert.ToInt32(Console.ReadLine());


        int fdd = 365 * Convert.ToInt32(fd[2]) + Convert.ToInt32(fd[2]) / 4 + Convert.ToInt32(fd[0]);
        for (int i = 0; i < Convert.ToInt32(fd[1]); i++)
        {
            fdd += mounts[i];
        }
        int ldd = 365 * Convert.ToInt32(sd[2]) + Convert.ToInt32(sd[2]) / 4 + Convert.ToInt32(sd[0]);
        for (int i = 0; i < Convert.ToInt32(sd[1]); i++)
        {
            ldd += mounts[i];
        }
        int n = ldd - fdd;
        int ans = ((2 * day_proiz + n - 1) * n) / 2;
        Console.WriteLine(ans);
    }
}
