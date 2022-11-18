using System;

namespace GenshinArtifactCalculator.Util
{
    public static class Utils
    {
        // https://stackoverflow.com/a/6944095
        public static int ComputeLevenshteinDistance(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.IsNullOrEmpty(t) ? 0 : t.Length;
            }
            if (string.IsNullOrEmpty(t))
            {
                return s.Length;
            }
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];
            for (int i = 0; i <= n; i++)
            {
                d[i, 0] = i;
            }
            for (int j = 1; j <= m; j++)
            {
                d[0, j] = j;
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = t[j - 1] == s[i - 1] ? 0 : 1;
                    int min1 = d[i - 1, j] + 1;
                    int min2 = d[i, j - 1] + 1;
                    int min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return d[n, m];
        }

        // https://stackoverflow.com/questions/6092243/c-sharp-check-if-a-decimal-has-more-than-3-decimal-places
        public static decimal CountDecimalPlaces(decimal dec)
        {
            int[] bits = decimal.GetBits(dec);
            ulong lowInt = (uint) bits[0];
            ulong midInt = (uint) bits[1];
            int exponent = (bits[3] & 0x00FF0000) >> 16;
            int result = exponent;
            ulong lowDecimal = lowInt | (midInt << 32);
            while (result > 0 && (lowDecimal % 10) == 0)
            {
                result--;
                lowDecimal /= 10;
            }
            return result;
        }
    }
}
