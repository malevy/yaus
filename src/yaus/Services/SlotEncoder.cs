using System.Collections.Generic;
using System.Text;

namespace yaus.Services
{
    public static class SlotEncoder
    {
        private static readonly char[] SymbolSpace = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        private static readonly int Base = SymbolSpace.Length;

        public static string Encode(long slotNumber)
        {
            var symbols = new Stack<char>();

            var num = slotNumber;
            while (num > 0)
            {
                symbols.Push(SymbolSpace[(num % Base)]);
                num /= Base;
            }

            var builder = new StringBuilder();
            while (symbols.Count > 0)
            {
                builder.Append(symbols.Pop());
            }

            return builder.ToString();
        }

    }
}