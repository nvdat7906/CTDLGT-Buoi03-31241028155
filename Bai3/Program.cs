using System;

public class CircularQueue<T>
{
    private T[] items;
    private int front;
    private int count;

    public int Count => count;
    public int Capacity => items.Length;

    public CircularQueue()
    {
        items = new T[4];
        front = 0;
        count = 0;
    }

    public void Enqueue(T value)
    {
        if (count == items.Length)
        {
            Grow();
        }

        int rear = (front + count) % items.Length;
        items[rear] = value;
        count++;
    }

    public T Dequeue()
    {
        if (count == 0) throw new InvalidOperationException("Hang doi rong");

        T value = items[front];

        items[front] = default!;

        front = (front + 1) % items.Length;
        count--;
        return value;
    }

    public T Peek()
    {
        if (count == 0) throw new InvalidOperationException("Hang doi rong");
        return items[front];
    }

    private void Grow()
    {
        int newCapacity = items.Length * 2;
        T[] newItems = new T[newCapacity];

        for (int i = 0; i < count; i++)
        {
            newItems[i] = items[(front + i) % items.Length];
        }

        items = newItems;
        front = 0;
    }
}

class Bai3
{
    static void Main()
    {
        Test("Ca 1 - Hang rong", () =>
        {
            var q = new CircularQueue<char>();
            Console.WriteLine($"Count {q.Count}, Capacity {q.Capacity}");
            try { q.Dequeue(); } catch (InvalidOperationException e) { Console.WriteLine($"Dequeue ném: {e.Message}"); }
            try { q.Peek(); } catch (InvalidOperationException e) { Console.WriteLine($"Peek ném: {e.Message}"); }
        });

        Test("Ca 2 - Vua day", () =>
        {
            var q = new CircularQueue<char>();
            foreach (char c in new[] { 'A', 'B', 'C', 'D' }) q.Enqueue(c);
            Console.WriteLine($"Count {q.Count}, Capacity {q.Capacity}, Peek {q.Peek()}");
        });

        Test("Ca 3 - Quay vong chua mo rong", () =>
        {
            var q = new CircularQueue<char>();
            foreach (char c in new[] { 'A', 'B', 'C', 'D' }) q.Enqueue(c);
            Console.Write(q.Dequeue());
            Console.Write(q.Dequeue());
            foreach (char c in new[] { 'E', 'F' }) q.Enqueue(c);
            Console.Write(q.Dequeue());
            Console.Write(q.Dequeue());
            Console.Write(q.Dequeue());
            Console.Write(q.Dequeue());
            Console.WriteLine($" | Capacity {q.Capacity}");
        });

        Test("Ca 4 - Mo rong khi front = 0", () =>
        {
            var q = new CircularQueue<int>();
            foreach (int v in new[] { 1, 2, 3, 4, 5 }) q.Enqueue(v);
            var sb = new System.Text.StringBuilder();
            while (q.Count > 0) sb.Append(q.Dequeue());
            Console.WriteLine($"{sb} | Capacity {q.Capacity}");
        });

        Test("Ca 5 - Mo rong khi front khac 0", () =>
        {
            var q = new CircularQueue<char>();
            foreach (char c in new[] { 'A', 'B', 'C', 'D' }) q.Enqueue(c);
            q.Dequeue();
            q.Dequeue();
            foreach (char c in new[] { 'E', 'F', 'G' }) q.Enqueue(c);
            var sb = new System.Text.StringBuilder();
            while (q.Count > 0) sb.Append(q.Dequeue());
            Console.WriteLine($"{sb} | Capacity {q.Capacity}");
        });

        Test("Ca 6 - Quay vong 1 trieu lan", () =>
        {
            var q = new CircularQueue<int>();
            for (int i = 0; i < 1_000_000; i++)
            {
                q.Enqueue(i);
                q.Dequeue();
            }
            Console.WriteLine($"Khong loi | Capacity {q.Capacity}");
        });

        Test("Ca 7 - Ca lon 100 000 phan tu", () =>
        {
            var q = new CircularQueue<int>();
            var sw = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 100_000; i++) q.Enqueue(i);
            var sb = new System.Text.StringBuilder();
            bool ok = true;
            for (int i = 0; i < 100_000; i++)
            {
                if (q.Dequeue() != i) ok = false;
            }
            sw.Stop();
            Console.WriteLine($"Dung thu tu: {ok} | Capacity cuoi: {q.Capacity} | Thoi gian: {sw.ElapsedMilliseconds} ms");
        });
    }

    static void Test(string name, System.Action action)
    {
        Console.WriteLine($"=== {name} ===");
        action();
        Console.WriteLine();
    }
}
