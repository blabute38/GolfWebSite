using System;
using System.Text;

namespace Golf.Global.Implementations
{
    public static class StringBuilderExtensionMethods
    {
        public static bool EndsWith(this StringBuilder sb, string test)
        {
            return EndsWith(sb, test, StringComparison.CurrentCulture);
        }

        public static bool EndsWith(this StringBuilder sb, string test,
            StringComparison comparison)
        {
            if (sb.Length < test.Length)
                return false;

            string end = sb.ToString(sb.Length - test.Length, test.Length);
            return end.Equals(test, comparison);
        }
    }
}
