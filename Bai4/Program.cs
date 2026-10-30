using System;
using System.Collections.Generic;
using System.Diagnostics;

public class TwoStackQueue<T>
{
    private readonly Stack<T> enqueueStack = new();
    private readonly Stack<T> dequeueStack = new();

    public long Transfers { get; private set; }
    public int Count => enqueueStack.Count + dequeueStack.Count;

    public void Enqueue(T value)
    {
        enqueueStack.Push(value);
    }

    public T Dequeue()
    {
        if (Count == 0) throw new InvalidOperationException("Hang doi rong");

        if (dequeueStack.Count == 0)
        {
            while (enqueueStack.Count > 0)
            {
                dequeueStack.Push(enqueueStack.Pop());
                Transfers++;
            }
        }

        return dequeueStack.Pop();
    }
}

public class NaiveTwoStack<T>
{
    private readonly Stack<T> main = new();
    private readonly Stack<T> temp = new();

    public int Count => main.Count + temp.Count;

    public void Enqueue(T value)
    {
        while (main.Count > 0) temp.Push(main.Pop());

        main.Push(value);

        while (temp.Count > 0) main.Push(temp.Pop());
    }

    public T Dequeue()
    {
        if (Count == 0) throw new InvalidOperationException("Hang doi rong");
        return main.Pop();
    }
}

class Bai4
{
    static void Main()
    {
        Console.WriteLine("=== Ca bat buoc ===");
        var q = new TwoStackQueue<int>();
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);
        Console.WriteLine(q.Dequeue());
        q.Enqueue(4);
        Console.WriteLine(q.Dequeue());
        Console.WriteLine(q.Dequeue());
        Console.WriteLine(q.Dequeue());
        Console.WriteLine($"Transfers: {q.Transfers}");

        Console.WriteLine("\n=== Ca lon ===");
        var big = new TwoStackQueue<int>();
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < 1_000_000; i++) big.Enqueue(i);
        long sum = 0;
        for (int i = 0; i < 1_000_000; i++) sum += big.Dequeue();
        sw.Stop();
        Console.WriteLine($"Transfers: {big.Transfers}");
        Console.WriteLine($"Tong: {sum} | Thoi gian: {sw.ElapsedMilliseconds} ms");

        Console.WriteLine("\n=== Bang 6 ===");
        Console.WriteLine("n\tNaiveTwoStack (ms)\tTwoStackQueue (ms)");
        foreach (int n in new[] { 1000, 5000, 20000 })
        {
            long naiveTime = TimeNaive(n);
            long fastTime = TimeFast(n);
            Console.WriteLine($"{n}\t{naiveTime}\t\t\t{fastTime}");
        }
    }

    static long TimeNaive(int n)
    {
        var q = new NaiveTwoStack<int>();
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < n; i++) q.Enqueue(i);
        for (int i = 0; i < n; i++) q.Dequeue();
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }

    static long TimeFast(int n)
    {
        var q = new TwoStackQueue<int>();
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < n; i++) q.Enqueue(i);
        for (int i = 0; i < n; i++) q.Dequeue();
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }
}
