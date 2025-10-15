// R1_T05_05_Deljivost_01_Prost                         // https://petlja.org/sr-Latn-RS/kurs/17862/23/2755
// R3_T01_01_Algebarski_algoritmi_01_Test_primalnosti   // https://petlja.org/sr-Latn-RS/kurs/17918/1/5314
// https://petlja.org/sr-Latn-RS/kurs/17918/1/5316
// https://petlja.org/sr-Latn-RS/biblioteka/r/Zbirka3/prost_broj
// https://github.com/draganilicnis/R3_T01_01_Algebarski_algoritmi_01_Test_primalnosti_Prost_broj
// 1000000007
// 1111111111111111111

using System;
using System.Diagnostics;

class R1_T05_05_Deljivost_01_Prost
{
    static void Main()
    {
        // ulong n = ulong.Parse(Console.ReadLine());
        // Console.WriteLine(Prost_Ver_04(n) ? "DA" : "NE");
        Main_Prost_Stoperica();
    }

    static void Main_Prost_Stoperica()
    {
        ulong n = 1000000007;
        Console.WriteLine(n);
        bool prost = false;
        Stopwatch t = new Stopwatch();
        t.Start(); prost = Prost_Ver_01(n); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
        t.Start(); prost = Prost_Ver_02(n); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
        t.Start(); prost = Prost_Ver_03(n); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
        t.Start(); prost = Prost_Ver_04(n); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();

        n = 1111111111111111111;
        Console.WriteLine(n);
        // t.Start(); prost = Prost_Ver_01(n); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
        // t.Start(); prost = Prost_Ver_02(n); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
        t.Start(); prost = Prost_Ver_03(n); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
        t.Start(); prost = Prost_Ver_04(n); t.Stop(); Console.WriteLine(t.Elapsed); t.Reset();
    }

    // Slozenost: O(Sqrt(N)): Odsecanje u pretrazi: Ispituje sve delioce od 2 do Sqrt(n)
    // Provera samo brojeva oblika 6k-1 i 6k+1 : 5, 7, 11, 13, 17, 19, 23, 25, 29, 31, 35, 37...(ne proverava 9, 15, 21, 27, 33, jer su deljivi sa 3)
    // Provera sa jednog na svaka tri neparna broja, brze, sto je srazmerno znatno manja usteda
    static bool Prost_Ver_04(ulong n)
    {
        if (n == 1 || (n % 2 == 0 && n != 2) || (n % 3 == 0 && n != 3)) return false;
        for (ulong k = 1; (6 * k - 1) * (6 * k - 1) <= n; k++)
            if (n % (6 * k - 1) == 0 || n % (6 * k + 1) == 0) return false;
        return true;
    }

    static bool Prost_Ver_03(ulong n)
    {
        if (n <= 1) return false;
        else if (n == 2) return true;
        else if (n % 2 == 0) return false;
        else
            for (ulong d = 3; d * d <= n; d = d + 2)
                if (n % d == 0) return false;
        return true;
    }
    static bool Prost_Ver_02(ulong n)
    {
        if (n <= 1) return false;
        else if (n == 2) return true;
        else
            for (ulong d = 2; d * d <= n; d++)
                if (n % d == 0) return false;
        return true;
    }
    static bool Prost_Ver_01(ulong n)
    {
        if (n <= 1) return false;
        else
            for (ulong d = 2; d < n; d++)
                if (n % d == 0) return false;
        return true;
    }
    static bool Prost_Ver_00(ulong n)
    {
        bool prost = true;
        if (n <= 1) prost = false;
        else
        {
            for (ulong d = 2; d < n; d++)
                if (n % d == 0) { prost = false; /* break; */ }
        }
        return prost;
    }
}

/*
    static bool Prost_Ver_03(ulong n)
    {
        if (n <= 1) return false;
        else if (n == 2) return true;
        else if (n % 2 == 0) return false;
        else
            for (ulong d = 3; d * d <= n; d = d + 2)
                if (n % d == 0) return false; 
        return true;
    }
    static bool Prost_Ver_02(ulong n)
    {
        if (n <= 1) return false;
        else if (n == 2) return true;
        else
            for (ulong d = 2; d * d <= n; d++)
                if (n % d == 0) return false;
        return true;
    }
    static bool Prost_Ver_01(ulong n)
    {
        if (n <= 1) return false;
        else
            for (ulong d = 2; d < n; d++)
                if (n % d == 0) return false;
        return true;
    }
    static bool Prost_Ver_00(ulong n)
    {
        bool prost = true;
        if (n <= 1) prost = false;
        else
        {
            for (ulong d = 2; d < n; d++)
                if (n % d == 0) { prost = false; /* break; */ /*}
        }
        return prost;
    }
}
*/
