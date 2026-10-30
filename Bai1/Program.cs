using System;
using System.Collections.Generic;

class Bai1
{
    static readonly Dictionary<char, char> Match = new()
    {
        [')'] = '(',
        [']'] = '[',
        ['}'] = '{',
    };

    static readonly HashSet<char> Open = new() { '(', '[', '{' };

    static void Main()
    {
        string s = Console.ReadLine() ?? string.Empty;
        string result = CheckParentheses(s);
        Console.WriteLine(result);
    }

    static string CheckParentheses(string s)
    {
        var st = new Stack<(char ch, int pos)>();

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (Open.Contains(c))
            {
                st.Push((c, i));
            }
            else if (Match.ContainsKey(c))
            {
                if (st.Count == 0) return $"SAI tai vi tri {i}";

                var top = st.Pop();

                if (top.ch != Match[c]) return $"SAI tai vi tri {i}";
            }
        }

        if (st.Count > 0)
        {
            int earliest = 0;
            while (st.Count > 0)
            {
                earliest = st.Pop().pos;
            }
            return $"SAI tai vi tri {earliest}";
        }

        return "HOP LE";
    }
}
