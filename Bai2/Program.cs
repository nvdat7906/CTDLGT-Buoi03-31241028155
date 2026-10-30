using System;
using System.Collections.Generic;
using System.Globalization;

class Customer
{
    public int Index { get; set; }
    public long Arrival { get; set; }
    public long Service { get; set; }
}

class Bai2
{
    static void Main()
    {
        string[] first = Console.ReadLine().Split();
        int n = int.Parse(first[0]);
        int k = int.Parse(first[1]);

        var queue = new Queue<Customer>();

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split();
            queue.Enqueue(new Customer
            {
                Index = i + 1,
                Arrival = long.Parse(parts[0]),
                Service = long.Parse(parts[1])
            });
        }

        long[] freeTime = new long[k];

        long totalWait = 0;
        long maxWait = 0;
        long finishTime = 0;

        while (queue.Count > 0)
        {
            Customer cust = queue.Dequeue();

            int best = 0;
            for (int j = 1; j < k; j++)
            {
                if (freeTime[j] < freeTime[best]) best = j;
            }

            long start = Math.Max(freeTime[best], cust.Arrival);

            long wait = start - cust.Arrival;
            totalWait += wait;
            if (wait > maxWait) maxWait = wait;

            long end = start + cust.Service;
            freeTime[best] = end;
            if (end > finishTime) finishTime = end;

            Console.WriteLine($"KH {cust.Index}: den {cust.Arrival}, quay {best + 1}, bat dau {start}, cho {wait}, xong {end}");
        }

        double avgWait = (double)totalWait / n;
        Console.WriteLine($"Cho trung binh: {avgWait.ToString("F2", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Cho lau nhat: {maxWait}");
        Console.WriteLine($"Hoan thanh luc: {finishTime}");
    }
}
