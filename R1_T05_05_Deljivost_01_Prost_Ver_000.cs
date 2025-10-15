using System;
using System.Diagnostics;

class R1_T05_05_Deljivost_01_Prost_Ver_000
{
    static void Main()
    {
        Main_Prost_Stoperica();
    }
    static void Main_Prost_Stoperica()
    {
        bool prost = false;
        ulong n = 1000000007;       // n = 10^9 + 7
        Console.WriteLine(n);
        Stopwatch t = new Stopwatch();
        t.Start(); prost = Prost_Ver_01_Spor(n); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
        t.Start(); prost = Prost_Ver_04_Brzi(n); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();

        n = 1111111111111111111;    // n > 10^19
        Console.WriteLine(n);
        // t.Start(); prost = Prost_Ver_01(n); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
        t.Start(); prost = Prost_Ver_04_Brzi(n); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
    }

    static bool Prost_Ver_04_Brzi(ulong n)          // O(Sqrt(N)) 
    {
        if (n == 1 || (n % 2 == 0 && n != 2) || (n % 3 == 0 && n != 3)) return false;
        for (ulong k = 1; (6 * k - 1) * (6 * k - 1) <= n; k++)
            if (n % (6 * k - 1) == 0 || n % (6 * k + 1) == 0) return false;
        return true;
    }
    static bool Prost_Ver_01_Spor(ulong n)          // O(N)
    {
        if (n <= 1) return false;
        else
        {
            for (ulong d = 2; d < n; d++)
                if (n % d == 0) return false;
        }
        return true;
    }
}
