using System.Text;

namespace Scuti.Lexicon.Internals
{
    internal static class StringBuilderExtensions
    {
        public static char Previous(this StringBuilder sb)
        {
            if (sb.Length > 1)
            {
                return sb[sb.Length - 1];
            }
            return '\0';
        }
    }
}