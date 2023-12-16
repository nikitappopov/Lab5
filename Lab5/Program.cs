using System.Text;
using System.Collections.Generic;
using System.Linq;
using System;

public class CodeWars
{
    public static string Encode(string text)
    {
        List<string> list = new List<string>();
        foreach (var c in text)
            list.Add(Convert.ToString(c, 2).PadLeft(8, '0'));
        return string.Concat(list.ToArray()).Replace("0", "000").Replace("1", "111");
    }
    public static string Decode(string bits)
    {
        if (bits.Length % 24 != 0)
            throw new Exception("error");
        byte[] bytes = new byte[bits.Length / 24];
        var b = Split(bits, 3).ToArray();
        for (int i = 0; i < b.Length; i++)
        {
            if (b[i][0] == b[i][1])
                bytes[i >> 3] |= (byte)(b[i][0] == '1' ? 1 << (7 - i & 7) : 0);
            else if (b[i][2] == b[i][1])
                bytes[i >> 3] |= (byte)(b[i][1] == '1' ? 1 << (7 - i & 7) : 0);
            else
                bytes[i >> 3] |= (byte)(b[i][0] == '1' ? 1 << (7 - i & 7) : 0);
        }
        return Encoding.ASCII.GetString(bytes);
    }

    static IEnumerable<string> Split(string str, int chunkSize)
    {
        return Enumerable.Range(0, str.Length / chunkSize)
            .Select(i => str.Substring(i * chunkSize, chunkSize));
    }
}