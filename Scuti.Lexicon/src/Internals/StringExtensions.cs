using System.Collections.Generic;
using System.Text;

namespace Scuti.Lexicon.Internals
{
    internal static class StringExtensions
    {
        public static IEnumerable<object> Parse(this string str)
        {
            StringBuilder buffer = new StringBuilder();
            string tmp = null;
            for (int i = 0; i < str.Length; i++)
            {
                if (Mappers.GetTokens.TryGetValue(str[i], out Tokens token))
                {
                    if (token == Tokens.SINGLE_QUOT)
                    {
                        while (++i < str.Length && (str[i] != '\'' || buffer.Previous() == '\\'))
                        {
                            buffer.Append(str[i]);
                        }
                        yield return buffer.ToString();
                        buffer.Clear();
                    }
                    else if (token == Tokens.HASH)
                    {
                        while (++i < str.Length && str[i] != '\n') ;
                        buffer.Clear();
                    }
                    else
                    {
                        if (buffer.Length > 0)
                        {
                            tmp = buffer.ToString();
                            buffer.Clear();
                            if (Mappers.GetKeywords.TryGetValue(tmp, out Keywords keyword))
                            {
                                yield return keyword;
                            }
                            else
                            {
                                switch (tmp.ParseValue(out object value))
                                {
                                    case Types.REFERENCE:
                                        yield return "";
                                        break;
                                    case Types.DECIMAL:
                                    case Types.INT:
                                        yield return value;
                                        break;
                                }
                            }
                        }
                        if (token > 0)
                        {
                            if (token == Tokens.DOLLAR_SIGN)
                            {
                                yield return Keywords.LET;
                            }
                            else
                            {
                                yield return token;
                            }
                        }
                    }
                }
                else
                {
                    buffer.Append(str[i]);
                }
            }
            if (buffer.Length > 0)
            {
                throw new System.Exception("Invalid Syntax");
            }
        }
        public static Types ParseValue(this string str, out object value)
        {
            bool isDecimal = false;
            foreach (var c in str)
            {
                if (!char.IsDigit(c))
                {
                    if (c != '.')
                    {
                        value = str;
                        return Types.REFERENCE;
                    }
                    else
                    {
                        isDecimal = true;
                        break;
                    }
                }
            }
            if (isDecimal)
            {
                value = decimal.Parse(str);
                return Types.DECIMAL;
            }
            else {
                value = int.Parse(str);
                return Types.INT;
            }
        }
    }
}